using System;
using System.Runtime.InteropServices;

namespace BrawlCrate.Core.Wii.BigEndian
{
    /// <summary>
    /// Represents a Big Endian 24-bit unsigned integer. See <see cref="UInt24"/>.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BUInt24 : IEquatable<BUInt24>
    {
        private readonly byte _b0; // 0x0
        private readonly byte _b1; // 0x1
        private readonly byte _b2; // 0x2

        /// <summary>
        /// Constructor from an unsigned 32-bit integer.
        /// </summary>
        /// <param name="value">An unsigned 32-bit integer to convert.</param>
        public BUInt24(uint value)
        {
            _b0 = (byte)((value >> 16) & 0xFF);
            _b1 = (byte)((value >> 8) & 0xFF);
            _b2 = (byte)(value & 0xFF);
        }

        /// <summary>
        /// Constructor from three bytes.
        /// </summary>
        /// <param name="b0">Byte 0x0</param>
        /// <param name="b1">Byte 0x1</param>
        /// <param name="b2">Byte 0x2</param>
        public BUInt24(byte b0, byte b1, byte b2)
        {
            _b0 = b0;
            _b1 = b1;
            _b2 = b2;
        }

        /// <summary>
        /// Implicit conversion to <see cref="UInt24"/>.
        /// </summary>
        /// <param name="value">The <see cref="BUInt24"/> to convert to the Little Endian equivalent.</param>
        public static implicit operator UInt24(BUInt24 value)
        {
            return new UInt24(value._b2, value._b1, value._b0);
        }

        public bool Equals(BUInt24 other)
        {
            return _b0 == other._b0 && _b1 == other._b1 && _b2 == other._b2;
        }

        public override bool Equals(object obj)
        {
            return obj is BUInt24 other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_b0, _b1, _b2);
        }
    }
}
