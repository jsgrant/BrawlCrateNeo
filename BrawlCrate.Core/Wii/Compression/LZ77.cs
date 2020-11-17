using System.IO.MemoryMappedFiles;

namespace BrawlCrate.Core.Wii.Compression
{
    /// <summary>
    /// Implementation of the LZ77 compression algorithm used by Brawl.
    /// </summary>
    public static class LZ77
    {
        /// <summary>
        /// Uncompresses a valid LZ77 file.
        /// </summary>
        /// <param name="header">The compression header of the original file.</param>
        /// <param name="original">The original file accessor.</param>
        /// <param name="uncompressed">The uncompressed file accessor to write to.</param>
        public static void Expand(CompressionHeader header, MemoryMappedViewAccessor original, MemoryMappedViewAccessor uncompressed)
        {
            var extended = header.Compression == CompressionType.ExtendedLZ77;
            var originalLen = original.Capacity;
            var uncompLen = uncompressed.Capacity;
            long origPos = header.HeaderSize;
            long uncompPos = 0;
            while (uncompPos < uncompLen)
            {
                byte bit = 8;
                var control = original.ReadByte(origPos);
                origPos++;
                while (bit-- != 0 && uncompPos < uncompLen)
                {
                    if ((control & (1 << bit)) == 0)
                    {
                        uncompressed.Write(uncompPos, original.ReadByte(origPos));
                        uncompPos++;
                        origPos++;
                    }
                    else
                    {
                        var temp = original.ReadByte(origPos) >> 4;
                        var num = !extended
                            ? temp + 3
                            : temp == 1
                                ? (((original.ReadByte(origPos) & 0x0F) << 12) | (original.ReadByte(++origPos) << 4) |
                                   (original.ReadByte(++origPos) >> 4)) + 0xFF + 0xF + 3
                                : temp == 0
                                    ? (((original.ReadByte(origPos) & 0x0F) << 4) |
                                       (original.ReadByte(++origPos) >> 4)) + 0xF + 2
                                    : temp + 1;
                        var offset = (((original.ReadByte(origPos) & 0xF) << 8) | original.ReadByte(++origPos)) + 2;
                        origPos++;
                        while (uncompPos != uncompLen && num-- > 0)
                        {
                            uncompressed.Write(uncompPos, uncompressed.ReadByte(uncompPos - offset));
                            uncompPos++;
                        }
                    }
                } 
            }
        }
    }
}
