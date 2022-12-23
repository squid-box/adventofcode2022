namespace AdventOfCode2022.Problems;

using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2022.Utils;
using AdventOfCode2022.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2022/day/23">Day 23</a>.
/// </summary>
public class Problem23 : ProblemBase
{
    public Problem23(InputDownloader inputDownloader) : base(23, inputDownloader) { }

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

    internal static ISet<Coordinate> ParseInput(IEnumerable<string> input)
    {
        var result = new HashSet<Coordinate>();

        var y = 0;

        foreach (var line in input)
        {
            for (var x = 0; x < line.Length; x++)
            {
                if (line[x].Equals('#'))
                {
                    result.Add(new Coordinate(x, y));
                }
            }

            y++;
        }

        return result;
    }

    internal static int FindEmptySpaces(ISet<Coordinate> state)
    {
        var maxX = state.Max(pos => pos.X);
        var maxY = state.Max(pos => pos.Y);
        var minX = state.Min(pos => pos.X);
        var minY = state.Min(pos => pos.Y);

        var totalSpaces = (maxX - minX + 1) * (maxY - minY + 1);

        return totalSpaces - state.Count;
    }

    internal static long SolvePartOne(ICollection<string> input)
    {
        var state = ParseInput(input);

        var directionStack = new List<Vector>
        {
            Vector.South,
            Vector.North,
            Vector.West,
            Vector.East
        };

        for (var round = 0; round < 10; round++)
        {
            var suggestedState = new Dictionary<Coordinate, ISet<Coordinate>>();

            foreach (var elf in state)
            {
                var target = DetermineTarget(elf, state, directionStack);

                if (!suggestedState.ContainsKey(target))
                {
                    suggestedState.Add(target, new HashSet<Coordinate>());
                }

                suggestedState[target].Add(elf);
            }

            var newState = new HashSet<Coordinate>();

            foreach (var suggestion in suggestedState)
            {
                if (suggestion.Value.Count > 1)
                {
                    // Add old elf states as they won't move.
                    newState.AddRange(suggestion.Value);
                    continue;
                }

                newState.Add(suggestion.Key);
            }

            state = newState;

            directionStack.Add(directionStack[0]);
            directionStack.Remove(directionStack[0]);
        }

        return FindEmptySpaces(state);
    }

    private static bool CanIMove(Coordinate elf, ICollection<Coordinate> state, Vector direction)
    {
        if (direction.Equals(Vector.North))
        {
            return 
                !state.Contains(elf + Vector.North) &&
                !state.Contains(elf + Vector.North + Vector.West) &&
                !state.Contains(elf + Vector.North + Vector.East) ;
        }

        if (direction.Equals(Vector.South))
        {
            return
                !state.Contains(elf + Vector.South) &&
                !state.Contains(elf + Vector.South + Vector.West) &&
                !state.Contains(elf + Vector.South + Vector.East);
        }
        
        if (direction.Equals(Vector.West))
        {
            return
                !state.Contains(elf + Vector.West) &&
                !state.Contains(elf + Vector.West + Vector.North) &&
                !state.Contains(elf + Vector.West + Vector.South);
        }
        
        if (direction.Equals(Vector.East))
        {
            return
                !state.Contains(elf + Vector.East) &&
                !state.Contains(elf + Vector.East + Vector.North) &&
                !state.Contains(elf + Vector.East + Vector.South);
        }

        throw new Exception("oh no again");
    }

    private static Coordinate DetermineTarget(Coordinate elf, ICollection<Coordinate> state, List<Vector> directionStack)
    {
        if (!elf.GetNeighbors().Any(state.Contains))
        {
            return elf;
        }

        foreach (var direction in directionStack)
        {
            if (CanIMove(elf, state, direction))
            {
                return elf + direction;
            }
        }

        return elf;
    }

    internal static long SolvePartTwo(ICollection<string> input)
    {
        var state = ParseInput(input);

        var directionStack = new List<Vector>
        {
            Vector.South,
            Vector.North,
            Vector.West,
            Vector.East
        };

        for (var round = 0; round < int.MaxValue; round++)
        {
            var suggestedState = new Dictionary<Coordinate, ISet<Coordinate>>();

            foreach (var elf in state)
            {
                var target = DetermineTarget(elf, state, directionStack);

                if (!suggestedState.ContainsKey(target))
                {
                    suggestedState.Add(target, new HashSet<Coordinate>());
                }

                suggestedState[target].Add(elf);
            }

            var newState = new HashSet<Coordinate>();

            foreach (var suggestion in suggestedState)
            {
                if (suggestion.Value.Count > 1)
                {
                    // Add old elf states as they won't move.
                    newState.AddRange(suggestion.Value);
                    continue;
                }

                newState.Add(suggestion.Key);
            }
            
            if (newState.All(target => state.Contains(target)))
            {
                return round + 1;
            }

            state = newState;

            directionStack.Add(directionStack[0]);
            directionStack.Remove(directionStack[0]);
        }

        return -1;
    }
}