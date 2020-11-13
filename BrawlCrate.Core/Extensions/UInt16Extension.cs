using BrawlCrate.Core.Wii;

namespace BrawlCrate.Core.Extensions
{
    /// <summary>
    /// Extensions to <see cref="ushort"/>.
    /// </summary>
    public static class UInt16Extension
    {
        /// <summary>
        /// Reverses the Endianness of an unsigned 16-bit integer.
        /// </summary>
        /// <param name="i">The specified ushort.</param>
        /// <returns>An Endian-swapped unsigned 16-bit integer.</returns>
        public static ushort Reverse(this ushort i)
        {
            return (ushort)((i >> 8) | (i << 8));
        }

        /// <summary>
        /// Converts an unsigned 16-bit integer from the current system Endianness to a given Endianness.
        /// </summary>
        /// <param name="i">The specified ushort.</param>
        /// <param name="convertTo">The Endianness to convert to.</param>
        /// <returns>An Endian-converted 16-bit integer.</returns>
        public static ushort ConvertFromSystemEndian(this ushort i, Endianness convertTo)
        {
            return i.EndianConversion(SystemInfo.Endian, convertTo);
        }

        /// <summary>
        /// Converts an unsigned 16-bit integer from a given Endianness to the current system Endianness.
        /// </summary>
        /// <param name="i">The specified ushort.</param>
        /// <param name="convertFrom">The Endianness to convert from.</param>
        /// <returns>An Endian-converted unsigned 16-bit integer.</returns>
        public static ushort ConvertToSystemEndian(this ushort i, Endianness convertFrom)
        {
            return i.EndianConversion(convertFrom, SystemInfo.Endian);
        }

        /// <summary>
        /// Converts an unsigned 16-bit integer from a given Endianness to another given Endianness.
        /// </summary>
        /// <param name="i">The specified ushort.</param>
        /// <param name="convertFrom">The Endianness to convert from.</param>
        /// <param name="convertTo">The Endianness to convert to.</param>
        /// <returns>An Endian-converted unsigned 16-bit integer.</returns>
        /// <remarks>Should most often be called by <see cref="ConvertFromSystemEndian"/> and <see cref="ConvertToSystemEndian"/>. Not much reason to call otherwise.</remarks>
        public static ushort EndianConversion(this ushort i, Endianness convertFrom, Endianness convertTo)
        {
            return (convertFrom == convertTo) switch
            {
                true => i, // If Endianness is the same, return the same value.
                false => i.Reverse() // If Endianness is different, return the reversed value.
            };
        }
    }
}
