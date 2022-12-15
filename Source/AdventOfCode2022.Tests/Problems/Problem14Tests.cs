namespace AdventOfCode2022.Tests.Problems;

using AdventOfCode2022.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem14Tests
{
    private readonly string[] _testInput =
    {
        "498,4 -> 498,6 -> 496,6",
        "503,4 -> 502,4 -> 502,9 -> 494,9"
    };

    [Test]
    public void TestPartOne()
    {
        Assert.AreEqual(24, Problem14.SolvePartOne(_testInput));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.AreEqual(93, Problem14.SolvePartTwo(_testInput));
    }
}