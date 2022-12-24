namespace AdventOfCode2022.Problems;

using System.Collections.Generic;
using System.Linq;
using AdventOfCode2022.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2022/day/20">Day 20</a>.
/// </summary>
public class Problem20 : ProblemBase
{
    public Problem20(InputDownloader inputDownloader) : base(20, inputDownloader) { }

    /// <inheritdoc />
    protected override object SolvePartOne()
    {
        return SolvePartOne(Input);
    }

    /// <inheritdoc />
    protected override object SolvePartTwo()
    {
        return SolvePartTwo(Input);
    }

    internal static long SolvePartOne(ICollection<string> input)
    {
        var file = input.AsLong().Select(val => new Number(val)).ToList();

        file = ReOrderFile(file);

        return FindCoordinates(file).Sum();
    }

    private static List<Number> ReOrderFile(IList<Number> file)
    {
        // Create a copy of the file.
        var result = file.ToList();

        // Go through each original number and move it.
        for (var i = 0; i < result.Count; i++)
        {
            var number = file[i];

            var oldIndex = result.IndexOf(number);
            var newIndex = (int)((oldIndex + number.Value) % (result.Count - 1));

            if (newIndex <= 0)
            {
                newIndex = result.Count - 1 + newIndex;
            }

            result.RemoveAt(oldIndex);
            result.Insert(newIndex, number);
        }

        return result;
    }

    private static IEnumerable<long> FindCoordinates(IList<Number> file)
    {
        var result = new long[3];

        // Find the index of the zero.
        var offset = file.IndexOf(file.First(x => x.Value == 0));

        result[0] = file[(1000 + offset) % file.Count].Value;
        result[1] = file[(2000 + offset) % file.Count].Value;
        result[2] = file[(3000 + offset) % file.Count].Value;

        return result;
    }

    internal static long SolvePartTwo(ICollection<string> input)
    {
        return 0;
    }

    /// <summary>
    /// Long wrapper.
    /// </summary>
    private class Number
    {
        /// <summary>
        /// Creates a new <see cref="Number"/>.
        /// </summary>
        /// <param name="value">The value of this <see cref="Number"/>.</param>
        public Number(long value)
        {
            Value = value;
        }

        /// <summary>
        /// The actual value of this <see cref="Number"/>.
        /// </summary>
        public long Value { get; }
    }
}