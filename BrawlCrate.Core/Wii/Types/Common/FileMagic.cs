﻿using System;
using System.Runtime.InteropServices;

namespace BrawlCrate.Core.Wii.Types.Common
{
    /// <summary>
    /// A four-character unique string representing a filetype.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct FileMagic : IEquatable<FileMagic>
    {
        private readonly byte _c0; // 0x0
        private readonly byte _c1; // 0x1
        private readonly byte _c2; // 0x2
        private readonly byte _c3; // 0x3

        /// <summary>
        /// Constructor from a string.
        /// </summary>
        /// <param name="tag">The string representing the <see cref="FileMagic"/>.</param>
        public FileMagic(string tag) : this(tag.ToCharArray())
        {
            // Call the char array constructor to reduce code duplication
        }

        /// <summary>
        /// Constructor from an array of characters.
        /// </summary>
        /// <param name="tag">The char array representing the <see cref="FileMagic"/>.</param>
        public FileMagic(char[] tag)
        {
            _c0 = (byte)(tag.Length > 0 ? tag[0] : '\0');
            _c1 = (byte)(tag.Length > 1 ? tag[1] : '\0');
            _c2 = (byte)(tag.Length > 2 ? tag[2] : '\0');
            _c3 = (byte)(tag.Length > 3 ? tag[3] : '\0');
        }

        /// <summary>
        /// The 4-byte tag as represented by a string.
        /// </summary>
        public string Tag => new string(new []{(char)_c0, (char)_c1, (char)_c2, (char)_c3});

        /// <summary>
        /// Implicit conversion to <see cref="string"/>.
        /// </summary>
        /// <param name="m">The <see cref="FileMagic"/> to convert.</param>
        public static implicit operator string(FileMagic m)
        {
            return m.ToString();
        }

        /// <summary>
        /// Implicit conversion from <see cref="string"/>.
        /// </summary>
        /// <param name="s">The <see cref="string"/> to convert.</param>
        public static implicit operator FileMagic(string s)
        {
            return new FileMagic(s);
        }

        /// <summary>
        /// Returns the FileMagic as represented by a string.
        /// </summary>
        /// <returns>The string representation of the FileMagic.</returns>
        public override string ToString()
        {
            return Tag.Trim();
        }

        public bool Equals(FileMagic other)
        {
            return _c0 == other._c0 && _c1 == other._c1 && _c2 == other._c2 && _c3 == other._c3;
        }

        public override bool Equals(object? obj)
        {
            return obj is FileMagic other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_c0, _c1, _c2, _c3);
        }

        public static bool operator ==(FileMagic left, FileMagic right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(FileMagic left, FileMagic right)
        {
            return !left.Equals(right);
        }
    }
}
