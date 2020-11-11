using System;
using System.Runtime.InteropServices;
using BrawlCrate.Core.Extensions;
using BrawlCrate.Core.Wii.Endianness.BigEndian;

namespace BrawlCrate.Core.Wii.Endianness.LittleEndian
{
    /// <summary>
    /// Represents an explicitly Little Endian 24-bit unsigned integer.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LUInt24 : IComparable<LUInt24>, IEquatable<LUInt24>
    {
        private readonly byte _b0; // 0x0
        private readonly byte _b1; // 0x1
        private readonly byte _b2; // 0x2

        /// <summary>
        /// The value as represented in a more standard 32-bit unsigned integer format.
        /// </summary>
        private uint Value
        {
            get
            {
                var val = _b0 | ((uint)_b1 << 8) | ((uint)_b2 << 16);

                // Correct Endianness if in a Big Endian system.
                if (!BitConverter.IsLittleEndian)
                {
                    val = val.Reverse();
                }

                return val;
            }
        }

        /// <summary>
        /// Constructor from an unsigned 32-bit integer.
        /// </summary>
        /// <param name="value">An unsigned 32-bit integer to convert.</param>
        public LUInt24(uint value)
        {
            var littleEndianValue = value.LittleEndian();
            _b0 = (byte)(littleEndianValue & 0xFF);
            _b1 = (byte)((littleEndianValue >> 8) & 0xFF);
            _b2 = (byte)((littleEndianValue >> 16) & 0xFF);
        }

        /// <summary>
        /// Constructor from three bytes.
        /// </summary>
        /// <param name="b0">Byte 0x0</param>
        /// <param name="b1">Byte 0x1</param>
        /// <param name="b2">Byte 0x2</param>
        public LUInt24(byte b0, byte b1, byte b2)
        {
            _b0 = b0;
            _b1 = b1;
            _b2 = b2;
        }

        /// <summary>
        /// Implicit conversion to <see cref="BUInt24"/>.
        /// </summary>
        /// <param name="value">The <see cref="LUInt24"/> to convert to the Little Endian equivalent.</param>
        public static implicit operator BUInt24(LUInt24 value)
        {
            return new BUInt24(value._b2, value._b1, value._b0);
        }

        /// <summary>
        /// Implicit conversion to <see cref="uint"/>.
        /// </summary>
        /// <param name="value">The <see cref="LUInt24"/> to convert to the 32-bit equivalent.</param>
        public static implicit operator uint(LUInt24 value)
        {
            return value.Value;
        }

        /// <summary>
        /// Implicit conversion from <see cref="uint"/>.
        /// </summary>
        /// <param name="value">The <see cref="uint"/> to convert to the 24-bit equivalent.</param>
        public static implicit operator LUInt24(uint value)
        {
            return new LUInt24(value);
        }

        public int CompareTo(LUInt24 other)
        {
            return Value.CompareTo(other.Value);
        }

        public bool Equals(LUInt24 other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            return obj is LUInt24 other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_b0, _b1, _b2);
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>The string representation of the value of this instance, consisting of a sequence of digits ranging from 0 to 9, without a sign or leading zeroes.</returns>
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
