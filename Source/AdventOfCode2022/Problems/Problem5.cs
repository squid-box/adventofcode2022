namespace AdventOfCode2022.Problems;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode2022.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2022/day/5">Day 5</a>.
/// </summary>
public class Problem5 : ProblemBase
{
    public Problem5(InputDownloader inputDownloader) : base(5, inputDownloader) { }

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

    internal static string SolvePartOne(ICollection<string> input)
    {
        var groupedInput = input.SplitByBlankLines();
        var cargoYard = new CargoYard(groupedInput[0]);

        foreach (var instruction in ParseInstructions(groupedInput[1]))
        {
            cargoYard.MoveCrateByCrate(instruction);
        }

        return cargoYard.TopCrates;
    }

    internal static string SolvePartTwo(ICollection<string> input)
    {
        var groupedInput = input.SplitByBlankLines();
        var cargoYard = new CargoYard(groupedInput[0]);

        foreach (var instruction in ParseInstructions(groupedInput[1]))
        {
            cargoYard.MoveSeveralCrates(instruction);
        }

        return cargoYard.TopCrates;
    }

    private static IEnumerable<Instruction> ParseInstructions(IEnumerable<string> input)
    {
        return input.Select(line => new Instruction(line)).ToList();
    }

    /// <summary>
    /// Represents a yard with stacks of cargo.
    /// </summary>
    private class CargoYard
    {
        private readonly List<Stack<char>> _stacks;

        /// <summary>
        /// Creates a new <see cref="CargoYard"/>.
        /// </summary>
        /// <param name="input">Input on the initial state of the <see cref="CargoYard"/>.</param>
        public CargoYard(ICollection<string> input)
        {
            var columns = Convert.ToInt32(input.Last().Trim().Split(' ').Last());
            _stacks = new List<Stack<char>>();

            for (var i = 0; i < columns; i++)
            {
                _stacks.Add(new Stack<char>());
            }

            // Read input in reverse to generate the stacks and skip line with stack numbers.
            foreach (var row in input.SkipLast(1).Reverse())
            {
                for (var col = 0; col < columns; col++)
                {
                    var index = 1 + col * 4;
                    if (!row[index].Equals(' '))
                    {
                        _stacks[col].Push(row[index]);
                    }
                }
            }
        }

        /// <summary>
        /// Moves several crates one at a time.
        /// </summary>
        /// <param name="instruction">Instruction on how to move the crates.</param>
        public void MoveCrateByCrate(Instruction instruction)
        {
            for (var n = 0; n < instruction.NumberOfCrates; n++)
            {
                _stacks[instruction.DestinationStack].Push(_stacks[instruction.SourceStack].Pop());
            }
        }

        /// <summary>
        /// Moves several crates at once.
        /// </summary>
        /// <param name="instruction">Instruction on how to move the crates.</param>
        public void MoveSeveralCrates(Instruction instruction)
        {
            var transport = _stacks[instruction.SourceStack].PopRange(instruction.NumberOfCrates);

            // We need to reverse these crates to maintain their order.
            transport = transport.Reverse();

            _stacks[instruction.DestinationStack].PushRange(transport);
        }

        /// <summary>
        /// Gets the top crates of all stacks in the <see cref="CargoYard"/>.
        /// </summary>
        public string TopCrates => string.Join(null, _stacks.Select(stack => stack.Peek()));
    }

    /// <summary>
    /// Represents a cargo transfer instruction.
    /// </summary>
    private readonly struct Instruction
    {
        /// <summary>
        /// Creates a new <see cref="Instruction"/> from given input.
        /// </summary>
        /// <param name="input">Input to parse into an <see cref="Instruction"/>.</param>
        public Instruction(string input)
        {
            var match = Regex.Match(input, @"move (?<number>\d+) from (?<source>\d+) to (?<destination>\d+)", RegexOptions.ExplicitCapture);

            NumberOfCrates = Convert.ToInt32(match.Groups["number"].Value);
            SourceStack = Convert.ToInt32(match.Groups["source"].Value) - 1;
            DestinationStack = Convert.ToInt32(match.Groups["destination"].Value) - 1;
        }

        /// <summary>
        /// The number of crates to move.
        /// </summary>
        public int NumberOfCrates { get; }

        /// <summary>
        /// The stack index to move crate(s) from.
        /// </summary>
        public int SourceStack { get; }

        /// <summary>
        /// The stack index to move crate(s) to.
        /// </summary>
        public int DestinationStack { get; }
    }
}