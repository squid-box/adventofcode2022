namespace AdventOfCode2022.Problems;

using System.Collections.Generic;
using System.Linq;
using AdventOfCode2022.Utils;
using AdventOfCode2022.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2022/day/8">Day 8</a>.
/// </summary>
public class Problem8 : ProblemBase
{
    public Problem8(InputDownloader inputDownloader) : base(8, inputDownloader) { }

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

    private static Matrix<int> ParseInput(IList<string> input)
    {
        var result = new Matrix<int>(input[0].Length, input.Count);

        for (var y = 0; y < result.Height; y++)
        {
            for (var x = 0; x < result.Width; x++)
            {
                result.SetElement(x, y, (int)char.GetNumericValue(input[y][x]));
            }
        }

        return result;
    }

    internal static int SolvePartOne(ICollection<string> input)
    {
        var forestMap = ParseInput(input.WithNoEmptyLines().ToList());

        var visibleTrees = new HashSet<Coordinate>();

        for (var y = 0; y < forestMap.Height; y++)
        {
            for (var x = 0; x < forestMap.Width; x++)
            {
                if (x == 0 || x >= forestMap.Width ||
                    y == 0 || y >= forestMap.Height)
                {
                    visibleTrees.Add(new Coordinate(x, y));
                    continue;
                }

                var currentTree = forestMap.GetElement(x, y);
                
                // Left
                var visible = true;

                for (var currX = 0; currX < x; currX++)
                {
                    if (forestMap.GetElement(currX, y) >= currentTree)
                    {
                        visible = false;
                        break;
                    }
                }

                if (visible)
                {
                    visibleTrees.Add(new Coordinate(x, y));
                    continue;
                }

                // Right
                visible = true;

                for (var currX = forestMap.Width-1; currX > x; currX--)
                {
                    if (forestMap.GetElement(currX, y) >= currentTree)
                    {
                        visible = false;
                        break;
                    }
                }

                if (visible)
                {
                    visibleTrees.Add(new Coordinate(x, y));
                    continue;
                }

                // Top
                visible = true;

                for (var currY = 0; currY < y; currY++)
                {
                    if (forestMap.GetElement(x, currY) >= currentTree)
                    {
                        visible = false;
                        break;
                    }
                }

                if (visible)
                {
                    visibleTrees.Add(new Coordinate(x, y));
                    continue;
                }

                // Bottom
                visible = true;

                for (var currY = forestMap.Height-1; currY > y; currY--)
                {
                    if (forestMap.GetElement(x, currY) >= currentTree)
                    {
                        visible = false;
                        break;
                    }
                }

                if (visible)
                {
                    visibleTrees.Add(new Coordinate(x, y));
                }
            }
        }

        return visibleTrees.Count;
    }

    internal static int SolvePartTwo(ICollection<string> input)
    {
        var forestMap = ParseInput(input.WithNoEmptyLines().ToList());

        var visibilityScores = new Dictionary<Coordinate, int>();

        for (var y = 1; y < forestMap.Height - 1; y++)
        {
            for (var x = 1; x < forestMap.Width - 1; x++)
            {
                var currentTree = forestMap.GetElement(x, y);

                // Left
                var distanceLeft = 1;

                for (var currX = x - 1; currX > 0; currX--)
                {
                    if (forestMap.GetElement(currX, y) >= currentTree)
                    {
                        break;
                    }

                    distanceLeft++;
                }

                // Right
                var distanceRight = 1;

                for (var currX = x + 1; currX < forestMap.Width - 1; currX++)
                {
                    if (forestMap.GetElement(currX, y) >= currentTree)
                    {
                        break;
                    }

                    distanceRight++;
                }

                // Top
                var distanceTop = 1;

                for (var currY = y - 1; currY > 0; currY--)
                {
                    if (forestMap.GetElement(x, currY) >= currentTree)
                    {
                        break;
                    }

                    distanceTop++;
                }

                // Bottom
                var distanceBottom = 1;

                for (var currY = y + 1; currY < forestMap.Height - 1; currY++)
                {
                    if (forestMap.GetElement(x, currY) >= currentTree)
                    {
                        break;
                    }

                    distanceBottom++;
                }

                visibilityScores.Add(new Coordinate(x,y), distanceLeft*distanceRight*distanceTop*distanceBottom);
            }
        }

        return visibilityScores.Max(x => x.Value);
    }
}