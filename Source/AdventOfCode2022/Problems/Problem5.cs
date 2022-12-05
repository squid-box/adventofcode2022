namespace AdventOfCode2022.Problems
{
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
            var columns = Convert.ToInt32(groupedInput[0].Last().Trim().Split(' ').Last());

            var initialState = new List<List<char>>(columns);

            for (var i = 0; i < columns; i++)
            {
                initialState.Add(new List<char>());
            }

            foreach (var row in groupedInput[0])
            {
                if (char.IsDigit(row[1]))
                {
                    continue;
                }

                for (var col = 0; col < columns; col++)
                {
                    var index = 1 + col * 4;
                    if (!row[index].Equals(' '))
                    {
                        initialState[col].Insert(0, row[index]);
                    }
                }
            }

            var regex = new Regex(@"move (?<number>\d+) from (?<source>\d+) to (?<destination>\d+)", RegexOptions.ExplicitCapture);

            foreach (var instruction in groupedInput[1])
            {
                var match = regex.Match(instruction);

                var number = Convert.ToInt32(match.Groups["number"].Value);
                var source = Convert.ToInt32(match.Groups["source"].Value) - 1;
                var destination = Convert.ToInt32(match.Groups["destination"].Value) - 1;

                var toMove = initialState[source].TakeLast(number).Reverse();
                initialState[destination].AddRange(toMove);
                initialState[source].RemoveRange(initialState[source].Count - number, number);
            }

            var topWord = "";

            foreach (var stack in initialState)
            {
                topWord += stack.Last();
            }

            return topWord;
        }

        internal static string SolvePartTwo(ICollection<string> input)
        {
            var groupedInput = input.SplitByBlankLines();
            var columns = Convert.ToInt32(groupedInput[0].Last().Trim().Split(' ').Last());

            var initialState = new List<List<char>>(columns);

            for (var i = 0; i < columns; i++)
            {
                initialState.Add(new List<char>());
            }

            foreach (var row in groupedInput[0])
            {
                if (char.IsDigit(row[1]))
                {
                    continue;
                }

                for (var col = 0; col < columns; col++)
                {
                    var index = 1 + col * 4;
                    if (!row[index].Equals(' '))
                    {
                        initialState[col].Insert(0, row[index]);
                    }
                }
            }

            var regex = new Regex(@"move (?<number>\d+) from (?<source>\d+) to (?<destination>\d+)", RegexOptions.ExplicitCapture);

            foreach (var instruction in groupedInput[1])
            {
                var match = regex.Match(instruction);

                var number = Convert.ToInt32(match.Groups["number"].Value);
                var source = Convert.ToInt32(match.Groups["source"].Value) - 1;
                var destination = Convert.ToInt32(match.Groups["destination"].Value) - 1;

                var toMove = initialState[source].TakeLast(number);
                initialState[destination].AddRange(toMove);
                initialState[source].RemoveRange(initialState[source].Count - number, number);
            }

            var topWord = "";

            foreach (var stack in initialState)
            {
                topWord += stack.Last();
            }

            return topWord;
        }
    }
}
