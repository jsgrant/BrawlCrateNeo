using System;
using System.IO;
using System.Runtime.InteropServices;

namespace BrawlCrate.Core.Wii.Types.Common
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct ByteOrderMark : IEquatable<ByteOrderMark>
    {
        private readonly byte _b1;
        private readonly byte _b2;

        public Endianness Endian
        {
            get
            {
                if (_b1 == 0xFE && _b2 == 0xFF)
                {
                    return Endianness.Big;
                }

                if (_b1 == 0xFF && _b2 == 0xFE)
                {
                    return Endianness.Little;
                }

                throw new InvalidDataException($"Invalid Byte Order Mark 0x{_b1:X2}{_b2:X2}. Valid values are 0xFEFF and 0xFFFE.");
            }
        }

        public ByteOrderMark(Endianness e)
        {
            _b1 = (byte)(e == Endianness.Big ? 0xFE : 0xFF);
            _b2 = (byte)(e == Endianness.Big ? 0xFF : 0xFE);
        }

        public bool Equals(ByteOrderMark other)
        {
            return _b1 == other._b1 && _b2 == other._b2;
        }

        public override bool Equals(object obj)
        {
            return obj is ByteOrderMark other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_b1, _b2);
        }

        public static bool operator ==(ByteOrderMark left, ByteOrderMark right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ByteOrderMark left, ByteOrderMark right)
        {
            return !left.Equals(right);
        }
    }
}
