namespace AdventOfCode2022.Tests.Problems;

using AdventOfCode2022.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem20Tests
{
    private readonly string[] _testInput =
    {
        "1",
        "2",
        "-3",
        "3",
        "-2",
        "0",
        "4"
    };

    [Test]
    public void TestPartOne()
    {
        Assert.AreEqual(3, Problem20.SolvePartOne(_testInput));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.AreEqual(-1, Problem20.SolvePartTwo(_testInput));
    }
}