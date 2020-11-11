using System;
using System.Runtime.InteropServices;
using BrawlCrate.Core.Extensions;

namespace BrawlCrate.Core.Wii.Endianness.BigEndian
{
    /// <summary>
    /// Represents an explicitly Big Endian 32-bit unsigned integer. See <see cref="uint"/>.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BUInt32 : IComparable<BUInt32>, IEquatable<BUInt32>, IEndian<uint>
    {
        /// <summary>
        /// Big Endian raw data.
        /// </summary>
        private readonly uint _data;

        /// <summary>
        /// The value as represented in the current system's Endian format.
        /// </summary>
        public uint Value => BitConverter.IsLittleEndian ? _data.Reverse() : _data;

        /// <summary>
        /// Constructor from an unsigned 32-bit integer.
        /// </summary>
        /// <param name="value">An unsigned 32-bit integer to convert.</param>
        public BUInt32(uint value)
        {
            _data = value.BigEndian();
        }

        /// <summary>
        /// Implicit conversion from <see cref="uint"/> to <see cref="BUInt32"/>.
        /// </summary>
        /// <param name="value">The <see cref="uint"/> to convert.</param>
        public static implicit operator BUInt32(uint value)
        {
            return new BUInt32(value);
        }

        /// <summary>
        /// Implicit conversion to <see cref="uint"/>.
        /// </summary>
        /// <param name="value">The <see cref="BUInt32"/> to convert.</param>
        public static implicit operator uint(BUInt32 value)
        {
            return value.Value;
        }

        public int CompareTo(BUInt32 other)
        {
            return Value.CompareTo(other.Value);
        }

        public bool Equals(BUInt32 other)
        {
            return _data == other._data;
        }

        public override bool Equals(object obj)
        {
            return obj is BUInt32 other && Equals(other);
        }

        public override int GetHashCode()
        {
            return (int) _data;
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
