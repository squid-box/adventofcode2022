namespace AdventOfCode2022.Problems;

using System.Collections.Generic;
using System.Linq;
using AdventOfCode2022.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2022/day/2">Day 2</a>.
/// </summary>
public class Problem2 : ProblemBase
{
    public Problem2(InputDownloader inputDownloader) : base(2, inputDownloader) { }

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

    internal static IList<(char Them, char Me)> ParseInput(ICollection<string> input)
    {
        var result = new List<(char Them, char Me)>();

        foreach (var line in input.WithNoEmptyLines())
        {
            result.Add((line[0], line[2]));
        }

        return result;
    }

    internal static int SolvePartOne(ICollection<string> input)
    {
        var parsed = ParseInput(input);

        return parsed
            .Sum(round => CalculateScore(round.Them, round.Me));
    }

    internal static int SolvePartTwo(ICollection<string> input)
    {
        var parsed = ParseInput(input);

        var score = 0;

        foreach (var (them, me) in parsed)
        {
            var myChoice = ResultTable[me] switch
            {
                Outcome.Win => them switch
                {
                    'A' => 'Y',
                    'B' => 'Z',
                    'C' => 'X'
                },
                Outcome.Loss => them switch
                {
                    'A' => 'Z',
                    'B' => 'X',
                    'C' => 'Y'
                },
                Outcome.Draw => them switch
                {
                    'A' => 'X',
                    'B' => 'Y',
                    'C' => 'Z'
                },
                _ => 'A'
            };

            score += CalculateScore(them, myChoice);
        }

        return score;
    }

    private static readonly Dictionary<char, int> ScoreTable = new()
    {
        { 'X', 1 },
        { 'Y', 2 },
        { 'Z', 3 },
    };

    private static readonly Dictionary<char, Outcome> ResultTable = new()
    {
        { 'X', Outcome.Loss },
        { 'Y', Outcome.Draw},
        { 'Z', Outcome.Win },
    };

    private static int CalculateScore(char them, char me)
    {
        var score = ScoreTable[me];

        switch (them)
        {
            case 'A' when me.Equals('X'):
            case 'B' when me.Equals('Y'):
            case 'C' when me.Equals('Z'):
                score += 3;
                break;
            case 'A' when me.Equals('Y'):
            case 'B' when me.Equals('Z'):
            case 'C' when me.Equals('X'):
                score += 6;
                break;
        }

        return score;
    }
}

/// <summary>
/// Possible outcomes from Rock, Paper, Scissors.
/// </summary>
internal enum Outcome
{
    Win,
    Loss,
    Draw
}