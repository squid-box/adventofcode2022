namespace AdventOfCode2022.Problems;

using System.Collections.Generic;
using System.Linq;
using AdventOfCode2022.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2022/day/6">Day 6</a>.
/// </summary>
public class Problem6 : ProblemBase
{
    public Problem6(InputDownloader inputDownloader) : base(6, inputDownloader) { }

    /// <inheritdoc />
    protected override object SolvePartOne()
    {
        return SolvePartOne(Input.WithNoEmptyLines().First());
    }

    /// <inheritdoc />
    protected override object SolvePartTwo()
    {
        return SolvePartTwo(Input.WithNoEmptyLines().First());
    }

    internal static int SolvePartOne(string input)
    {
        return FindMarkerEndPosition(input, 4);
    }

    internal static int SolvePartTwo(string input)
    {
        return FindMarkerEndPosition(input, 14);
    }

    private static int FindMarkerEndPosition(string message, int numberOfUniqueCharacters)
    {
        for (var i = 0; i < message.Length - numberOfUniqueCharacters; i++)
        {
            if (message.ToCharArray(i, numberOfUniqueCharacters).ToHashSet().Count == numberOfUniqueCharacters)
            {
                return i + numberOfUniqueCharacters;
            }
        }

        return -1;
    }
}