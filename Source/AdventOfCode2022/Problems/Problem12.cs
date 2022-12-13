namespace AdventOfCode2022.Problems;

using System.Collections.Generic;
using System.Linq;
using AdventOfCode2022.Utils;
using AdventOfCode2022.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2022/day/12">Day 12</a>.
/// </summary>
public class Problem12 : ProblemBase
{
    public Problem12(InputDownloader inputDownloader) : base(12, inputDownloader) { }

    /// <inheritdoc />
    protected override object SolvePartOne()
    {
        return SolvePartOne(Input.WithNoEmptyLines());
    }

    /// <inheritdoc />
    protected override object SolvePartTwo()
    {
        return SolvePartTwo(Input);
    }

    internal static int SolvePartOne(ICollection<string> input)
    {
        var map = new HeightMap(input);

        return Bfs(map).Count;
    }

    internal static int SolvePartTwo(ICollection<string> input)
    {
        var map = new HeightMap(input);

        var aPoints = map.GetAllPointsWith('a');

        var pathLengths = new List<int>();

        foreach (var start in aPoints)
        {
            map.Start = start;
            var path = Bfs(map);

            if (path != null)
            {
                pathLengths.Add(path.Count);
            }
        }

        return pathLengths.Min();
    }

    private static List<Coordinate> Bfs(HeightMap map)
    {
        var previous = new Dictionary<Coordinate, Coordinate>();

        var queue = new Queue<Coordinate>();
        queue.Enqueue(map.Start);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            foreach (var neighbor in current.GetNeighbors(includeDiagonals: false))
            {
                if (previous.ContainsKey(neighbor) ||
                    !map.Map.ContainsKey(neighbor) ||
                    map.Map[neighbor] - map.Map[current] > 1)
                {
                    continue;
                }

                previous[neighbor] = current;
                queue.Enqueue(neighbor);
            }
        }

        var path = new List<Coordinate>();

        var c = map.End;

        if (!previous.ContainsKey(map.End))
        {
            return null;
        }

        while (!c.Equals(map.Start))
        {
            path.Add(c);
            c = previous[c];
        }

        return path;
    }

    private class HeightMap
    {
        public HeightMap(IEnumerable<string> input)
        {
            Map = new Dictionary<Coordinate, int>();

            var y = 0;

            foreach (var line in input)
            {
                for (var x = 0; x < line.Length; x++)
                {
                    var current = line[x];
                    var coordinate = new Coordinate(x, y);

                    switch (current)
                    {
                        case 'S':
                            Start = coordinate;
                            Map.Add(coordinate, 'a'.ToInt());
                            break;
                        case 'E':
                            End = coordinate;

                            Map.Add(coordinate, 'z'.ToInt());
                            break;
                        default:
                            Map.Add(coordinate, current.ToInt());
                            break;
                    }
                }

                y++;
            }
        }

        public List<Coordinate> GetAllPointsWith(char elevation)
        {
            var target = elevation.ToInt();

            return (from kvp in Map where kvp.Value.Equals(target) select kvp.Key).ToList();
        }

        public Dictionary<Coordinate, int> Map { get; }

        public Coordinate Start { get; set; }

        public Coordinate End { get; }
    }
}