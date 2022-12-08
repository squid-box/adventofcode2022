namespace AdventOfCode2022.Tests.Problems;

using AdventOfCode2022.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem8Tests
{
    private readonly string[] _testInput =
    {
        "30373",
        "25512",
        "65332",
        "33549",
        "35390",
    };

    [Test]
    public void TestPartOne()
    {
        Assert.AreEqual(21, Problem8.SolvePartOne(_testInput));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.AreEqual(8, Problem8.SolvePartTwo(_testInput));
    }
}