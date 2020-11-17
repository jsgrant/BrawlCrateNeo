namespace BrawlCrate.Core.Wii.Compression
{
    /// <summary>
    /// Currently supported compression types.
    /// </summary>
    /// <remarks>Not all known compression types, solely the ones currently supported by the program.</remarks>
    public enum CompressionType : byte
    {
        /// <summary>
        /// Not actually used for Compression Headers, placeholder used for uncompressed files.
        /// </summary>
        None = 0x0,
        /// <summary>
        /// Most common algorithm.
        /// </summary>
        LZ77 = 0x10,
        /// <summary>
        /// Improved version of <see cref="LZ77"/>.
        /// </summary>
        ExtendedLZ77 = 0x11
    }

    /// <summary>
    /// Known compression algorithms, including ones not currently supported
    /// </summary>
    public enum CompressionAlgorithm : byte
    {
        LZ77 = 0x1,
        Huffman = 0x2,
        RunLength = 0x3,
        LZ77Huffman = 0x4,
        LZ77RangeCoder = 0x5,
        Differential = 0x8
    }
}
