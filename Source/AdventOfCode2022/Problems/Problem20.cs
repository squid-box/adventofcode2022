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
        var originalFile = input.AsLong().Select(val => new Number(val)).ToList();
        var file = originalFile.Select(x => x).ToList();

        ReOrderFile(originalFile, file);

        return FindCoordinates(file).Sum();
    }

    internal static long SolvePartTwo(ICollection<string> input)
    {
        var originalFile = input.AsLong().Select(val => new Number(val * 811589153L)).ToList();
        var file = originalFile.Select(x => x).ToList();

        for (var i = 0; i < 10; i++)
        {
            ReOrderFile(originalFile, file);
        }

        return FindCoordinates(file).Sum();
    }

    private static void ReOrderFile(IEnumerable<Number> originalFile, IList<Number> file)
    {
        // Go through each original number and move it.
        foreach (var number in originalFile)
        {
            var oldIndex = file.IndexOf(number);
            var newIndex = (int)((oldIndex + number.Value) % (file.Count - 1));

            if (newIndex <= 0)
            {
                newIndex = file.Count - 1 + newIndex;
            }

            file.RemoveAt(oldIndex);
            file.Insert(newIndex, number);
        }
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

        /// <inheritdoc />
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}