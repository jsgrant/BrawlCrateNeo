using BrawlCrate.Core.Wii.Endian;

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
        /// Converts an unsigned integer from the current system Endianness to a given Endianness.
        /// </summary>
        /// <param name="i">The specified uint.</param>
        /// <param name="convertTo">The Endianness to convert to.</param>
        /// <returns>An Endian-converted unsigned integer.</returns>
        public static uint ConvertFromSystemEndian(this uint i, Endianness convertTo)
        {
            return i.EndianConversion(SystemInfo.Endian, convertTo);
        }

        /// <summary>
        /// Converts an unsigned integer from a given Endianness to the current system Endianness.
        /// </summary>
        /// <param name="i">The specified uint.</param>
        /// <param name="convertFrom">The Endianness to convert from.</param>
        /// <returns>An Endian-converted unsigned integer.</returns>
        public static uint ConvertToSystemEndian(this uint i, Endianness convertFrom)
        {
            return i.EndianConversion(convertFrom, SystemInfo.Endian);
        }

        /// <summary>
        /// Converts an unsigned integer from a given Endianness to another given Endianness.
        /// </summary>
        /// <param name="i">The specified uint.</param>
        /// <param name="convertFrom">The Endianness to convert from.</param>
        /// <param name="convertTo">The Endianness to convert to.</param>
        /// <returns>An Endian-converted unsigned integer.</returns>
        /// <remarks>Should most often be called by <see cref="ConvertFromSystemEndian"/> and <see cref="ConvertToSystemEndian"/>. Not much reason to call otherwise.</remarks>
        public static uint EndianConversion(this uint i, Endianness convertFrom, Endianness convertTo)
        {
            switch (convertFrom == convertTo)
            {
                case true: // If Endianness is the same, return the same value.
                    return i;
                case false: // If Endianness is different, return the reversed value.
                    return i.Reverse();
            }
        }
    }
}
