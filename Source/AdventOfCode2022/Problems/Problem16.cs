namespace AdventOfCode2022.Problems;

using System.Collections.Generic;
using System.Text.RegularExpressions;
using AdventOfCode2022.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2022/day/16">Day 16</a>.
/// </summary>
public class Problem16 : ProblemBase
{
    public Problem16(InputDownloader inputDownloader) : base(16, inputDownloader) { }

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

    private static IEnumerable<Valve> ParseInput(IEnumerable<string> input)
    {
        var result = new Dictionary<string, Valve>();
        var connections = new Dictionary<string, IList<string>>();

        var regex = new Regex(@"Valve (?<id>\w+) has flow rate=(?<flowrate>\d+); tunnel(s)* lead(s)* to valve(s)* (?<targets>.*)", RegexOptions.ExplicitCapture);

        foreach (var line in input)
        {
            var match = regex.Match(line);

            result.Add(match.Groups["id"].Value, new Valve(match.Groups["id"].Value, match.Groups["flowrate"].Value.ToInt()));
            connections.Add(match.Groups["id"].Value, match.Groups["targets"].Value.Split(','));
        }

        foreach (var connection in connections)
        {
            foreach (var target in connection.Value)
            {
                result[connection.Key].ConnectedValves.Add(result[target.Trim()]);
            }
        }

        return result.Values;
    }

    internal static long SolvePartOne(ICollection<string> input)
    {
        var valves = ParseInput(input);

        return 0;
    }

    internal static long SolvePartTwo(ICollection<string> input)
    {
        return 0;
    }

    private class Valve
    {
        public Valve(string id, int flowRate)
        {
            Id = id;
            FlowRate = flowRate;

            ConnectedValves = new HashSet<Valve>();
        }

        public string Id { get; }

        public int FlowRate { get; }

        public HashSet<Valve> ConnectedValves { get; }
    }
}