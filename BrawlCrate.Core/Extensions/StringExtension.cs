using System;
using System.Text;

namespace BrawlCrate.Core.Extensions
{
    /// <summary>
    /// Extensions to <see cref="string"/>.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Returns a value indicating whether a specified <see cref="T:System.String"/> occurs within this string. A parameter specifies the type of search to use for the specified string.
        /// </summary>
        /// <param name="s">The specified string.</param>
        /// <param name="value">The string to seek.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
        /// <returns>True if the <paramref name="value">value</paramref> parameter occurs within this string; otherwise, false.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="value">value</paramref> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="comparisonType">comparisonType</paramref> is not a <see cref="T:System.StringComparison"></see> value.</exception>
        public static bool Contains(this string s, string value, StringComparison comparisonType)
        {
            return s.IndexOf(value, comparisonType) >= 0;
        }

        /// <summary>
        /// Returns a value indicating whether a specified <see cref="T:System.Char"/> occurs within this string.
        /// </summary>
        /// <param name="s">The specified string.</param>
        /// <param name="value">The char to seek.</param>
        /// <returns>True if the <paramref name="value">value</paramref> parameter occurs within this string; otherwise, false.</returns>
        public static bool Contains(this string s, char value)
        {
            return s.IndexOf(value) >= 0;
        }

        /// <summary>
        /// Returns a value indicating whether a specified <see cref="T:System.Char"/> occurs within this string. A parameter specifies the type of search to use for the specified char.
        /// </summary>
        /// <param name="s">The specified string.</param>
        /// <param name="value">The char to seek.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies how the string and char will be compared.</param>
        /// <returns>True if the <paramref name="value">value</paramref> parameter occurs within this string; otherwise, false.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="value">value</paramref> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="comparisonType">comparisonType</paramref> is not a <see cref="T:System.StringComparison"></see> value.</exception>
        public static bool Contains(this string s, char value, StringComparison comparisonType)
        {
            return s.IndexOf(value.ToString(), comparisonType) >= 0;
        }

        /// <summary>
        /// Returns the byte length of this string when encoded in UTF-8 format.
        /// </summary>
        /// <param name="s">The specified string.</param>
        /// <returns>The number of bytes produced by encoding the specified string.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="s">s</paramref> is null.</exception>
        /// <exception cref="T:System.Text.EncoderFallbackException">A fallback occurred (see Character Encoding in the .NET Framework for complete explanation)   -and-  <see cref="P:System.Text.Encoding.EncoderFallback"></see> is set to <see cref="T:System.Text.EncoderExceptionFallback"></see>.</exception>
        public static int UTF8Length(this string s)
        {
            return Encoding.UTF8.GetByteCount(s);
        }
    }
}
