using System;
using BrawlCrate.Core.Wii;

namespace BrawlCrate.Core
{
    /// <summary>
    /// Read-only information pertaining to the current system that the program is running on.
    /// </summary>
    public static class SystemInfo
    {
        /// <summary>
        /// The Endianness of the current system running the program.
        /// </summary>
        public static readonly Endianness Endian =
            BitConverter.IsLittleEndian ? Endianness.Little : Endianness.Big;
    }
}
