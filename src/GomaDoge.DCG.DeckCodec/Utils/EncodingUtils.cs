using System;

namespace GomaDoge.DCG.DeckCodec.Utils
{
  public static class EncodingUtils
  {
    public static byte[] DecodeBase64URL(string encoded)
    {
      if (string.IsNullOrWhiteSpace(encoded))
      {
        throw new ArgumentException("Argument must not be null or empty.", nameof(encoded));
      }

      // Replace characters to match Base64 alphabet.
      encoded = encoded.Replace('_', '/').Replace('-', '+');

      // Add padding if needed as it is not present in Base64URL encoding.
      switch (encoded.Length % 4)
      {
        case 2: encoded += "=="; break;
        case 3: encoded += "="; break;
      }

      return Convert.FromBase64String(encoded);
    }

    public static char DecodeBase36(int encoded)
    {
      return encoded switch
      {
        >= 0 and < 10 => (char)('0' + encoded),
        >= 0 and < 36 => (char)('A' + encoded - 10),
        _ => throw new ArgumentException("Parameter out of range for base36."),
      };
    }
  }
}
