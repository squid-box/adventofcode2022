namespace AdventOfCode2022.Problems;

using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2022.Utils;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2022/day/9">Day 9</a>.
/// </summary>
public class Problem9 : ProblemBase
{
    public Problem9(InputDownloader inputDownloader) : base(9, inputDownloader) { }

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

    internal static int SolvePartOne(ICollection<string> input)
    {
        var map = new RopeMap(2);

        foreach (var line in input)
        {
            var split = line.Split(' ');

            map.Move(split[0], Convert.ToInt32(split[1]));    
        }

        return map.Visited.Count;
    }

    internal static int SolvePartTwo(ICollection<string> input)
    {
        var map = new RopeMap(10);

        foreach (var line in input)
        {
            var split = line.Split(' ');

            map.Move(split[0], Convert.ToInt32(split[1]));
        }

        return map.Visited.Count;
    }

    private class RopeMap
    {
        private readonly List<Coordinate> _knots;

        public RopeMap(int numberOfKnots)
        {
            Visited = new HashSet<Coordinate>();
            _knots = new List<Coordinate>(numberOfKnots);

            for (var i = 0; i < numberOfKnots; i++)
            {
                _knots.Add(Coordinate.Zero);
            }

            Visited.Add(Coordinate.Zero);
        }

        public HashSet<Coordinate> Visited { get; }

        public void Move(string direction, int moves)
        {
            for (var i = 0; i < moves; i++)
            {
                switch (direction)
                {
                    case "R":
                        _knots[0] += Vector.East;
                        break;
                    case "D":
                        _knots[0] += Vector.South;
                        break;
                    case "L":
                        _knots[0] += Vector.West;
                        break;
                    case "U":
                        _knots[0] += Vector.North;
                        break;
                }

                for (var k = 1; k < _knots.Count; k++)
                {
                    var distanceToNext = _knots[k-1] - _knots[k];
                    
                    if (distanceToNext.Magnitude < 2)
                    {
                        continue;
                    }

                    if (_knots[k - 1].X > _knots[k].X)
                    {
                        _knots[k] += Vector.East;
                    }
                    else if (_knots[k - 1].X < _knots[k].X)
                    {
                        _knots[k] += Vector.West;
                    }

                    if (_knots[k - 1].Y > _knots[k].Y)
                    {
                        _knots[k] += Vector.North;
                    }
                    else if (_knots[k - 1].Y < _knots[k].Y)
                    {
                        _knots[k] += Vector.South;
                    }
                }

                Visited.Add(_knots.Last());
            }
        }
    }
}