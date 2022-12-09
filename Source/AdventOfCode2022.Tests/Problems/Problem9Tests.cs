namespace AdventOfCode2022.Tests.Problems;

using AdventOfCode2022.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem9Tests
{
    private readonly string[] _testInput1 =
    {
        "R 4",
        "U 4",
        "L 3",
        "D 1",
        "R 4",
        "D 1",
        "L 5",
        "R 2"
    };

    private readonly string[] _testInput2 =
    {
        "R 5",
        "U 8",
        "L 8",
        "D 3",
        "R 17",
        "D 10",
        "L 25",
        "U 20"
    };

    [Test]
    public void TestPartOne()
    {
        Assert.AreEqual(13, Problem9.SolvePartOne(_testInput1));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.AreEqual(1, Problem9.SolvePartTwo(_testInput1));
        Assert.AreEqual(36, Problem9.SolvePartTwo(_testInput2));
    }
}