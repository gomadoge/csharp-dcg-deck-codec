using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GomaDoge.DCG.DeckCodec
{
  public class CardDeck
  {
    [JsonPropertyName("deck/name")]
    public string Name { get; set; }

    [JsonPropertyName("deck/language")]
    public string Language { get; set; }

    [JsonPropertyName("deck/digi-eggs")]
    public IEnumerable<Card> DigiEggs { get; set; }

    [JsonPropertyName("deck/deck")]
    public IEnumerable<Card> Deck { get; set; }

    [JsonPropertyName("deck/sideboard")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public IEnumerable<Card> Sideboard { get; set; }

    public override bool Equals(object obj)
    {
      return obj is CardDeck deck &&
             Name == deck.Name &&
             Language == deck.Language &&
             Enumerable.SequenceEqual(DigiEggs, deck.DigiEggs) &&
             Enumerable.SequenceEqual(Deck, deck.Deck) &&
             Enumerable.SequenceEqual(Sideboard, deck.Sideboard);
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(Name, Language, DigiEggs, Deck, Sideboard);
    }

    public override string ToString()
    {
      return JsonSerializer.Serialize(this);
    }
  }
}
