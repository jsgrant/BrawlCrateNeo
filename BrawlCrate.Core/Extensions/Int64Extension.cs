using BrawlCrate.Core.Wii;

namespace BrawlCrate.Core.Extensions
{
    /// <summary>
    /// Extensions to <see cref="long"/>.
    /// </summary>
    public static class Int64Extension
    {
        /// <summary>
        /// Reverses the Endianness of a 64-bit integer.
        /// </summary>
        /// <param name="i">The specified long.</param>
        /// <returns>An Endian-swapped 64-bit integer.</returns>
        public static long Reverse(this long i)
        {
            return
                ((i >> 56) & 0xFF) | ((i & 0xFF) << 56) |
                ((i >> 40) & 0xFF00) | ((i & 0xFF00) << 40) |
                ((i >> 24) & 0xFF0000) | ((i & 0xFF0000) << 24) |
                ((i >> 8) & 0xFF000000) | ((i & 0xFF000000) << 8);
        }

        /// <summary>
        /// Converts a 64-bit integer from the current system Endianness to a given Endianness.
        /// </summary>
        /// <param name="i">The specified long.</param>
        /// <param name="convertTo">The Endianness to convert to.</param>
        /// <returns>An Endian-converted 64-bit integer.</returns>
        public static long ConvertFromSystemEndian(this long i, Endianness convertTo)
        {
            return i.EndianConversion(SystemInfo.Endian, convertTo);
        }

        /// <summary>
        /// Converts a 64-bit integer from a given Endianness to the current system Endianness.
        /// </summary>
        /// <param name="i">The specified long.</param>
        /// <param name="convertFrom">The Endianness to convert from.</param>
        /// <returns>An Endian-converted 64-bit integer.</returns>
        public static long ConvertToSystemEndian(this long i, Endianness convertFrom)
        {
            return i.EndianConversion(convertFrom, SystemInfo.Endian);
        }

        /// <summary>
        /// Converts a 64-bit integer from a given Endianness to another given Endianness.
        /// </summary>
        /// <param name="i">The specified long.</param>
        /// <param name="convertFrom">The Endianness to convert from.</param>
        /// <param name="convertTo">The Endianness to convert to.</param>
        /// <returns>An Endian-converted 64-bit integer.</returns>
        /// <remarks>Should most often be called by <see cref="ConvertFromSystemEndian"/> and <see cref="ConvertToSystemEndian"/>. Not much reason to call otherwise.</remarks>
        public static long EndianConversion(this long i, Endianness convertFrom, Endianness convertTo)
        {
            return (convertFrom == convertTo) switch
            {
                true => i, // If Endianness is the same, return the same value.
                false => i.Reverse() // If Endianness is different, return the reversed value.
            };
        }
    }
}
