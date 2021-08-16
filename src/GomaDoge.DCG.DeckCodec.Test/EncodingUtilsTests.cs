using System;
using System.Collections;
using System.Text;
using GomaDoge.DCG.DeckCodec.Utils;
using NUnit.Framework;

namespace GomaDoge.DCG.DeckCodec.Test
{
  [TestFixture]
  public class EncodingUtilTests
  {
    public class Base64Encoded_NoPadding : IEnumerable
    {
      public IEnumerator GetEnumerator()
      {
        yield return new object[] { "VGhpcyBpcyBhIFRlc3Qu", "This is a Test." };
        yield return new object[] { "QW5vdGhlciBUZXN0", "Another Test" };
        yield return new object[] { "U3RhcnRlciBEZWNrLCBHYWlhIFJlZCBbU1QtMV0h", "Starter Deck, Gaia Red [ST-1]!" };
      }
    }

    [TestCaseSource(typeof(Base64Encoded_NoPadding))]
    public void DecodeBase64URL_NoPadding(string encoded, string expected)
    {
        Assert.AreEqual(expected, Encoding.UTF8.GetString(EncodingUtils.DecodeBase64URL(encoded)));
    }

    public class Base64Encoded_OnePaddingChar : IEnumerable
    {
      public IEnumerator GetEnumerator()
      {
        yield return new object[] { "VGhpcyBpcyBhIFRlc3Q", "This is a Test" };
        yield return new object[] { "VGhpcyBpcyBhbm90aGVyIFRlc3Q", "This is another Test" };
        yield return new object[] { "U3RhcnRlciBEZWNrLCBHYWlhIFJlZCBbU1QtMV0", "Starter Deck, Gaia Red [ST-1]" };
      }
    }

    [TestCaseSource(typeof(Base64Encoded_OnePaddingChar))]
    public void DecodeBase64URL_OnePaddingChar(string encoded, string expected)
    {
        Assert.AreEqual(expected, Encoding.UTF8.GetString(EncodingUtils.DecodeBase64URL(encoded)));
    }

    public class Base64Encoded_TwoPaddingChar : IEnumerable
    {
      public IEnumerator GetEnumerator()
      {
        yield return new object[] { "VGhpcyBpcyBhIFRlc3QhIQ", "This is a Test!!" };
        yield return new object[] { "QW5vdGhlciBUZXN0IQ", "Another Test!" };
        yield return new object[] { "U3RhcnRlciBEZWNrLCBHYWlhIFJlZCBbU1QtMV0gIQ", "Starter Deck, Gaia Red [ST-1] !" };
      }
    }

    [TestCaseSource(typeof(Base64Encoded_TwoPaddingChar))]
    public void DecodeBase64URL_TwoPaddingChar(string encoded, string expected)
    {
        Assert.AreEqual(expected, Encoding.UTF8.GetString(EncodingUtils.DecodeBase64URL(encoded)));
    }

    [Test]
    public void DecodeBase64URL_ArgumentInvalid([Values(null, "", "   ")] string encoded)
    {
      Assert.Throws<ArgumentException>(() => EncodingUtils.DecodeBase64URL(encoded));
    }

    [Test]
    public void DecodeBase64URL_InvalidBase64URL([Values("!!!", "0123456789@", "VGhpcyBpcyBhIFRlc3QhIQ ")] string encoded)
    {
      Assert.Throws<FormatException>(() => EncodingUtils.DecodeBase64URL(encoded));
    }

    public class Base36Encoded_InRange : IEnumerable
    {
      public IEnumerator GetEnumerator()
      {
        yield return new object[] { 0, '0' };
        yield return new object[] { 1, '1' };
        yield return new object[] { 2, '2' };
        yield return new object[] { 3, '3' };
        yield return new object[] { 4, '4' };
        yield return new object[] { 5, '5' };
        yield return new object[] { 6, '6' };
        yield return new object[] { 7, '7' };
        yield return new object[] { 8, '8' };
        yield return new object[] { 9, '9' };
        yield return new object[] { 10, 'A' };
        yield return new object[] { 11, 'B' };
        yield return new object[] { 12, 'C' };
        yield return new object[] { 13, 'D' };
        yield return new object[] { 14, 'E' };
        yield return new object[] { 15, 'F' };
        yield return new object[] { 16, 'G' };
        yield return new object[] { 17, 'H' };
        yield return new object[] { 18, 'I' };
        yield return new object[] { 19, 'J' };
        yield return new object[] { 20, 'K' };
        yield return new object[] { 21, 'L' };
        yield return new object[] { 22, 'M' };
        yield return new object[] { 23, 'N' };
        yield return new object[] { 24, 'O' };
        yield return new object[] { 25, 'P' };
        yield return new object[] { 26, 'Q' };
        yield return new object[] { 27, 'R' };
        yield return new object[] { 28, 'S' };
        yield return new object[] { 29, 'T' };
        yield return new object[] { 30, 'U' };
        yield return new object[] { 31, 'V' };
        yield return new object[] { 32, 'W' };
        yield return new object[] { 33, 'X' };
        yield return new object[] { 34, 'Y' };
        yield return new object[] { 35, 'Z' };
      }
    }

    [TestCaseSource(typeof(Base36Encoded_InRange))]
    public void DecodeBase36_InRange(int encoded, char expected)
    {
        Assert.AreEqual(expected, EncodingUtils.DecodeBase36(encoded));
    }

    [Test]
    public void DecodeBase36_OutOfRange([Values(-1, 36, 128)] int encoded)
    {
        Assert.Throws<ArgumentException>(() => EncodingUtils.DecodeBase36(encoded));
    }
  }
}
