using System;
using System.Runtime.InteropServices;
using BrawlCrate.Core.Wii.BigEndian;

namespace BrawlCrate.Core.Wii
{
    /// <summary>
    /// Represents a 24-bit unsigned integer.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct UInt24 : IEquatable<UInt24>
    {
        private readonly byte _b0; // 0x0
        private readonly byte _b1; // 0x1
        private readonly byte _b2; // 0x2

        /// <summary>
        /// The value as represented in a more standard 32-bit unsigned integer format.
        /// </summary>
        private uint Value => _b0 | ((uint) _b1 << 8) | ((uint) _b2 << 16);

        /// <summary>
        /// Constructor from an unsigned 32-bit integer.
        /// </summary>
        /// <param name="value">An unsigned 32-bit integer to convert.</param>
        public UInt24(uint value)
        {
            _b0 = (byte)(value & 0xFF);
            _b1 = (byte)((value >> 8) & 0xFF);
            _b2 = (byte)((value >> 16) & 0xFF);
        }

        /// <summary>
        /// Constructor from three bytes.
        /// </summary>
        /// <param name="b0">Byte 0x0</param>
        /// <param name="b1">Byte 0x1</param>
        /// <param name="b2">Byte 0x2</param>
        public UInt24(byte b0, byte b1, byte b2)
        {
            _b0 = b0;
            _b1 = b1;
            _b2 = b2;
        }

        /// <summary>
        /// Implicit conversion to <see cref="BUInt24"/>.
        /// </summary>
        /// <param name="value">The <see cref="UInt24"/> to convert to the Little Endian equivalent.</param>
        public static implicit operator BUInt24(UInt24 value)
        {
            return new BUInt24(value._b2, value._b1, value._b0);
        }

        /// <summary>
        /// Implicit conversion to <see cref="uint"/>.
        /// </summary>
        /// <param name="value">The <see cref="UInt24"/> to convert to the 32-bit equivalent.</param>
        public static implicit operator uint(UInt24 value)
        {
            return value.Value;
        }

        /// <summary>
        /// Implicit conversion from <see cref="uint"/>.
        /// </summary>
        /// <param name="value">The <see cref="UInt24"/> to convert to the 32-bit equivalent.</param>
        public static implicit operator UInt24(uint value)
        {
            return new UInt24(value);
        }

        public bool Equals(UInt24 other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            return obj is UInt24 other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_b0, _b1, _b2);
        }
    }
}
