using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using GomaDoge.DCG.DeckCodec.Extensions;
using GomaDoge.DCG.DeckCodec.Utils;

namespace GomaDoge.DCG.DeckCodec
{
  record DeckCodecHeader(
      int Version,
      string Language,
      int DigiEggCardSets,
      int Checksum,
      int DeckNameBytes,
      int SideboardCards
  );

  record CardSetHeader(string Name, int ZeroPadding, int CardCount);

  /// <summary>
  /// Wrapper around the DCG deck codec.
  /// Bit numbering and indexing starts with the most significant bit.
  /// </summary>
  public static class DeckCodec
  {
    /// <summary>
    /// Parses the header of the deck codec.
    ///
    ///   byte 1:
    ///     bit 1 2 3 4 _ _ _ _: Version
    /// version < 3:
    ///     bit _ _ _ _ 5 6 7 8: Digi-Egg card set count
    /// else:
    ///     bit _ _ _ _ 5 _ _ _: Language (0 = ja, 1 = en)
    ///     bit _ _ _ _ _ 6 7 8: Digi-Egg card set count
    /// end
    ///   byte 2: Checksum
    ///   byte 3: Deck name string byte count
    /// version >= 2:
    ///   byte 4: Sideboard card count
    /// end
    /// </summary>
    /// <param name="reader">The object used to read the deck codec bytes.</param>
    /// <returns>The parsed deck codec header.</returns>
    private static DeckCodecHeader ParseDeckCodecHeader(BinaryReader reader)
    {
      byte[] headerBytes = reader.ReadBytes(3);

      int version = headerBytes[0] >> 4;
      string language = (version < 3 || headerBytes[0].IsBitSet(4))
          ? "en"
          : "ja";
      int digiEggCardSets = (version < 3)
          ? (headerBytes[0] & 0b_0000_1111)
          : (headerBytes[0] & 0b_0000_0111);
      int checksum = headerBytes[1];
      int deckNameBytes = headerBytes[2];
      int sideboardCards = (version >= 2)
          ? reader.ReadByte()
          : 0;

      return new DeckCodecHeader(version, language, digiEggCardSets, checksum, deckNameBytes, sideboardCards);
    }

    /// <summary>
    /// Parses the header of a card set.
    ///
    /// version 0:
    ///   byte 1-4: Card set name as ASCII characters
    ///   byte 5:
    ///     bit 1 2 _ _ _ _ _ _: Card zero padding (stored zero-based)
    ///     bit _ _ 3 4 5 6 7 8: Card count
    /// else:
    ///   byte 1-x: Card set name encoded as Base36 characters.
    ///             Continue as long as the 1st bit is set.
    ///     bit 1 _ _ _ _ _ _ _: Continue bit
    ///     bit _ 2 3 4 5 6 7 8: Base36 encoded character
    ///   byte x+1:
    ///     bit 1 2 _ _ _ _ _ _: Card zero padding (stored zero-based)
    ///     bit _ _ 3 4 5 6 7 8: Card count
    /// end
    /// </summary>
    /// <param name="reader">The object used to read the deck codec bytes.</param>
    /// <param name="deckCodecHeader">The deck codec header.</param>
    /// <returns>The parsed card set header.</returns>
    private static CardSetHeader ParseCardSetHeader(BinaryReader reader, DeckCodecHeader deckCodecHeader)
    {
      string setName = "";

      if (deckCodecHeader.Version == 0)
      {
        setName = Encoding.ASCII.GetString(reader.ReadBytes(4));
      }
      else
      {
        bool continueCardSetName = true;

        while (continueCardSetName)
        {
          byte setNameCharByte = reader.ReadByte();

          setName += EncodingUtils.DecodeBase36(setNameCharByte & 0b_0111_1111);
          continueCardSetName = setNameCharByte.IsBitSet(0);
        }
      }

      byte paddingAndCardSetCount = reader.ReadByte();
      int zeroPadding = (paddingAndCardSetCount >> 6) + 1;
      int cardCount = paddingAndCardSetCount & 0b_0011_1111;

      return new CardSetHeader(setName, zeroPadding, cardCount);
    }

    /// <summary>
    /// Parses a card of a card set.
    ///
    /// version 0:
    ///   byte 1:
    ///     bit 1 2 _ _ _ _ _ _: Card count (stored zero-based)
    ///     bit _ _ 3 4 5 _ _ _: Parallel ID
    ///     bit _ _ _ _ _ 6 7 8: Card number offset (card number = previous card number + offset)
    ///   byte 2-x: If the card number cannot be contained in bit 6-8, the continue bit is set (1st bit).
    ///             Use the next byte for the card number. Continue as long as the 1st bit is set.
    ///     bit 1 _ _ _ _ _ _ _: Continue bit
    ///     bit _ 2 3 4 5 6 7 8: Additional bits for card number offset.
    ///                          Already parsed bits are less significant than these.
    /// version > 0:
    ///   byte 1: Card count (stored zero-based)
    ///   byte 2:
    ///     bit 1 2 3 _ _ _ _ _: Parallel ID
    ///     bit _ _ _ 4 5 6 7 8: Card number offset (card number = previous card number + offset)
    ///   byte 3-x: If the card number cannot be contained in bit 6-8, the continue bit is set (1st bit).
    ///             Use the next byte for the card number. Continue as long as the 1st bit is set.
    ///     bit 1 _ _ _ _ _ _ _: Continue bit
    ///     bit _ 2 3 4 5 6 7 8: Additional bits for card number offset.
    ///                          Already parsed bits are less significant than these.
    /// end
    /// </summary>
    /// <param name="reader">The object used to read the deck codec bytes.</param>
    /// <param name="deckCodecHeader">The deck codec header.</param>
    /// <param name="cardSetHeader">The card set header.</param>
    /// <param name="lastCardNumber">The number of the last card used to compute the number of this card.</param>
    /// <returns></returns>
    private static Card ParseCard(BinaryReader reader, DeckCodecHeader deckCodecHeader, CardSetHeader cardSetHeader, ref int lastCardNumber)
    {
      int cardNumber;
      int cardCount;
      int parallelID;

      if (deckCodecHeader.Version == 0)
      {
        byte cardByte = reader.ReadByte();
        cardCount = (cardByte >> 6) + 1;
        parallelID = (cardByte >> 3) & 0b_0000_0111;
        cardNumber = cardByte & 0b_0000_0011;
        int currentShift = 2;

        if (cardByte.IsBitSet(5))
        {
          byte currentByte;

          do
          {
            currentByte = reader.ReadByte();
            cardNumber = ((currentByte & 0b_0111_1111) << currentShift) | cardNumber;
            currentShift += 7;
          } while (currentByte.IsBitSet(0));
        }
      }
      else
      {
        cardCount = reader.ReadByte() + 1;

        byte parallelAndNumber = reader.ReadByte();
        parallelID = (parallelAndNumber & 0b_1110_0000) >> 5;
        cardNumber = parallelAndNumber & 0b_0000_1111;
        int currentShift = 4;

        if (parallelAndNumber.IsBitSet(3))
        {
          byte currentByte;

          do
          {
            currentByte = reader.ReadByte();
            cardNumber = ((currentByte & 0b_0111_1111) << currentShift) | cardNumber;
            currentShift += 7;
          } while (currentByte.IsBitSet(0));
        }
      }

      cardNumber += lastCardNumber;
      lastCardNumber = cardNumber;

      return new Card
      {
        Number = $"{cardSetHeader.Name.Trim()}-{cardNumber.ToString("D" + cardSetHeader.ZeroPadding)}",
        Count = cardCount,
        ParallelID = parallelID
      };
    }

    private static byte ComputeChecksum(byte[] deckCodecBytes, int cardSetBytes, int skipCount)
    {
      int checksum = 0;

      for (int i = skipCount; i < cardSetBytes; i++)
      {
        checksum += deckCodecBytes[i];
      }

      return (byte)(checksum & 0b_1111_1111);
    }

    /// <summary>
    /// Decodes the given deck codec string.
    /// </summary>
    /// <param name="deckCodec">A string starting with "DCG" followed by a Base64URL encoded string.</param>
    /// <returns>The decoded card deck.</returns>
    public static CardDeck Decode(string deckCodec)
    {
      if (!deckCodec.StartsWith("DCG"))
      {
        throw new DeckCodecException("DCG deck codecs must start with 'DCG'.");
      }

      List<Card> digiEggCards = new();
      List<Card> deckCards = new();
      List<Card> sideboardCards = new();

      byte[] deckCodecBytes = EncodingUtils.DecodeBase64URL(deckCodec[3..]);
      using MemoryStream deckCodecStream = new(deckCodecBytes);
      using BinaryReader deckCodecReader = new(deckCodecStream);

      var deckCodecHeader = ParseDeckCodecHeader(deckCodecReader);
      int cardSetBytes = deckCodecBytes.Length - deckCodecHeader.DeckNameBytes;
      byte checksum = ComputeChecksum(deckCodecBytes, cardSetBytes, 3);

      int currentSet = 0;

      while (deckCodecStream.Position < cardSetBytes)
      {
        var cardSetHeader = ParseCardSetHeader(deckCodecReader, deckCodecHeader);
        int lastCardNumber = 0;

        for (int cardIndex = 0; cardIndex < cardSetHeader.CardCount; cardIndex++)
        {
          var card = ParseCard(deckCodecReader, deckCodecHeader, cardSetHeader, ref lastCardNumber);

          if (currentSet < deckCodecHeader.DigiEggCardSets)
          {
            digiEggCards.Add(card);
          }
          else
          {
            deckCards.Add(card);
          }
        }

        currentSet++;
      }

      sideboardCards.AddRange(deckCards.TakeLast(deckCodecHeader.SideboardCards));
      deckCards.RemoveRange(deckCards.Count - deckCodecHeader.SideboardCards, deckCodecHeader.SideboardCards);

      byte[] utfDeckName = deckCodecReader.ReadBytes(deckCodecHeader.DeckNameBytes);
      string deckName = Encoding.UTF8.GetString(utfDeckName);

      return new CardDeck
      {
        Name = deckName,
        Language = deckCodecHeader.Language,
        DigiEggs = digiEggCards,
        Deck = deckCards,
        Sideboard = sideboardCards
      };
    }

    public static string Encode(string deckJSON)
    {
      throw new NotImplementedException("Encoding is not supported yet.");
    }
  }
}
