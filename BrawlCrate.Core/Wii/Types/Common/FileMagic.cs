using System;
using System.Runtime.InteropServices;

namespace BrawlCrate.Core.Wii.Types.Common
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct FileMagic : IEquatable<FileMagic>
    {
        private readonly char _c0;
        private readonly char _c1;
        private readonly char _c2;
        private readonly char _c3;

        public FileMagic(string tag)
        {
            _c0 = tag.Length > 0 ? tag[0] : '\0';
            _c1 = tag.Length > 1 ? tag[1] : '\0';
            _c2 = tag.Length > 2 ? tag[2] : '\0';
            _c3 = tag.Length > 3 ? tag[3] : '\0';
        }
        
        /// <summary>
        /// The 4-byte tag as represented by a string.
        /// </summary>
        public string Tag => new string(new []{_c0, _c1, _c2, _c3});

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

        public override string ToString()
        {
            return Tag;
        }

        public bool Equals(FileMagic other)
        {
            return _c0 == other._c0 && _c1 == other._c1 && _c2 == other._c2 && _c3 == other._c3;
        }

        public override bool Equals(object obj)
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
