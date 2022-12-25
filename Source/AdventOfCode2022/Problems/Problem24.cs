namespace AdventOfCode2022.Problems;

using System.Collections.Generic;
using System.Linq;
using AdventOfCode2022.Utils;
using AdventOfCode2022.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2022/day/24">Day 24</a>.
/// </summary>
public class Problem24 : ProblemBase
{
    public Problem24(InputDownloader inputDownloader) : base(24, inputDownloader) { }

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

    internal static long SolvePartOne(ICollection<string> input)
    {
        var map = new Valley(input.WithNoEmptyLines());

        return 0;
    }

    internal static long SolvePartTwo(ICollection<string> input)
    {
        return 0;
    }

    /// <summary>
    /// Represents the Valley.
    /// </summary>
    private class Valley
    {
        /// <summary>
        /// Creates a new <see cref="Valley"/>.
        /// </summary>
        /// <param name="input">Input for the <see cref="Valley"/> starting state.</param>
        public Valley(IList<string> input)
        {
            Walls = new HashSet<Coordinate>();
            Blizzards = new HashSet<Blizzard>();

            Width = input.First().Length;
            Height = input.Count;

            Start = new Coordinate(0, input.First().IndexOf('.'));
            End = new Coordinate(input.Count - 1, input.Last().IndexOf('.'));

            for (var y = 0; y < input.Count; y++)
            {
                for (var x = 0; x < input.First().Length; x++)
                {
                    switch (input[y][x])
                    {
                        case '#':
                            Walls.Add(new Coordinate(x, y));
                            break;
                        case '<':
                            Blizzards.Add(new Blizzard(new Coordinate(x, y), Vector.West));
                            break;
                        case '>':
                            Blizzards.Add(new Blizzard(new Coordinate(x, y), Vector.East));
                            break;
                        case 'v':
                            Blizzards.Add(new Blizzard(new Coordinate(x, y), Vector.South));
                            break;
                        case '^':
                            Blizzards.Add(new Blizzard(new Coordinate(x, y), Vector.North));
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the width of the <see cref="Valley"/>.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Gets the height of the <see cref="Valley"/>.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Gets the start position.
        /// </summary>
        public Coordinate Start { get; }

        /// <summary>
        /// Gets the end position.
        /// </summary>
        public Coordinate End { get; }

        /// <summary>
        /// Gets the walls of the <see cref="Valley"/>.
        /// </summary>
        public HashSet<Coordinate> Walls { get; }

        /// <summary>
        /// Gets the <see cref="Blizzard"/>s in the <see cref="Valley"/>.
        /// </summary>
        public HashSet<Blizzard> Blizzards { get; }

        /// <summary>
        /// Moves all <see cref="Blizzard"/>s one step.
        /// </summary>
        public void Step()
        {
            foreach (var blizzard in Blizzards)
            {
                if (Walls.Contains(blizzard.Position + blizzard.Direction))
                {
                    Coordinate newPosition;

                    if (blizzard.Direction.Equals(Vector.East))
                    {
                        newPosition = new Coordinate(1, blizzard.Position.Y);
                    }
                    else if (blizzard.Direction.Equals(Vector.South))
                    {
                        newPosition = new Coordinate(blizzard.Position.X, 1);
                    }
                    else if (blizzard.Direction.Equals(Vector.West))
                    {
                        newPosition = new Coordinate(Width - 2, blizzard.Position.Y);
                    }
                    else
                    {
                        newPosition = new Coordinate(blizzard.Position.X, Height - 2);
                    }

                    blizzard.Reform(newPosition);
                }
                else
                {
                    blizzard.Move();
                }
            }
        }
    }

    /// <summary>
    /// Represents a blizzard.
    /// </summary>
    private class Blizzard
    {
        /// <summary>
        /// Creates a new <see cref="Blizzard"/>.
        /// </summary>
        /// <param name="startingPosition">Initial position of the <see cref="Blizzard"/>.</param>
        /// <param name="direction">Direction the <see cref="Blizzard"/> is moving in.</param>
        public Blizzard(Coordinate startingPosition, Vector direction)
        {
            Position = startingPosition;
            Direction = direction;
        }

        /// <summary>
        /// Current position of the <see cref="Blizzard"/>.
        /// </summary>
        public Coordinate Position { get; private set; }

        /// <summary>
        /// Direction of the <see cref="Blizzard"/>.
        /// </summary>
        public Vector Direction { get; }

        /// <summary>
        /// Moves the <see cref="Blizzard"/> on step in its current <see cref="Direction"/>.
        /// </summary>
        public void Move()
        {
            Position += Direction;
        }

        /// <summary>
        /// Recreates the <see cref="Blizzard"/> in a new position.
        /// </summary>
        /// <param name="newPosition"></param>
        public void Reform(Coordinate newPosition)
        {
            Position = newPosition;
        }
    }
}