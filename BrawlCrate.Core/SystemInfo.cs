using System;
using BrawlCrate.Core.Wii.Endian;

namespace BrawlCrate.Core
{
    public class SystemInfo
    {
        public static readonly Endianness Endian =
            BitConverter.IsLittleEndian ? Endianness.LittleEndian : Endianness.BigEndian;
    }
}
