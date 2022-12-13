namespace AdventOfCode2022.Tests.Problems;

using AdventOfCode2022.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem12Tests
{
    private readonly string[] _testInput =
    {
        "Sabqponm",
        "abcryxxl",
        "accszExk",
        "acctuvwj",
        "abdefghi"
    };

    [Test]
    public void TestPartOne()
    {
        Assert.AreEqual(31, Problem12.SolvePartOne(_testInput));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.AreEqual(29, Problem12.SolvePartTwo(_testInput));
    }
}