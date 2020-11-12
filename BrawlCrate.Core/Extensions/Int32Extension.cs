using BrawlCrate.Core.Wii;

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
        /// Converts an integer from the current system Endianness to a given Endianness.
        /// </summary>
        /// <param name="i">The specified int.</param>
        /// <param name="convertTo">The Endianness to convert to.</param>
        /// <returns>An Endian-converted integer.</returns>
        public static int ConvertFromSystemEndian(this int i, Endianness convertTo)
        {
            return i.EndianConversion(SystemInfo.Endian, convertTo);
        }

        /// <summary>
        /// Converts an integer from a given Endianness to the current system Endianness.
        /// </summary>
        /// <param name="i">The specified int.</param>
        /// <param name="convertFrom">The Endianness to convert from.</param>
        /// <returns>An Endian-converted integer.</returns>
        public static int ConvertToSystemEndian(this int i, Endianness convertFrom)
        {
            return i.EndianConversion(convertFrom, SystemInfo.Endian);
        }

        /// <summary>
        /// Converts an integer from a given Endianness to another given Endianness.
        /// </summary>
        /// <param name="i">The specified int.</param>
        /// <param name="convertFrom">The Endianness to convert from.</param>
        /// <param name="convertTo">The Endianness to convert to.</param>
        /// <returns>An Endian-converted integer.</returns>
        /// <remarks>Should most often be called by <see cref="ConvertFromSystemEndian"/> and <see cref="ConvertToSystemEndian"/>. Not much reason to call otherwise.</remarks>
        public static int EndianConversion(this int i, Endianness convertFrom, Endianness convertTo)
        {
            return (convertFrom == convertTo) switch
            {
                true => i, // If Endianness is the same, return the same value.
                false => i.Reverse() // If Endianness is different, return the reversed value.
            };
        }
    }
}
