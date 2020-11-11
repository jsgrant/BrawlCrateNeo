using System;

namespace BrawlCrate.Core.Extensions
{
    /// <summary>
    /// Extensions to <see cref="int"/>.
    /// </summary>
    public static class Int32Extension
    {
        /// <summary>
        /// Reverses the Endianness of the integer.
        /// </summary>
        /// <param name="i">The specified int.</param>
        /// <returns>An endian-swapped int.</returns>
        public static int Reverse(this int i)
        {
            return ((i >> 24) & 0xFF) | (i << 24) | ((i >> 8) & 0xFF00) | ((i & 0xFF00) << 8);
        }

        /// <summary>
        /// Gets a forced Little Endian variation of the integer, regardless of current system Endian.
        /// </summary>
        /// <param name="i">The specified int.</param>
        /// <returns>A Little Endian formatted variation of the given integer.</returns>
        public static int LittleEndian(this int i)
        {
            return BitConverter.IsLittleEndian ? i : i.Reverse();
        }

        /// <summary>
        /// Gets a forced Big Endian variation of a given integer, regardless of current system Endian.
        /// </summary>
        /// <param name="i">The specified int.</param>
        /// <returns>A Big Endian formatted variation of the given integer.</returns>
        public static int BigEndian(this int i)
        {
            return BitConverter.IsLittleEndian ? i.Reverse() : i;
        }
    }
}
