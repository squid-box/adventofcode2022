namespace AdventOfCode2022.Problems;

using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2022.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2022/day/4">Day 4</a>.
/// </summary>
public class Problem4 : ProblemBase
{
    public Problem4(InputDownloader inputDownloader) : base(4, inputDownloader) { }

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

    internal static int SolvePartOne(ICollection<string> input)
    {
        var numberOfFullOverlaps = 0;

        foreach (var line in input.WithNoEmptyLines())
        {
            var sections = line.Split(',');
            var firstRangeStart = Convert.ToInt32(sections[0].Split('-')[0]);
            var firstRangeEnd = Convert.ToInt32(sections[0].Split('-')[1]);

            var secondRangeStart = Convert.ToInt32(sections[1].Split('-')[0]);
            var secondRangeEnd = Convert.ToInt32(sections[1].Split('-')[1]);

            var first = Enumerable.Range(firstRangeStart, firstRangeEnd - firstRangeStart + 1);
            var second = Enumerable.Range(secondRangeStart, secondRangeEnd - secondRangeStart + 1);

            if (first.Intersect(second).Count() == second.Count() ||
                second.Intersect(first).Count() == first.Count())
            {
                numberOfFullOverlaps++;
            }
        }

        return numberOfFullOverlaps;
    }

    internal static int SolvePartTwo(ICollection<string> input)
    {
        var numberOfFullOverlaps = 0;

        foreach (var line in input.WithNoEmptyLines())
        {
            var sections = line.Split(',');
            var firstRangeStart = Convert.ToInt32(sections[0].Split('-')[0]);
            var firstRangeEnd = Convert.ToInt32(sections[0].Split('-')[1]);

            var secondRangeStart = Convert.ToInt32(sections[1].Split('-')[0]);
            var secondRangeEnd = Convert.ToInt32(sections[1].Split('-')[1]);

            var first = Enumerable.Range(firstRangeStart, firstRangeEnd - firstRangeStart + 1);
            var second = Enumerable.Range(secondRangeStart, secondRangeEnd - secondRangeStart + 1);

            if (first.Intersect(second).Any())
            {
                numberOfFullOverlaps++;
            }
        }

        return numberOfFullOverlaps;
    }
}