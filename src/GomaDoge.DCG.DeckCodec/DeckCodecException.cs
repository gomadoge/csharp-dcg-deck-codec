using System;

namespace GomaDoge.DCG.DeckCodec
{
  [Serializable]
  public class DeckCodecException : Exception
  {
    public DeckCodecException()
    {
    }

    public DeckCodecException(string message) : base(message)
    {
    }

    public DeckCodecException(string message, Exception inner) : base(message, inner)
    {
    }
  }
}
