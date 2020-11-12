using System;
using BrawlCrate.Core.Wii;

namespace BrawlCrate.Core
{
    public static class SystemInfo
    {
        public static readonly Endianness Endian =
            BitConverter.IsLittleEndian ? Endianness.Little : Endianness.Big;
    }
}
