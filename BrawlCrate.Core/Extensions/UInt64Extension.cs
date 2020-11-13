using BrawlCrate.Core.Wii;

namespace BrawlCrate.Core.Extensions
{
    /// <summary>
    /// Extensions to <see cref="ulong"/>.
    /// </summary>
    public static class UInt64Extension
    {
        /// <summary>
        /// Reverses the Endianness of an unsigned 64-bit integer.
        /// </summary>
        /// <param name="i">The specified ulong.</param>
        /// <returns>An Endian-swapped unsigned 64-bit integer.</returns>
        public static ulong Reverse(this ulong i)
        {
            return
                ((i >> 56) & 0xFF) | ((i & 0xFF) << 56) |
                ((i >> 40) & 0xFF00) | ((i & 0xFF00) << 40) |
                ((i >> 24) & 0xFF0000) | ((i & 0xFF0000) << 24) |
                ((i >> 8) & 0xFF000000) | ((i & 0xFF000000) << 8);
        }

        /// <summary>
        /// Converts an unsigned 64-bit integer from the current system Endianness to a given Endianness.
        /// </summary>
        /// <param name="i">The specified ulong.</param>
        /// <param name="convertTo">The Endianness to convert to.</param>
        /// <returns>An Endian-converted unsigned 64-bit integer.</returns>
        public static ulong ConvertFromSystemEndian(this ulong i, Endianness convertTo)
        {
            return i.EndianConversion(SystemInfo.Endian, convertTo);
        }

        /// <summary>
        /// Converts an unsigned 64-bit integer from a given Endianness to the current system Endianness.
        /// </summary>
        /// <param name="i">The specified ulong.</param>
        /// <param name="convertFrom">The Endianness to convert from.</param>
        /// <returns>An Endian-converted unsigned 64-bit integer.</returns>
        public static ulong ConvertToSystemEndian(this ulong i, Endianness convertFrom)
        {
            return i.EndianConversion(convertFrom, SystemInfo.Endian);
        }

        /// <summary>
        /// Converts an unsigned 64-bit integer from a given Endianness to another given Endianness.
        /// </summary>
        /// <param name="i">The specified ulong.</param>
        /// <param name="convertFrom">The Endianness to convert from.</param>
        /// <param name="convertTo">The Endianness to convert to.</param>
        /// <returns>An Endian-converted unsigned 64-bit integer.</returns>
        /// <remarks>Should most often be called by <see cref="ConvertFromSystemEndian"/> and <see cref="ConvertToSystemEndian"/>. Not much reason to call otherwise.</remarks>
        public static ulong EndianConversion(this ulong i, Endianness convertFrom, Endianness convertTo)
        {
            return (convertFrom == convertTo) switch
            {
                true => i, // If Endianness is the same, return the same value.
                false => i.Reverse() // If Endianness is different, return the reversed value.
            };
        }
    }
}
