namespace AdventOfCode2022.Problems
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Solution for <a href="https://adventofcode.com/2022/day/3">Day 3</a>.
    /// </summary>
    public class Problem3 : ProblemBase
    {
        public Problem3(InputDownloader inputDownloader) : base(3, inputDownloader) { }

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

        internal static IList<(IList<char> first, IList<char> second)> ParseInput(IEnumerable<string> input)
        {
            var result = new List<(IList<char>, IList<char>)>();

            foreach (var line in input)
            {
                result.Add((line.Take(line.Length / 2).ToList(), line.Skip(line.Length / 2).ToList()));
            }

            return result;
        }

        internal static int SolvePartOne(ICollection<string> input)
        {
            var score = 0;

            var parsed = ParseInput(input);

            foreach (var pair in parsed)
            {
                score += FindScore(FindCommonChar(pair.first, pair.second));
            }

            return score;
        }

        internal static char FindCommonChar(IList<char> first, IList<char> second)
        {
            for (var i = 0; i < first.Count; i++)
            {
                if (second.Contains(first[i]))
                {
                    return first[i];
                }
            }

            return '\0';
        }

        internal static int FindScore(char item)
        {
            if (char.IsLower(item))
            {
                return item - 96;
            }
            else
            {
                return item - 38;
            }
        }

        internal static int SolvePartTwo(ICollection<string> input)
        {
            return 0;
        }
    }
}
