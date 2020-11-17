using System;
using System.Runtime.InteropServices;
using BrawlCrate.Core.Extensions;
using BrawlCrate.Core.Wii.Types.Common;

namespace BrawlCrate.Core.Wii.Compression
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CompressionHeader : IEquatable<CompressionHeader>
    {
        /// <summary>
        /// Compression Algorithm used, see <see cref="CompressionType"/>.
        /// </summary>
        /// <remarks>Upper 4 bits represent the algorithm itself while the lower 4 appear to be flags.</remarks>
        private readonly byte _type;

        /// <summary>
        /// Expanded size as an unsigned 24-bit integer.
        /// </summary>
        /// <remarks>If size is larger than <see cref="UInt24.MaxValue"/>, uses <see cref="_extraSize"/> instead and leaves this field as 0.</remarks>
        private readonly UInt24 _size;

        /// <summary>
        /// Larger size value as an unsigned 32-bit integer.
        /// </summary>
        /// <remarks>Not present unless size is larger than <see cref="UInt24.MaxValue"/>.</remarks>
        private readonly uint _extraSize;

        /// <summary>
        /// The exact compression type used by a node, including known parameter flags.
        /// </summary>
        public CompressionType Compression => (CompressionType)_type;

        /// <summary>
        /// The compression algorithm used by a node.
        /// </summary>
        /// <remarks>Mostly only notable when scaling, since <see cref="Compression"/> should be the primary factor for determining compression.</remarks>
        public CompressionAlgorithm Algorithm => (CompressionAlgorithm) _type.Upper4();

        /// <summary>
        /// Set of four parameter flags used to determine compression. Should generally not be used directly in favor of using <see cref="Compression"/>.
        /// </summary>
        public byte Parameters => _type.Lower4();

        /// <summary>
        /// Checks if this is a proper compression header for a defined <see cref="CompressionType"/>.
        /// </summary>
        public bool IsActualHeader => Enum.IsDefined(typeof(CompressionType), Compression) &&
                                      Compression != CompressionType.None;

        /// <summary>
        /// The uncompressed size of the node.
        /// </summary>
        public uint Size => _size == 0
            ? _extraSize.ConvertToSystemEndian(Endianness.Little)
            : (uint) _size.ConvertToSystemEndian(Endianness.Little);

        /// <summary>
        /// The size of this header.
        /// </summary>
        public uint HeaderSize => (uint)(_size == 0 ? 8 : 4);

        public bool Equals(CompressionHeader other)
        {
            return _type == other._type && Size.Equals(other.Size);
        }

        public override bool Equals(object? obj)
        {
            return obj is CompressionHeader other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_type, Size);
        }

        public static bool operator ==(CompressionHeader left, CompressionHeader right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CompressionHeader left, CompressionHeader right)
        {
            return !left.Equals(right);
        }
    }
}
