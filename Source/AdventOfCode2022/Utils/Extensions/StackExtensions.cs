namespace AdventOfCode2022.Utils.Extensions;

using System.Collections.Generic;

/// <summary>
/// Extensions for the Stack class.
/// </summary>
public static class StackExtensions
{
    /// <summary>
    /// Pops a number of items and returns them.
    /// </summary>
    /// <typeparam name="T">Type of items in this Stack.</typeparam>
    /// <param name="stack">The Stack to operate on.</param>
    /// <param name="count">Number of items to pop.</param>
    /// <returns>The items popped from the Stack.</returns>
    public static IEnumerable<T> PopRange<T>(this Stack<T> stack, int count)
    {
        var result = new List<T>();

        for (var i = 0; i < count; i++)
        {
            result.Add(stack.Pop());
        }

        return result;
    }

    /// <summary>
    /// Pushes a number of items onto the top of the Stack.
    /// </summary>
    /// <typeparam name="T">Type of items in this Stack.</typeparam>
    /// <param name="stack">The Stack to operate on.</param>
    /// <param name="range">The collection of items to push onto this Stack.</param>
    public static void PushRange<T>(this Stack<T> stack, IEnumerable<T> range)
    {
        foreach (var item in range)
        {
            stack.Push(item);
        }
    }
}