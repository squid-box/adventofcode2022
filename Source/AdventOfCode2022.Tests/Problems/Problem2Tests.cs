namespace AdventOfCode2022.Tests.Problems
{
    using AdventOfCode2022.Problems;
    using NUnit.Framework;

    [TestFixture]
    public class Problem2Tests
    {
        private readonly string[] _testInput = new[]
        {
            "A Y",
            "B X",
            "C Z"
        };

        [Test]
        public void TestPartOne()
        {
            Assert.AreEqual(15, Problem2.SolvePartOne(_testInput));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.AreEqual(12, Problem2.SolvePartTwo(_testInput));
        }
    }
}