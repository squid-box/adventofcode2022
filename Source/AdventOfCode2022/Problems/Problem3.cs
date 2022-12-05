namespace AdventOfCode2022.Problems;

using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2022/day/3">Day 3</a>.
/// </summary>
public class Problem3 : ProblemBase
{
    public Problem3(InputDownloader inputDownloader) : base(3, inputDownloader) { }

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

    internal static IList<(IList<char> first, IList<char> second)> ParseInput(IEnumerable<string> input)
    {
        var result = new List<(IList<char>, IList<char>)>();

        foreach (var line in input)
        {
            result.Add((line.Take(line.Length / 2).ToList(), line.Skip(line.Length / 2).ToList()));
        }

        return result;
    }

    internal static int SolvePartOne(ICollection<string> input)
    {
        var parsed = ParseInput(input);

        return parsed.Sum(pair => FindScore(FindCommonChar(pair.first, pair.second)));
    }

    internal static int SolvePartTwo(ICollection<string> input)
    {
        var score = 0;

        var inputList = input.ToList();

        for (var i = 0; i < input.Count; i += 3)
        {
            score += FindScore(FindCommonChar(inputList[i].ToCharArray(), inputList[i + 1].ToCharArray(), inputList[i + 2].ToCharArray()));
        }

        return score;
    }

    internal static char FindCommonChar(IList<char> first, IList<char> second, IList<char> third = null)
    {
        foreach (var letter in first)
        {
            if (!second.Contains(letter))
            {
                continue;
            }

            if (third == null || third.Contains(letter))
            {
                return letter;
            }
        }

        return '\0';
    }

    internal static int FindScore(char item)
    {
        if (char.IsLower(item))
        {
            return item - 96;
        }
        else
        {
            return item - 38;
        }
    }
}