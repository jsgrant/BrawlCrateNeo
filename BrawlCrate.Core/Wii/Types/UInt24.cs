﻿using System;
using System.Runtime.InteropServices;

namespace BrawlCrate.Core.Wii.Types
{
    /// <summary>
    /// Represents a 24-bit unsigned integer.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct UInt24 : IEquatable<UInt24>, IComparable<UInt24>
    {
        private readonly byte _b0; // 0x0
        private readonly byte _b1; // 0x1
        private readonly byte _b2; // 0x2

        private uint Value => _b0 | ((uint)_b1 << 8) | ((uint)_b2 << 16);

        /// <summary>
        /// Constructor from an unsigned 32-bit integer.
        /// </summary>
        /// <param name="value">An unsigned 32-bit integer to convert.</param>
        public UInt24(uint value)
        {
            _b0 = (byte)((value >> 16) & 0xFF);
            _b1 = (byte)((value >> 8) & 0xFF);
            _b2 = (byte)(value & 0xFF);
        }

        /// <summary>
        /// Constructor from three given bytes
        /// </summary>
        /// <param name="b0">Byte 0x0.</param>
        /// <param name="b1">Byte 0x1.</param>
        /// <param name="b2">Byte 0x2.</param>
        public UInt24(byte b0, byte b1, byte b2)
        {
            _b0 = b0;
            _b1 = b1;
            _b2 = b2;
        }

        /// <summary>
        /// Converts from the current system Endianness to a given Endianness.
        /// </summary>
        /// <param name="convertTo">The Endianness to convert to.</param>
        /// <returns>An Endian-converted 24-bit unsigned integer.</returns>
        public UInt24 ConvertFromSystemEndian(Endianness convertTo)
        {
            return EndianConversion(SystemInfo.Endian, convertTo);
        }

        /// <summary>
        /// Converts from a given Endianness to the current system Endianness.
        /// </summary>
        /// <param name="convertFrom">The Endianness to convert from.</param>
        /// <returns>An Endian-converted 24-bit unsigned integer.</returns>
        public UInt24 ConvertToSystemEndian(Endianness convertFrom)
        {
            return EndianConversion(convertFrom, SystemInfo.Endian);
        }

        /// <summary>
        /// Converts from a given Endianness to another given Endianness.
        /// </summary>
        /// <param name="convertFrom">The Endianness to convert from.</param>
        /// <param name="convertTo">The Endianness to convert to.</param>
        /// <returns>An Endian-converted 24-bit integer.</returns>
        /// <remarks>Should most often be called by <see cref="ConvertFromSystemEndian"/> and <see cref="ConvertToSystemEndian"/>. Not much reason to call otherwise.</remarks>
        public UInt24 EndianConversion(Endianness convertFrom, Endianness convertTo)
        {
            return (convertFrom == convertTo) switch
            {
                true => this, // If Endianness is the same, return the same value.
                false => new UInt24(_b2, _b1, _b0) // If Endianness is different, return the reversed value.
            };
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
        /// <param name="value">The <see cref="uint"/> to convert to the 24-bit equivalent.</param>
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

        public int CompareTo(UInt24 other)
        {
            return Value.CompareTo(other.Value);
        }

        public static bool operator ==(UInt24 a, UInt24 b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(UInt24 a, UInt24 b)
        {
            return !(a == b);
        }

        public static bool operator <(UInt24 left, UInt24 right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(UInt24 left, UInt24 right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(UInt24 left, UInt24 right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(UInt24 left, UInt24 right)
        {
            return left.CompareTo(right) >= 0;
        }
    }
}
