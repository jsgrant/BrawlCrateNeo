using BrawlCrate.Core.Wii;

namespace BrawlCrate.Core.Extensions
{
    /// <summary>
    /// Extensions to <see cref="short"/>.
    /// </summary>
    public static class Int16Extension
    {
        /// <summary>
        /// Reverses the Endianness of an 16-bit integer.
        /// </summary>
        /// <param name="i">The specified short.</param>
        /// <returns>An Endian-swapped 16-bit integer.</returns>
        public static short Reverse(this short i)
        {
            return (short)(((i >> 8) & 0xFF) | (i << 8));
        }

        /// <summary>
        /// Converts a 16-bit integer from the current system Endianness to a given Endianness.
        /// </summary>
        /// <param name="i">The specified short.</param>
        /// <param name="convertTo">The Endianness to convert to.</param>
        /// <returns>An Endian-converted 16-bit integer.</returns>
        public static short ConvertFromSystemEndian(this short i, Endianness convertTo)
        {
            return i.EndianConversion(SystemInfo.Endian, convertTo);
        }

        /// <summary>
        /// Converts a 16-bit integer from a given Endianness to the current system Endianness.
        /// </summary>
        /// <param name="i">The specified short.</param>
        /// <param name="convertFrom">The Endianness to convert from.</param>
        /// <returns>An Endian-converted 16-bit integer.</returns>
        public static short ConvertToSystemEndian(this short i, Endianness convertFrom)
        {
            return i.EndianConversion(convertFrom, SystemInfo.Endian);
        }

        /// <summary>
        /// Converts a 16-bit integer from a given Endianness to another given Endianness.
        /// </summary>
        /// <param name="i">The specified short.</param>
        /// <param name="convertFrom">The Endianness to convert from.</param>
        /// <param name="convertTo">The Endianness to convert to.</param>
        /// <returns>An Endian-converted 16-bit integer.</returns>
        /// <remarks>Should most often be called by <see cref="ConvertFromSystemEndian"/> and <see cref="ConvertToSystemEndian"/>. Not much reason to call otherwise.</remarks>
        public static short EndianConversion(this short i, Endianness convertFrom, Endianness convertTo)
        {
            return (convertFrom == convertTo) switch
            {
                true => i, // If Endianness is the same, return the same value.
                false => i.Reverse() // If Endianness is different, return the reversed value.
            };
        }
    }
}
