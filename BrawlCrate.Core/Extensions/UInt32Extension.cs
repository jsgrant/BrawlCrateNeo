using System;
using BrawlCrate.Core.Wii;
using BrawlCrate.Core.Wii.Types.Common;

namespace BrawlCrate.Core.Extensions
{
    /// <summary>
    /// Extensions to <see cref="uint"/>.
    /// </summary>
    public static class UInt32Extension
    {
        /// <summary>
        /// Reverses the Endianness of an unsigned 32-bit integer.
        /// </summary>
        /// <param name="i">The specified uint.</param>
        /// <returns>An Endian-swapped unsigned 32-bit integer.</returns>
        public static uint Reverse(this uint i)
        {
            return ((i >> 24) & 0xFF) | (i << 24) | ((i >> 8) & 0xFF00) | ((i & 0xFF00) << 8);
        }

        /// <summary>
        /// Converts an unsigned 32-bit integer from the current system Endianness to a given Endianness.
        /// </summary>
        /// <param name="i">The specified uint.</param>
        /// <param name="convertTo">The Endianness to convert to.</param>
        /// <returns>An Endian-converted unsigned 32-bit integer.</returns>
        public static uint ConvertFromSystemEndian(this uint i, Endianness convertTo)
        {
            return i.EndianConversion(SystemInfo.Endian, convertTo);
        }

        /// <summary>
        /// Converts an unsigned 32-bit integer from a given Endianness to the current system Endianness.
        /// </summary>
        /// <param name="i">The specified uint.</param>
        /// <param name="convertFrom">The Endianness to convert from.</param>
        /// <returns>An Endian-converted unsigned 32-bit integer.</returns>
        public static uint ConvertToSystemEndian(this uint i, Endianness convertFrom)
        {
            return i.EndianConversion(convertFrom, SystemInfo.Endian);
        }

        /// <summary>
        /// Converts an unsigned 32-bit integer from a given Endianness to another given Endianness.
        /// </summary>
        /// <param name="i">The specified uint.</param>
        /// <param name="convertFrom">The Endianness to convert from.</param>
        /// <param name="convertTo">The Endianness to convert to.</param>
        /// <returns>An Endian-converted unsigned 32-bit integer.</returns>
        /// <remarks>Should most often be called by <see cref="ConvertFromSystemEndian"/> and <see cref="ConvertToSystemEndian"/>. Not much reason to call otherwise.</remarks>
        public static uint EndianConversion(this uint i, Endianness convertFrom, Endianness convertTo)
        {
            return (convertFrom == convertTo) switch
            {
                true => i, // If Endianness is the same, return the same value.
                false => i.Reverse() // If Endianness is different, return the reversed value.
            };
        }

        #region UInt24

        /// <summary>
        /// Converts an unsigned 32-bit integer from the current system Endianness to an unsigned 24-bit integer of a given Endianness.
        /// </summary>
        /// <param name="i">The specified uint.</param>
        /// <param name="convertTo">The Endianness to convert to.</param>
        /// <returns>An Endian-converted unsigned 24-bit integer.</returns>
        public static UInt24 ConvertFromSystemEndian24(this uint i, Endianness convertTo)
        {
            return i.EndianConversion24(SystemInfo.Endian, convertTo);
        }

        /// <summary>
        /// Converts an unsigned 32-bit integer from a given Endianness to an unsigned 24-bit integer of the current system Endianness.
        /// </summary>
        /// <param name="i">The specified uint.</param>
        /// <param name="convertFrom">The Endianness to convert from.</param>
        /// <returns>An Endian-converted unsigned 24-bit integer.</returns>
        public static UInt24 ConvertToSystemEndian24(this uint i, Endianness convertFrom)
        {
            return i.EndianConversion24(convertFrom, SystemInfo.Endian);
        }

        /// <summary>
        /// Converts an unsigned 32-bit integer from a given Endianness to an unsigned 24-bit integer of a given Endianness.
        /// </summary>
        /// <param name="i">The specified uint.</param>
        /// <param name="convertFrom">The Endianness to convert from.</param>
        /// <param name="convertTo">The Endianness to convert to.</param>
        /// <returns>An Endian-converted unsigned 24-bit integer.</returns>
        /// <remarks>Should most often be called by <see cref="ConvertFromSystemEndian24"/> and <see cref="ConvertToSystemEndian24"/>. Not much reason to call otherwise.</remarks>
        public static UInt24 EndianConversion24(this uint i, Endianness convertFrom, Endianness convertTo)
        {
            // Converting from Little Endian
            if (convertFrom == Endianness.Little)
            {
                var littleEndian = new UInt24((byte)(i & 0xFF), (byte)((i >> 8) & 0xFF), (byte)((i >> 16) & 0xFF));
                return (convertTo) switch
                {
                    Endianness.Little => littleEndian,
                    Endianness.Big => littleEndian.Reverse(),
                    _ => throw new ArgumentOutOfRangeException(nameof(convertTo), convertTo, null)
                };
            }

            // TODO: Implement converting from Big Endian
            throw new ArgumentOutOfRangeException(nameof(convertFrom), convertFrom, null);
        }

        #endregion
    }
}
