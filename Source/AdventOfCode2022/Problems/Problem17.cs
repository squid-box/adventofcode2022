namespace AdventOfCode2022.Problems;

using System.Collections.Generic;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2022/day/17">Day 17</a>.
/// </summary>
public class Problem17 : ProblemBase
{
    public Problem17(InputDownloader inputDownloader) : base(17, inputDownloader) { }

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
        return 0;
    }

    internal static long SolvePartTwo(ICollection<string> input)
    {
        return 0;
    }

    private class Chamber
    {
        public Chamber()
        {
            Width = 7;
            TopHeight = 0;
        }

        public int Width { get; }

        public int TopHeight { get; }
    }

    private class Rock
    {

    }
}