namespace AdventOfCode2022.Problems;

using System.Collections.Generic;
using System.Linq;
using AdventOfCode2022.Utils.Extensions;

using AdventOfCode2022.Utils;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2022/day/18">Day 18</a>.
/// </summary>
public class Problem18 : ProblemBase
{
    public Problem18(InputDownloader inputDownloader) : base(18, inputDownloader) { }

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

    private static HashSet<Coordinate> ParseInput(IEnumerable<string> input)
    {
        var result = new HashSet<Coordinate>();

        foreach (var line in input)
        {
            var split = line.Split(',').AsInt();
            result.Add(new Coordinate(split[0], split[1], split[2]));
        }

        return result;
    }

    internal static long SolvePartOne(ICollection<string> input)
    {
        var scan = ParseInput(input);

        return scan.Sum(cube => cube.GetCubeNeighbors().Count(neighbors => !scan.Contains(neighbors)));
    }

    internal static long SolvePartTwo(ICollection<string> input)
    {
        var scan = ParseInput(input);

        // Define bounding box
        var maxX = scan.Max(cube => cube.X) + 1;
        var maxY = scan.Max(cube => cube.Y) + 1;
        var maxZ = scan.Max(cube => cube.Z) + 1;
        var minX = scan.Min(cube => cube.X) - 1;
        var minY = scan.Min(cube => cube.Y) - 1;
        var minZ = scan.Min(cube => cube.Z) - 1;

        var all = new HashSet<Coordinate>();
        for (var x = minX; x < maxX; x++)
        {
            for (var y = minY; y < maxY; y++)
            {
                for (var z = minZ; z < maxZ; z++)
                {
                    all.Add(new Coordinate(x, y, z));
                }
            }
        }

        // Figure out which cubes are "external" air.
        var queue = new Queue<Coordinate>();
        queue.Enqueue(new Coordinate(minX, minY, minZ));
        var visited = new HashSet<Coordinate>();

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (visited.Contains(current) || scan.Contains(current) || !all.Contains(current))
            {
                continue;
            }

            visited.Add(current);
            queue.EnqueueRange(current.GetCubeNeighbors());
        }

        // Remove internal air pockets
        var notInScan = all.Where(cube => !visited.Contains(cube));
        scan.AddRange(notInScan);

        // Calculate exposed sides
        return scan.Sum(cube => cube.GetCubeNeighbors().Count(neighbors => !scan.Contains(neighbors)));
    }
}