using System.IO;
using System.Runtime.InteropServices;

namespace BrawlCrate.Core.Wii.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct ByteOrderMark
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
    }
}
