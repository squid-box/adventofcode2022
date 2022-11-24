namespace AdventOfCode2022.Utils.Extensions;

using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Extensions for the collections.
/// </summary>
public static class CollectionExtensions
{
    /// <summary>
    /// Converts the input from a collection of strings to a collection of <see cref="int"/>.
    /// </summary>
    /// <param name="input">Input to convert.</param>
    /// <returns>An array of integers.</returns>
    public static IList<int> AsInt(this ICollection<string> input)
    {
        return input.Select(int.Parse).ToList();
    }

    /// <summary>
    /// Converts the input from a collection of strings to a collection of <see cref="long"/>.
    /// </summary>
    /// <param name="input">Input to convert.</param>
    /// <returns>An array of <see cref="long"/>.</returns>
    public static IList<long> AsLong(this ICollection<string> input)
    {
        return input.Select(long.Parse).ToList();
    }

    /// <summary>
    /// Removes any empty lines from a collection of strings.
    /// </summary>
    /// <param name="input">Input to clean.</param>
    /// <returns>The collection of strings, with any empty lines removed.</returns>
    public static IList<string> WithNoEmptyLines(this ICollection<string> input)
    {
        return input.Where(line => !string.IsNullOrEmpty(line)).ToList();
    }
}