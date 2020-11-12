namespace BrawlCrate.Core.Wii.Endian
{
    /// <summary>
    /// Specifies Endianness. Values are taken from BRRES Endian implementation
    /// </summary>
    public enum Endianness : ushort
    {
        /// <summary>
        /// Big Endian
        /// </summary>
        Big = 0xFEFF,
        /// <summary>
        /// Little Endian
        /// </summary>
        Little = 0xFFFE
    }
}
