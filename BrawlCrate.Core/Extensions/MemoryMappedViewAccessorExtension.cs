using System;
using System.IO.MemoryMappedFiles;
using BrawlCrate.Core.Wii;
using BrawlCrate.Core.Wii.Types.Common;

namespace BrawlCrate.Core.Extensions
{
    /// <summary>
    /// Extensions to <see cref="MemoryMappedViewAccessor"/>.
    /// </summary>
    public static class MemoryMappedViewAccessorExtension
    {
        /// <summary>
        /// Attempts to read a structure of type T from the accessor into a provided reference.
        /// </summary>
        /// <typeparam name="T">The type of structure.</typeparam>
        /// <param name="mem">The specified MemoryMappedViewAccessor.</param>
        /// <param name="position">The position in the accessor at which to begin reading.</param>
        /// <param name="structure">The structure to contain the read data.</param>
        /// <returns>True if the structure is successfully read, false if an error is thrown.</returns>
        public static bool TryRead<T>(this MemoryMappedViewAccessor mem, long position, out T structure) where T : struct
        {
            try
            {
                mem.Read(position, out structure);
                return true;
            }
            catch
            {
                structure = default;
                if (structure is IDisposable d)
                {
                    // Dispose of the to-be-unused structure for memory purposes
                    d.Dispose();
                }
                return false;
            }
        }

        /// <summary>
        /// Reads a structure of type T from the accessor and returns it.
        /// </summary>
        /// <typeparam name="T">The type of structure.</typeparam>
        /// <param name="mem">The specified MemoryMappedViewAccessor.</param>
        /// <param name="position">The position in the accessor at which to begin reading.</param>
        /// <returns>The structure containing the read data.</returns>
        public static T Read<T>(this MemoryMappedViewAccessor mem, long position) where T : struct
        {
            mem.Read(position, out T temp);
            return temp;
        }

        #region Base Types

        #region Int16

        /// <summary>
        /// Reads a 16-bit integer of a specific Endianness from the accessor and converts it to the current system Endianness.
        /// </summary>
        /// <param name="mem">The specified MemoryMappedViewAccessor.</param>
        /// <param name="position">The number of bytes into the accessor at which to begin reading.</param>
        /// <param name="convertFrom">The Endianness to convert from.</param>
        /// <returns>The value that was read as converted to the current system Endianness.</returns>
        public static short ReadInt16(this MemoryMappedViewAccessor mem, long position, Endianness convertFrom)
        {
            return mem.ReadInt16(position).ConvertToSystemEndian(convertFrom);
        }

        /// <summary>
        /// Writes a 16-bit integer converted to a specific Endianness to the accessor.
        /// </summary>
        /// <param name="mem">The specified MemoryMappedViewAccessor.</param>
        /// <param name="position">The number of bytes into the accessor at which to begin writing.</param>
        /// <param name="value">The value to write.</param>
        /// <param name="convertTo">The Endianness to convert to.</param>
        public static void Write(this MemoryMappedViewAccessor mem, long position, short value, Endianness convertTo)
        {
            mem.Write(position, value.ConvertFromSystemEndian(convertTo));
        }

        #endregion

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

        #region Int64

        /// <summary>
        /// Reads a 64-bit integer of a specific Endianness from the accessor and converts it to the current system Endianness.
        /// </summary>
        /// <param name="mem">The specified MemoryMappedViewAccessor.</param>
        /// <param name="position">The number of bytes into the accessor at which to begin reading.</param>
        /// <param name="convertFrom">The Endianness to convert from.</param>
        /// <returns>The value that was read as converted to the current system Endianness.</returns>
        public static long ReadInt64(this MemoryMappedViewAccessor mem, long position, Endianness convertFrom)
        {
            return mem.ReadInt64(position).ConvertToSystemEndian(convertFrom);
        }

        /// <summary>
        /// Writes a 64-bit integer converted to a specific Endianness to the accessor.
        /// </summary>
        /// <param name="mem">The specified MemoryMappedViewAccessor.</param>
        /// <param name="position">The number of bytes into the accessor at which to begin writing.</param>
        /// <param name="value">The value to write.</param>
        /// <param name="convertTo">The Endianness to convert to.</param>
        public static void Write(this MemoryMappedViewAccessor mem, long position, long value, Endianness convertTo)
        {
            mem.Write(position, value.ConvertFromSystemEndian(convertTo));
        }

        #endregion

        #region UInt16

        /// <summary>
        /// Reads an unsigned 16-bit integer of a specific Endianness from the accessor and converts it to the current system Endianness.
        /// </summary>
        /// <param name="mem">The specified MemoryMappedViewAccessor.</param>
        /// <param name="position">The number of bytes into the accessor at which to begin reading.</param>
        /// <param name="convertFrom">The Endianness to convert from.</param>
        /// <returns>The value that was read as converted to the current system Endianness.</returns>
        public static ushort ReadUInt16(this MemoryMappedViewAccessor mem, long position, Endianness convertFrom)
        {
            return mem.ReadUInt16(position).ConvertToSystemEndian(convertFrom);
        }

        /// <summary>
        /// Writes an unsigned 16-bit integer converted to a specific Endianness to the accessor.
        /// </summary>
        /// <param name="mem">The specified MemoryMappedViewAccessor.</param>
        /// <param name="position">The number of bytes into the accessor at which to begin writing.</param>
        /// <param name="value">The value to write.</param>
        /// <param name="convertTo">The Endianness to convert to.</param>
        public static void Write(this MemoryMappedViewAccessor mem, long position, ushort value, Endianness convertTo)
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

        #region UInt64

        /// <summary>
        /// Reads an unsigned 64-bit integer of a specific Endianness from the accessor and converts it to the current system Endianness.
        /// </summary>
        /// <param name="mem">The specified MemoryMappedViewAccessor.</param>
        /// <param name="position">The number of bytes into the accessor at which to begin reading.</param>
        /// <param name="convertFrom">The Endianness to convert from.</param>
        /// <returns>The value that was read as converted to the current system Endianness.</returns>
        public static ulong ReadUInt64(this MemoryMappedViewAccessor mem, long position, Endianness convertFrom)
        {
            return mem.ReadUInt64(position).ConvertToSystemEndian(convertFrom);
        }

        /// <summary>
        /// Writes an unsigned 64-bit integer converted to a specific Endianness to the accessor.
        /// </summary>
        /// <param name="mem">The specified MemoryMappedViewAccessor.</param>
        /// <param name="position">The number of bytes into the accessor at which to begin writing.</param>
        /// <param name="value">The value to write.</param>
        /// <param name="convertTo">The Endianness to convert to.</param>
        public static void Write(this MemoryMappedViewAccessor mem, long position, ulong value, Endianness convertTo)
        {
            mem.Write(position, value.ConvertFromSystemEndian(convertTo));
        }

        #endregion

        #endregion

        #region Custom Types

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
        public static uint ReadUInt24(this MemoryMappedViewAccessor mem, long position, Endianness convertFrom)
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

        #endregion
    }
}
