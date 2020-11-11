using System;

namespace BrawlCrate.Core.Extensions
{
    /// <summary>
    /// Extensions to <see cref="uint"/>.
    /// </summary>
    public static class UInt32Extension
    {
        /// <summary>
        /// Reverses the Endianness of the integer.
        /// </summary>
        /// <param name="i">The specified uint.</param>
        /// <returns>An endian-swapped uint.</returns>
        public static uint Reverse(this uint i)
        {
            return ((i >> 24) & 0xFF) | (i << 24) | ((i >> 8) & 0xFF00) | ((i & 0xFF00) << 8);
        }

        /// <summary>
        /// Gets a forced Little Endian variation of the unsigned integer, regardless of current system Endian.
        /// </summary>
        /// <param name="i">The specified uint.</param>
        /// <returns>A Little Endian formatted variation of the given unsigned integer.</returns>
        public static uint LittleEndian(this uint i)
        {
            return BitConverter.IsLittleEndian ? i : i.Reverse();
        }

        /// <summary>
        /// Gets a forced Big Endian variation of a given unsigned integer, regardless of current system Endian.
        /// </summary>
        /// <param name="i">The specified uint.</param>
        /// <returns>A Big Endian formatted variation of the given unsigned integer.</returns>
        public static uint BigEndian(this uint i)
        {
            return BitConverter.IsLittleEndian ? i.Reverse() : i;
        }
    }
}
