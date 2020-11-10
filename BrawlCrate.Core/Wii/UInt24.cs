using System.Runtime.InteropServices;
using BrawlCrate.Core.Wii.BigEndian;

namespace BrawlCrate.Core.Wii
{
    /// <summary>
    /// Represents a 24-bit unsigned integer.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct UInt24
    {
        private byte _b0; // 0x0
        private byte _b1; // 0x1
        private byte _b2; // 0x2

        /// <summary>
        /// The value as represented in a more standard 32-bit unsigned integer format.
        /// </summary>
        public uint Value
        {
            get => _b0 | ((uint) _b1 << 8) | ((uint) _b2 << 16);
            set
            {
                _b0 = (byte)(value & 0xFF);
                _b1 = (byte)((value >> 8) & 0xFF);
                _b2 = (byte)((value >> 16) & 0xFF);
            }
        }

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
    }
}
