namespace AdventOfCode2022.Problems;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode2022.Utils;
using AdventOfCode2022.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2022/day/15">Day 15</a>.
/// </summary>
public class Problem15 : ProblemBase
{
    public Problem15(InputDownloader inputDownloader) : base(15, inputDownloader) { }

    /// <inheritdoc />
    protected override object SolvePartOne()
    {
        return SolvePartOne(Input, 2000000);
    }

    /// <inheritdoc />
    protected override object SolvePartTwo()
    {
        return SolvePartTwo(Input);
    }

    private static IEnumerable<Sensor> ParseInput(IEnumerable<string> input)
    {
        var regex = new Regex(@"Sensor at x=(?<sensorX>-?\d+), y=(?<sensorY>-?\d+): closest beacon is at x=(?<beaconX>-?\d+), y=(?<beaconY>-?\d+)");

        var result = new List<Sensor>();

        foreach (var line in input)
        {
            var match = regex.Match(line);

            result.Add(new Sensor(new Coordinate(match.Groups["sensorX"].Value.ToInt(), match.Groups["sensorY"].Value.ToInt()),
                new Coordinate(match.Groups["beaconX"].Value.ToInt(), match.Groups["beaconY"].Value.ToInt())));
        }

        return result;
    }

    private static int FindImpossibleLocationsOnLevel(int yLevel, IEnumerable<Sensor> sensors)
    {
        var impossibleLocations = new HashSet<int>();

        foreach (var sensor in sensors)
        {
            
        }

        return impossibleLocations.Count;
    }

    internal static long SolvePartOne(ICollection<string> input, int yLevel)
    {
        var pairs = ParseInput(input);

        return FindImpossibleLocationsOnLevel(yLevel, pairs);
    }

    internal static long SolvePartTwo(ICollection<string> input)
    {
        return 0;
    }

    private class Sensor
    {
        public Sensor(Coordinate position, Coordinate detectedBeacon)
        {
            Position = position;
            DetectedBeacon = detectedBeacon;

            Range = Coordinate.ManhattanDistance(position, detectedBeacon);
        }

        public int Range { get; }

        public Coordinate Position { get; }

        public Coordinate DetectedBeacon { get; }
    }
}