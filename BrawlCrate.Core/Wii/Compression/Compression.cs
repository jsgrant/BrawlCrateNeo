using System;
using System.IO.MemoryMappedFiles;

namespace BrawlCrate.Core.Wii.Compression
{
    public static class Compression
    {
        public static void Decompress(CompressionHeader header, MemoryMappedViewAccessor original,
            MemoryMappedViewAccessor uncompressed)
        {
            switch (header.Compression)
            {
                case CompressionType.LZ77:
                case CompressionType.ExtendedLZ77:
                    LZ77.Expand(header, original, uncompressed);
                    break;
                default:
                    throw new ArgumentException($"{header.Compression} is not properly supported.");
            }
        }
    }
}
