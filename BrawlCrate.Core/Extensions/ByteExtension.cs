using System;

namespace BrawlCrate.Core.Extensions
{
    /// <summary>
    /// Extensions to <see cref="byte"/>.
    /// </summary>
    public static class ByteExtension
    {
        /// <summary>
        /// Gets the state of a specified bit as a bool.
        /// </summary>
        /// <param name="b">The specified byte.</param>
        /// <param name="index">Index of the flag to check, starting at 0 for the rightmost bit.</param>
        /// <returns>True if the specified flag is set, false if the specified flag is not set.</returns>
        /// <exception cref="ArgumentException"><paramref name="index">index</paramref> does not fall in the range of 0-7.</exception>
        /// <remarks>Bits are numbered from 0 - 7, right to left.</remarks>
        public static bool GetBit(this byte b, byte index)
        {
            if (index > 7)
            {
                throw new ArgumentException($"{index} is not a valid bit accessor. Values must be between 0-7.");
            }

            return (b & (1 << index)) != 0;
        }

        /// <summary>
        /// Sets a specified bit.
        /// </summary>
        /// <param name="b">The specified byte.</param>
        /// <param name="index">Index of the flag to check, starting at 0 for the rightmost bit.</param>
        /// <param name="value">The state to set the bit to.</param>
        /// <returns>An edited byte with the given bit set to the expected value.</returns>
        /// <exception cref="ArgumentException"><paramref name="index">index</paramref> does not fall in the range of 0-7.</exception>
        /// <remarks>Bits are numbered from 0 - 7, right to left.</remarks>
        public static byte SetBit(this byte b, byte index, bool value)
        {
            if (index > 7)
            {
                throw new ArgumentException($"{index} is not a valid bit accessor. Values must be between 0-7.");
            }

            return (byte)(value ? b | (1 << index) : b & ~(1 << index));
        }

        /// <summary>
        /// Gets the value of the upper nibble of a specified byte (Bits 7-4).
        /// </summary>
        /// <param name="b">The specified byte.</param>
        /// <returns>A byte value representing the value of the upper 4 bits.</returns>
        public static byte Upper4(this byte b)
        {
            return (byte)((b >> 4) & 0x0F);
        }

        /// <summary>
        /// Gets the value of the lower nibble of a specified byte (Bits 7-4).
        /// </summary>
        /// <param name="b">The specified byte.</param>
        /// <returns>A byte value representing the value of the lower 4 bits.</returns>
        public static byte Lower4(this byte b)
        {
            return (byte) (b & 0x0F);
        }
    }
}
