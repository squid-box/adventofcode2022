namespace AdventOfCode2022.Problems;

using AdventOfCode2022.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2022/day/25">Day 25</a>.
/// </summary>
public class Problem25 : ProblemBase
{
    public Problem25(InputDownloader inputDownloader) : base(25, inputDownloader) { }

    /// <inheritdoc />
    protected override object SolvePartOne()
    {
        return SolvePartOne(Input);
    }

    /// <inheritdoc />
    protected override object SolvePartTwo()
    {
        return "N/A";
    }

    internal static long SnafuToLong(string snafu)
    {
        var result = 0L;
        var reversed = snafu.Reverse().ToArray();

        for (var i = 0; i < snafu.Length; i++)
        {
            var value = reversed[i] switch
            {
                '=' => -2,
                '-' => -1,
                _ => Convert.ToInt32(reversed[i].ToString()),
            };
            result += (long)(value * Math.Pow(5, i));
        }

        return result;
    }

    internal static string LongToSnafu(long number)
    {
        var result = "";

        while (number > 0)
        {
            var remainder = number % 5;
            number /= 5;

            if (remainder.IsWithin(0,2))
            {
                result = remainder + result;
            }
            else if (remainder == 3)
            {
                result = "=" + result;
                number++;
            }
            else if (remainder == 4)
            {
                result = "-" + result;
                number++;
            }
        }

        return result;
    }

    internal static string SolvePartOne(ICollection<string> input)
    {
        var fuelSum = 0L;

        foreach (var line in input.WithNoEmptyLines())
        {
            fuelSum += SnafuToLong(line);
        }

        Console.WriteLine($"Fuel to heat: {fuelSum}");

        return LongToSnafu(fuelSum);
    }

    internal static long SolvePartTwo(ICollection<string> input)
    {
        return 0;
    }
}