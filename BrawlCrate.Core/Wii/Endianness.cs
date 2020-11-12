namespace BrawlCrate.Core.Wii
{
    /// <summary>
    /// Specifies Endianness. Values are taken from BRRES BOM.
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
