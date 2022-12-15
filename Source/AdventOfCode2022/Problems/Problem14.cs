namespace AdventOfCode2022.Problems;

using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2022.Utils;
using AdventOfCode2022.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2022/day/14">Day 14</a>.
/// </summary>
public class Problem14 : ProblemBase
{
    public Problem14(InputDownloader inputDownloader) : base(14, inputDownloader)
    {
    }

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

    private static HashSet<Coordinate> ParseScan(IEnumerable<string> input)
    {
        var rocks = new HashSet<Coordinate>();

        foreach (var line in input)
        {
            var split = line.Split(" -> ");

            for (var i = 0; i < split.Length - 1; i++)
            {
                // Determine points
                var pointOne = split[i].Split(',').AsInt();
                var pointTwo = split[i + 1].Split(',').AsInt();

                // Generate coordinates between the two points
                if (pointOne[0] == pointTwo[0])
                {
                    // Same X
                    var min = Math.Min(pointOne[1], pointTwo[1]);
                    var max = Math.Max(pointOne[1], pointTwo[1]);

                    for (var y = min; y <= max; y++)
                    {
                        rocks.Add(new Coordinate(pointOne[0], y));
                    }
                }
                else if (pointOne[1] == pointTwo[1])
                {
                    // Same Y
                    var min = Math.Min(pointOne[0], pointTwo[0]);
                    var max = Math.Max(pointOne[0], pointTwo[0]);

                    for (var x = min; x <= max; x++)
                    {
                        rocks.Add(new Coordinate(x, pointOne[1]));
                    }
                }
            }
        }

        return rocks;
    }

    internal static long SolvePartOne(ICollection<string> input)
    {
        var rocks = ParseScan(input.WithNoEmptyLines());

        var simulator = new SandSimulator(rocks);

        simulator.Simulate();

        return simulator.RestingSand;
    }

    internal static long SolvePartTwo(ICollection<string> input)
    {
        var rocks = ParseScan(input.WithNoEmptyLines());

        var simulator = new SandSimulator(rocks);

        simulator.SimulateWithFloor();

        return simulator.RestingSand;
    }

    private class SandSimulator
    {
        private readonly HashSet<Coordinate> _rocks;
        private readonly Coordinate _startingPosition;

        public SandSimulator(HashSet<Coordinate> rocks)
        {
            _rocks = rocks;
            _startingPosition = new Coordinate(500, 0);

            RestingSand = 0;
        }

        public int RestingSand { get; private set; }

        public void Simulate()
        {
            var cutOff = _rocks.Max(rock => rock.Y);

            while (true)
            {
                var sand = new SandGrain(_startingPosition, _rocks);

                if (sand.Simulate(cutOff))
                {
                    break;
                }
                else
                {
                    RestingSand++;
                    _rocks.Add(sand.Position);
                }
            }
        }

        public void SimulateWithFloor()
        {
            var floor = _rocks.Max(rock => rock.Y) + 2;

            var xMin = _rocks.Min(rock => rock.X) - 500;
            var xMax = _rocks.Max(rock => rock.X) + 500;

            for (var x = xMin; x <= xMax; x++)
            {
                _rocks.Add(new Coordinate(x, floor));
            }

            while (true)
            {
                var sand = new SandGrain(_startingPosition, _rocks);

                sand.Simulate(floor + 2);

                RestingSand++;
                _rocks.Add(sand.Position);

                if (sand.Position.Equals(_startingPosition))
                {
                    break;
                }
            }
        }
    }

    private class SandGrain
    {
        private readonly HashSet<Coordinate> _rocks;

        private static readonly Vector Down = new(0, 1);
        private static readonly Vector Left = new(-1, 0);
        private static readonly Vector Right = new(1, 0);

        public SandGrain(Coordinate startingPosition, HashSet<Coordinate> rocks)
        {
            Position = startingPosition;
            _rocks = rocks;
        }

        public Coordinate Position { get; private set; }

        public bool Simulate(int cutOff)
        {
            var moving = true;

            while (moving)
            {
                if (Position.Y > cutOff)
                {
                    // Into the void
                    return true;
                }
                
                if (!_rocks.Contains(Position + Down))
                {
                    Position += Down;
                }
                else if (!_rocks.Contains(Position + Down + Left))
                {
                    Position += Down + Left;
                }
                else if (!_rocks.Contains(Position + Down + Right))
                {
                    Position += Down + Right;
                }
                else
                {
                    moving = false;
                }
            }

            return false;
        }
    }
}