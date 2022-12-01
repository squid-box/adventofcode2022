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

        private static IEnumerable<int> ParseInput(IEnumerable<string> input)
        {
            var elvesWithFood = new List<int>();
            var currentElf = 0;

            foreach (var foodItem in input)
            {
                if (elvesWithFood.Count < currentElf + 1)
                {
                    elvesWithFood.Add(0);
                }

                if (string.IsNullOrEmpty(foodItem))
                {
                    currentElf++;
                    continue;
                }

                elvesWithFood[currentElf] += foodItem.ToInt();
            }

            return elvesWithFood;
        }

        internal static int SolvePartOne(IEnumerable<string> input)
        {
            return ParseInput(input).Max();
        }

        internal static int SolvePartTwo(IEnumerable<string> input)
        {
            return ParseInput(input).Order().Reverse().Take(3).Sum();
        }
    }
}
