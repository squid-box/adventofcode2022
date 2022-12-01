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

    /// <summary>
    /// Returns a collection of grouped strings from the original collection, split by blank lines.
    /// </summary>
    /// <param name="input">Input to split.</param>
    /// <returns>A list of grouped strings from the original collection.</returns>
    public static IList<IList<string>> SplitByBlankLines(this ICollection<string> input)
    {
        var result = new List<IList<string>>();

        var currentList = new List<string>();

        foreach (var line in input)
        {
            if (string.IsNullOrEmpty(line))
            {
                if (currentList.Count != 0)
                {
                    result.Add(currentList);
                }

                currentList = new List<string>();
                continue;
            }

            currentList.Add(line);
        }

        result.Add(currentList);

        return result;
    }
}