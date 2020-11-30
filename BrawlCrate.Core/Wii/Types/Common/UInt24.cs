using System;
using System.Runtime.InteropServices;

namespace BrawlCrate.Core.Wii.Types.Common
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

        /// <summary>
        /// Represents the largest possible value of <see cref="UInt24"/>. This field is constant.
        /// </summary>
        public const uint MaxValue = 0xffffff;
        /// <summary>
        /// Represents the smallest possible value of <see cref="UInt24"/>. This field is constant.
        /// </summary>
        public const uint MinValue = 0U;

        /// <summary>
        /// Reverses the Endianness of an unsigned 24-bit integer.
        /// </summary>
        /// <returns>An Endian-swapped unsigned 24-bit integer.</returns>
        public UInt24 Reverse()
        {
            return new UInt24(_b2, _b1, _b0);
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
        /// <returns>An Endian-converted unsigned integer.</returns>
        public uint ConvertFromSystemEndian(Endianness convertTo)
        {
            return EndianConversion(SystemInfo.Endian, convertTo);
        }

        /// <summary>
        /// Converts from a given Endianness to the current system Endianness.
        /// </summary>
        /// <param name="convertFrom">The Endianness to convert from.</param>
        /// <returns>An Endian-converted unsigned integer.</returns>
        public uint ConvertToSystemEndian(Endianness convertFrom)
        {
            return EndianConversion(convertFrom, SystemInfo.Endian);
        }

        /// <summary>
        /// Converts from a given Endianness to another given Endianness.
        /// </summary>
        /// <param name="convertFrom">The Endianness to convert from.</param>
        /// <param name="convertTo">The Endianness to convert to.</param>
        /// <returns>An Endian-converted unsigned integer.</returns>
        /// <remarks>Should most often be called by <see cref="ConvertFromSystemEndian"/> and <see cref="ConvertToSystemEndian"/>. Not much reason to call otherwise.</remarks>
        public uint EndianConversion(Endianness convertFrom, Endianness convertTo)
        {
            // Converting to Little Endian
            if (convertTo == Endianness.Little)
            {
                return (convertFrom) switch
                {
                    Endianness.Little => _b0 | ((uint)_b1 << 8) | ((uint)_b2 << 16),
                    Endianness.Big => _b2 | ((uint)_b1 << 8) | ((uint)_b0 << 16),
                    _ => throw new ArgumentOutOfRangeException(nameof(convertFrom), convertFrom, null)
                };
            }

            // TODO: Implement converting to Big Endian
            throw new ArgumentOutOfRangeException(nameof(convertTo), convertTo, null);
        }

        /// <summary>
        /// Implicit conversion to <see cref="byte"/>[].
        /// </summary>
        /// <param name="value">The <see cref="UInt24"/> to convert to a byte array.</param>
        public static implicit operator byte[](UInt24 value)
        {
            return new[] { value._b0, value._b1, value._b2 };
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>The string representation of the value of this instance in hexadecimal format.</returns>
        public override string ToString()
        {
            return $"0x{_b0:X2}{_b1:X2}{_b2:X2}";
        }

        public bool Equals(UInt24 other)
        {
            return _b0 == other._b0 && _b1 == other._b1 && _b2 == other._b2;
        }

        public override bool Equals(object? obj)
        {
            return obj is UInt24 other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_b0, _b1, _b2);
        }

        public static bool operator ==(UInt24 left, UInt24 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(UInt24 left, UInt24 right)
        {
            return !left.Equals(right);
        }

        public int CompareTo(UInt24 other)
        {
            var b0Comparison = _b0.CompareTo(other._b0);
            if (b0Comparison != 0)
            {
                return b0Comparison;
            }
            var b1Comparison = _b1.CompareTo(other._b1);
            return b1Comparison != 0 ? b1Comparison : _b2.CompareTo(other._b2);
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
