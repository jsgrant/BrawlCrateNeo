using System;

namespace BrawlCrate.Core.Extensions
{
    /// <summary>
    /// Extensions to <see cref="string"/>.
    /// </summary>
    public static class StringExtension
    {
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
        /// Returns a value indicating whether a specified <see cref="T:System.Char"/> occurs within this string. A parameter specifies the type of search to use for the specified string.
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
    }
}
