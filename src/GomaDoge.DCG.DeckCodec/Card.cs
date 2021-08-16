using System;
using System.Text.Json.Serialization;

namespace GomaDoge.DCG.DeckCodec
{
  public class Card
  {
    [JsonPropertyName("card/number")]
    public string Number { get; set; }

    [JsonPropertyName("card/count")]
    public int Count { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [JsonPropertyName("card/parallel-id")]
    public int ParallelID { get; set; }

    public Card()
    {
    }

    public Card(Card card)
    {
      Number = card.Number;
      Count = card.Count;
      ParallelID = card.ParallelID;
    }

    public override bool Equals(object obj)
    {
      return obj is Card card &&
             Number == card.Number &&
             Count == card.Count &&
             ParallelID == card.ParallelID;
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(Number, Count, ParallelID);
    }
  }
}
