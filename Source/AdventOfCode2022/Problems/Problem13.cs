namespace AdventOfCode2022.Problems;

using System.Collections.Generic;
using AdventOfCode2022.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2022/day/13">Day 13</a>.
/// </summary>
public class Problem13 : ProblemBase
{
    public Problem13(InputDownloader inputDownloader) : base(13, inputDownloader) { }

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
        var correctlyOrdered = 0;

        foreach (var signalPair in input.SplitByBlankLines())
        {
            var left = signalPair[0];
            var right = signalPair[1];
        }

        return correctlyOrdered;
    }

    internal static long SolvePartTwo(ICollection<string> input)
    {
        return 0;
    }
}