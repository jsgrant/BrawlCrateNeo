using System.Runtime.InteropServices;
using BrawlCrate.Core.Wii.Types.Common;

namespace BrawlCrate.Core.Wii.Types.Containers
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BRESHeader
    {
        public static string Tag => "bres";

        public FileMagic _tag;      // 0x00: "bres"
        public ByteOrderMark _bom;  // 0x04: Determines Endian state for this file.
        public ushort _padding;     // 0x06: Seemingly always 0x0000. BRES doesn't have multiple versions.
        public uint _length;        // 0x08: Length of the file
        public ushort _offset;      // 0x0C: Offset to root section
        public ushort _sections;    // 0x0E: Number of sections (root included)
    }
}
