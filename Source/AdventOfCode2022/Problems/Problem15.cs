namespace AdventOfCode2022.Problems;

using System.Collections.Generic;
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
        return SolvePartOne(Input);
    }

    /// <inheritdoc />
    protected override object SolvePartTwo()
    {
        return SolvePartTwo(Input);
    }

    private static (HashSet<Coordinate> Sensors, HashSet<Coordinate> Beacons) ParseInput(IEnumerable<string> input)
    {
        var regex = new Regex(@"Sensor at x=(?<sensorX>-?\d+), y=(?<sensorY>-?\d+): closest beacon is at x=(?<beaconX>-?\d+), y=(?<beaconY>-?\d+)");

        var sensors = new HashSet<Coordinate>();
        var beacons = new HashSet<Coordinate>();

        foreach (var line in input)
        {
            var match = regex.Match(line);

            sensors.Add(new Coordinate(match.Groups["sensorX"].Value.ToInt(), match.Groups["sensorY"].Value.ToInt()));
            beacons.Add(new Coordinate(match.Groups["beaconX"].Value.ToInt(), match.Groups["beaconY"].Value.ToInt()));
        }

        return (sensors, beacons);
    }

    private static int FindImpossibleLocationsOnLevel(int yLevel, HashSet<Coordinate> sensors, HashSet<Coordinate> beacons)
    {


        return 0;
    }

    internal static long SolvePartOne(ICollection<string> input, int yLevel)
    {
        var (sensors, beacons) = ParseInput(input);

        return FindImpossibleLocationsOnLevel(yLevel, sensors, beacons);
    }

    internal static long SolvePartTwo(ICollection<string> input)
    {
        return 0;
    }
}