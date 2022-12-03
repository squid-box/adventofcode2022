namespace AdventOfCode2022.Tests.Problems
{
    using AdventOfCode2022.Problems;
    using NUnit.Framework;

    [TestFixture]
    public class Problem3Tests
    {
        private readonly string[] _testInput =
        {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg",
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            "ttgJtRGJQctTZtZT",
            "CrZsJsPPZsGzwwsLwLmpwMDw"
        };

        [Test]
        public void TestPartOne()
        {
            Assert.AreEqual(157, Problem3.SolvePartOne(_testInput));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.AreEqual(70, Problem3.SolvePartTwo(_testInput));
        }
    }
}
