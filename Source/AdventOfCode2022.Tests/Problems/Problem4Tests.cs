namespace AdventOfCode2022.Tests.Problems
{
    using AdventOfCode2022.Problems;
    using NUnit.Framework;

    [TestFixture]
    public class Problem4Tests
    {
        private readonly string[] _testInput =
        {
            "2-4,6-8",
            "2-3,4-5",
            "5-7,7-9",
            "2-8,3-7",
            "6-6,4-6",
            "2-6,4-8"
        };

        [Test]
        public void TestPartOne()
        {
            Assert.AreEqual(2, Problem4.SolvePartOne(_testInput));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.AreEqual(4, Problem4.SolvePartTwo(_testInput));
        }
    }
}