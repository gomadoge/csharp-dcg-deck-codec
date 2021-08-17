using GomaDoge.DCG.DeckCodec.Test.TestData;
using NUnit.Framework;

namespace GomaDoge.DCG.DeckCodec.Test
{
  [TestFixture]
  public class DeckCodecDecodeTests
  {
    [Test]
    public void Decode_DoesNotStartWithDCG()
    {
      Assert.Throws<DeckCodecException>(() => DeckCodec.Decode("AREdU1QxIEHBU1QxIE_CwcHBwUHBwUFBwcHBQUFTdGFydGVyIERlY2ssIEdhaWEgUmVkIFtTVC0xXQ"));
    }

    [Test]
    public void Decode_StarterDecks(
      [Values("ST1", "ST2", "ST3", "ST4", "ST5", "ST6")] string deckName,
      [Values(0, 1, 2, 3)] int version
    )
    {
      (string encoded, CardDeck expected) = DecksEncoded.StarterDecks(deckName, version);
      Assert.AreEqual(expected, DeckCodec.Decode(encoded));
    }

    [Test]
    public void Decode_DeckWithSingleCardCountFifty(
      [Values(
        "DCGIWkdAJydAUEDAZydAU8xAgMBAwEDAQMBAQEDAQMBAQEBAQMBAwEDAQEBAQFTdGFydGVyIERlY2ssIEdhaWEgUmVkIFtTVC0xXQ", // version 2
        "DCGOWkdAJydAUEDAZydAU8xAgMBAwEDAQMBAQEDAQMBAQEBAQMBAwEDAQEBAQFTdGFydGVyIERlY2ssIEdhaWEgUmVkIFtTVC0xXQ"  // version 3
      )] string encoded
    )
    {
      CardDeck expectedDeckBase = DecksEncoded.StarterDecks("ST1", 0).Item2;
      CardDeck expectedDeck = new CardDeckBuilder(expectedDeckBase)
          .WithDeckCard("ST1-02", 50)
          .Build();

      Assert.AreEqual(expectedDeck, DeckCodec.Decode(encoded));
    }

    [Test]
    public void Decode_DeckWithParallelArt(
      [Values(
        "DCGApQzQlQyIIHBU1QxIEEBQlQxIIQFAsYCQU0QQlQyIIHEBEJUMyCGxALFAYNCwYUNU1QxIEbCwYMBiEUCRGlnaSBCcm9zOiBSYWduYWxvYXJkbW9uIFJlZCAoeW91dHUuYmUvbzBLb1cyd3doUjQp", // version 1
        "DCGEoozi50CgQMBnJ0BQQABi50BhAAJAwoBAQExBIudAoEDEAGLnQOGAwgDBQIDAQIDAQIVA5ydAUYDAgMBAgMAAQIgAQlEaWdpIEJyb3M6IFJhZ25hbG9hcmRtb24gUmVkICh5b3V0dS5iZS9vMEtvVzJ3d2hSNCk", // version 2
        "DCGOoozAIudAoEDAZydAUEAAYudAYQACQMKAQEBMQSLnQKBAxABi50DhgMIAwUCAwECAwECFQOcnQFGAwIDAQIDAAECIAEJRGlnaSBCcm9zOiBSYWduYWxvYXJkbW9uIFJlZCAoeW91dHUuYmUvbzBLb1cyd3doUjQp"  // version 3
      )] string encoded
    )
    {
      CardDeck expectedDeck = new CardDeckBuilder()
          .WithName("Digi Bros: Ragnaloardmon Red (youtu.be/o0KoW2wwhR4)")
          .WithDigiEggCard("BT2-001", 4)
          .WithDigiEggCard("ST1-01", 1)
          .WithDeckCard("BT1-009", 1)
          .WithDeckCard("BT1-019", 4)
          .WithDeckCard("BT1-020", 2)
          .WithDeckCard("BT1-085", 2, 1)
          .WithDeckCard("BT2-016", 4)
          .WithDeckCard("BT3-008", 4)
          .WithDeckCard("BT3-013", 4)
          .WithDeckCard("BT3-016", 3)
          .WithDeckCard("BT3-018", 2)
          .WithDeckCard("BT3-019", 4)
          .WithDeckCard("BT3-072", 3)
          .WithDeckCard("ST1-02", 4)
          .WithDeckCard("ST1-03", 4)
          .WithDeckCard("ST1-06", 3)
          .WithDeckCard("ST1-07", 1)
          .WithDeckCard("ST1-07", 3, 1)
          .WithDeckCard("ST1-16", 2)
          .Build();

      Assert.AreEqual(expectedDeck, DeckCodec.Decode(encoded));
    }

    [Test]
    public void Decode_DeckWithSideboard(
      [Values(
        "DCGIkAzB4udAoEDAZydAUEAAYudAYQACQMKAQEBMQSLnQKBAxABi50DhQMIAwUCAwECAwGLnQOBAhgEnJ0BRgMCAwECAwABAiABCURpZ2kgQnJvczogUmFnbmFsb2FyZG1vbiBSZWQgKHlvdXR1LmJlL28wS29XMnd3aFI0KQ"  // version 2
      )] string encoded
    )
    {
      CardDeck expectedDeck = new CardDeckBuilder()
          .WithName("Digi Bros: Ragnaloardmon Red (youtu.be/o0KoW2wwhR4)")
          .WithDigiEggCard("BT2-001", 4)
          .WithDigiEggCard("ST1-01", 1)
          .WithDeckCard("BT1-009", 1)
          .WithDeckCard("BT1-019", 4)
          .WithDeckCard("BT1-020", 2)
          .WithDeckCard("BT1-085", 2, 1)
          .WithDeckCard("BT2-016", 4)
          .WithDeckCard("BT3-008", 4)
          .WithDeckCard("BT3-013", 4)
          .WithDeckCard("BT3-016", 3)
          .WithDeckCard("BT3-018", 2)
          .WithDeckCard("BT3-019", 4)
          .WithSideboardCard("BT3-072", 3)
          .WithSideboardCard("ST1-02", 4)
          .WithSideboardCard("ST1-03", 4)
          .WithSideboardCard("ST1-06", 3)
          .WithSideboardCard("ST1-07", 1)
          .WithSideboardCard("ST1-07", 3, 1)
          .WithSideboardCard("ST1-16", 2)
          .Build();

      Assert.AreEqual(expectedDeck, DeckCodec.Decode(encoded));
    }

    [Test]
    public void Decode_JapaneseDeck(
      [Values(
        "DCGMTsYAJydAUEDAZydAU8DAgMBAwEDAQMBAQEDAQMBAQEBAQMBAwEDAQEBAQHkuojnrpfjga7otaTjgYTjg4fjg4Pjgq0"   // version 3
      )] string encoded
    )
    {
      CardDeck expectedDeckBase = DecksEncoded.StarterDecks("ST1", 0).Item2;
      CardDeck expectedDeck = new CardDeckBuilder(expectedDeckBase)
          .WithName("予算の赤いデッキ")
          .WithLanguage("ja")
          .Build();

      Assert.AreEqual(expectedDeck, DeckCodec.Decode(encoded));
    }

    [Test]
    public void Decode_ChecksumDoesNotMatch([Values(0, 1, 2, 3)] int version)
    {
      (string encoded, _) = DecksEncoded.StarterDecks("ST1", version);
      encoded = encoded[..4] + (char)(encoded[4] + 1) + encoded[5..];

      Assert.Throws<DeckCodecException>(() => DeckCodec.Decode(encoded));
    }

    // TODO: There are still many error cases that need to be tested.
  }
}
