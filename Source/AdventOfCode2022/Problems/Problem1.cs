namespace AdventOfCode2022.Problems
{
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode2022.Utils.Extensions;

    /// <summary>
    /// Solution for <a href="https://adventofcode.com/2022/day/1">Day 1</a>.
    /// </summary>
    public class Problem1 : ProblemBase
    {
        public Problem1(InputDownloader inputDownloader) : base(1, inputDownloader) { }

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

        private static IEnumerable<int> ParseInput(ICollection<string> input)
        {
            return input.SplitByBlankLines()
                .Select(elf => elf.AsInt().Sum())
                .ToList();
        }

        internal static int SolvePartOne(ICollection<string> input)
        {
            return ParseInput(input).Max();
        }

        internal static int SolvePartTwo(ICollection<string> input)
        {
            return ParseInput(input)
                .OrderDescending()
                .Take(3)
                .Sum();
        }
    }
}
