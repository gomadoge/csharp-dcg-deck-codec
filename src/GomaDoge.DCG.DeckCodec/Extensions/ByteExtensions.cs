using System;

namespace GomaDoge.DCG.DeckCodec.Extensions
{
  public static class ByteExtensions
  {
    /// <summary>
    /// Returns true if the bit at the given index is set, false otherwise.
    /// Bits are numbered starting with the most significant bit at index 0 (MSB 0).
    /// </summary>
    /// <param name="value">The byte to check.</param>
    /// <param name="index">The index to check.</param>
    /// <returns>True if the bit is set at index, false otherwise.</returns>
    /// <exception cref="IndexOutOfRangeException">Thrown when index is not between 0 and 8.</exception>
    public static bool IsBitSet(this byte value, int index) =>
        (index < 0 || index > 7)
          ? throw new IndexOutOfRangeException("Index must be between 0 and 8.")
          : (value & (0b_1000_0000 >> index)) != 0;
  }
}
