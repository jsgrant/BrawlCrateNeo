using System.IO.MemoryMappedFiles;
using BrawlCrate.Core.Wii;
using BrawlCrate.Core.Wii.Types.Common;

namespace BrawlCrate.Core.Extensions
{
    public static class MemoryMappedViewAccessorExtension
    {
        #region Int32

        /// <summary>
        /// Reads a 32-bit integer of a specific Endianness from the accessor and converts it to the current system Endianness.
        /// </summary>
        /// <param name="mem">The specified MemoryMappedViewAccessor.</param>
        /// <param name="position">The number of bytes into the accessor at which to begin reading.</param>
        /// <param name="convertFrom">The Endianness to convert from.</param>
        /// <returns>The value that was read as converted to the current system Endianness.</returns>
        public static int ReadInt32(this MemoryMappedViewAccessor mem, long position, Endianness convertFrom)
        {
            return mem.ReadInt32(position).ConvertToSystemEndian(convertFrom);
        }

        /// <summary>
        /// Writes a 32-bit integer converted to a specific Endianness to the accessor.
        /// </summary>
        /// <param name="mem">The specified MemoryMappedViewAccessor.</param>
        /// <param name="position">The number of bytes into the accessor at which to begin writing.</param>
        /// <param name="value">The value to write.</param>
        /// <param name="convertTo">The Endianness to convert to.</param>
        public static void Write(this MemoryMappedViewAccessor mem, long position, int value, Endianness convertTo)
        {
            mem.Write(position, value.ConvertFromSystemEndian(convertTo));
        }

        #endregion

        #region UInt24

        /// <summary>
        /// Reads an unsigned 24-bit integer from the accessor.
        /// </summary>
        /// <param name="mem">The specified MemoryMappedViewAccessor.</param>
        /// <param name="position">The number of bytes into the accessor at which to begin reading.</param>
        /// <returns>The value that was read as converted to the current system Endianness.</returns>
        public static UInt24 ReadUInt24(this MemoryMappedViewAccessor mem, long position)
        {
            return new UInt24(mem.ReadByte(position), mem.ReadByte(position + 1), mem.ReadByte(position + 2));
        }

        /// <summary>
        /// Reads an unsigned 24-bit integer of a specific Endianness from the accessor and converts it to the current system Endianness.
        /// </summary>
        /// <param name="mem">The specified MemoryMappedViewAccessor.</param>
        /// <param name="position">The number of bytes into the accessor at which to begin reading.</param>
        /// <param name="convertFrom">The Endianness to convert from.</param>
        /// <returns>The value that was read as converted to the current system Endianness.</returns>
        public static UInt24 ReadUInt24(this MemoryMappedViewAccessor mem, long position, Endianness convertFrom)
        {
            return mem.ReadUInt24(position).ConvertToSystemEndian(convertFrom);
        }

        /// <summary>
        /// Writes an unsigned 24-bit integer to the accessor.
        /// </summary>
        /// <param name="mem">The specified MemoryMappedViewAccessor.</param>
        /// <param name="position">The number of bytes into the accessor at which to begin writing.</param>
        /// <param name="value">The value to write.</param>
        public static void Write(this MemoryMappedViewAccessor mem, long position, UInt24 value)
        {
            byte[] bytes = value;
            mem.Write(position, bytes[0]);
            mem.Write(position + 1, bytes[1]);
            mem.Write(position + 2, bytes[2]);
        }

        /// <summary>
        /// Writes an unsigned 24-bit integer converted to a specific Endianness to the accessor.
        /// </summary>
        /// <param name="mem">The specified MemoryMappedViewAccessor.</param>
        /// <param name="position">The number of bytes into the accessor at which to begin writing.</param>
        /// <param name="value">The value to write.</param>
        /// <param name="convertTo">The Endianness to convert to.</param>
        public static void Write(this MemoryMappedViewAccessor mem, long position, UInt24 value, Endianness convertTo)
        {
            mem.Write(position, value.ConvertFromSystemEndian(convertTo));
        }

        #endregion

        #region UInt32

        /// <summary>
        /// Reads an unsigned 32-bit integer of a specific Endianness from the accessor and converts it to the current system Endianness.
        /// </summary>
        /// <param name="mem">The specified MemoryMappedViewAccessor.</param>
        /// <param name="position">The number of bytes into the accessor at which to begin reading.</param>
        /// <param name="convertFrom">The Endianness to convert from.</param>
        /// <returns>The value that was read as converted to the current system Endianness.</returns>
        public static uint ReadUInt32(this MemoryMappedViewAccessor mem, long position, Endianness convertFrom)
        {
            return mem.ReadUInt32(position).ConvertToSystemEndian(convertFrom);
        }

        /// <summary>
        /// Writes an unsigned 32-bit integer converted to a specific Endianness to the accessor.
        /// </summary>
        /// <param name="mem">The specified MemoryMappedViewAccessor.</param>
        /// <param name="position">The number of bytes into the accessor at which to begin writing.</param>
        /// <param name="value">The value to write.</param>
        /// <param name="convertTo">The Endianness to convert to.</param>
        public static void Write(this MemoryMappedViewAccessor mem, long position, uint value, Endianness convertTo)
        {
            mem.Write(position, value.ConvertFromSystemEndian(convertTo));
        }

        #endregion
    }
}
