namespace AdventOfCode2022.Utils.Extensions;

using System.Collections.Generic;

/// <summary>
/// Extensions for the HashSet class.
/// </summary>
public static class HashSetExtensions
{
    /// <summary>
    /// Adds a number of items to the HashSet.
    /// </summary>
    /// <typeparam name="T">Type of items in this HashSet.</typeparam>
    /// <param name="set">The HashSet to operate on.</param>
    /// <param name="range">The collection of items to push onto this HashSet.</param>
    public static void AddRange<T>(this HashSet<T> set, IEnumerable<T> range)
    {
        foreach (var item in range)
        {
            set.Add(item);
        }
    }
}