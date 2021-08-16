using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using System.Text.Json;

namespace GomaDoge.DCG.DeckCodec.CLI
{
  public class Program
  {
    static int Main(string[] args)
    {
      var decodeCommand = new Command("decode", "Decodes the given deck codec as JSON")
      {
        new Argument<string>("deckCodec", "Base64URL encoded deck codec starting with 'DCG'")
      };

      var encodeCommand = new Command("encode", "Encodes the given JSON as a deck codec")
      {
        new Argument<string>("deckJSON", "DCG deck as JSON")
      };

      var rootCommand = new RootCommand("A command line tool to work with DCG deck codecs")
      {
          decodeCommand,
          encodeCommand
      };

      decodeCommand.Handler = CommandHandler.Create<string>((deckCodec) =>
      {
        try
        {
          CardDeck deck = DeckCodec.Decode(deckCodec);

          if (!deck.Sideboard.Any())
          {
            // Set sideboard to null if it is empty to prevent its serialization.
            deck.Sideboard = null;
          }

          Console.WriteLine(JsonSerializer.Serialize(deck, new JsonSerializerOptions
          {
            WriteIndented = false
          }));
        }
        catch (Exception e)
        {
          Console.WriteLine($"Error while decoding: {e.Message}");
        }
      });

      encodeCommand.Handler = CommandHandler.Create<string>((deckJSON) =>
      {
        try
        {
          string deckEncoded = DeckCodec.Encode(deckJSON);
          Console.WriteLine(deckEncoded);
        }
        catch (Exception e)
        {
          Console.WriteLine($"Error while encoding: {e.Message}");
        }
      });

      return rootCommand.InvokeAsync(args).Result;
    }
  }
}
