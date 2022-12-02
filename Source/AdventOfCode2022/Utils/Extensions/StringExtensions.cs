namespace AdventOfCode2022.Utils.Extensions;

using System;
using System.Linq;

/// <summary>
/// Extensions for strings.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Converts a string into an int.
    /// </summary>
    /// <param name="source">The string to convert.</param>
    /// <returns>The string as an integer.</returns>
    public static int ToInt(this string source)
    {
        return Convert.ToInt32(source);
    }

    /// <summary>
    /// Converts a string into a long.
    /// </summary>
    /// <param name="source">The string to convert.</param>
    /// <returns>The string as a long.</returns>
    public static long ToLong(this string source)
    {
        return Convert.ToInt64(source);
    }

    /// <summary>
    /// Converts a string from binary to a decimal int.
    /// </summary>
    /// <param name="source">The string to convert.</param>
    /// <returns>The string as a decimal integer.</returns>
    public static int ToIntFromBinary(this string source)
    {
        return Convert.ToInt32(source, 2);
    }

    /// <summary>
    /// Sorts all characters in a string alphabetically.
    /// </summary>
    /// <param name="source">The string to sort.</param>
    /// <returns>A new string, with all <see cref="char"/>'s sorted.</returns>
    public static string SortAlphabetically(this string source)
    {
        return string.Concat(source.OrderBy(c => c));
    }
}