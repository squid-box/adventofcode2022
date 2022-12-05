namespace AdventOfCode2022.Tests.Problems
{
    using AdventOfCode2022.Problems;
    using NUnit.Framework;

    [TestFixture]
    public class Problem5Tests
    {
        private readonly string[] _testInput =
        {
            "    [D]    ",
            "[N] [C]    ",
            "[Z] [M] [P]",
            " 1   2   3 ",
            "",
            "move 1 from 2 to 1",
            "move 3 from 1 to 3",
            "move 2 from 2 to 1",
            "move 1 from 1 to 2"
        };

        [Test]
        public void TestPartOne()
        {
            Assert.AreEqual("CMZ", Problem5.SolvePartOne(_testInput));
        }

        [Test]
        public void TestPartTwo()
        {
            Assert.AreEqual("MCD", Problem5.SolvePartTwo(_testInput));
        }
    }
}
