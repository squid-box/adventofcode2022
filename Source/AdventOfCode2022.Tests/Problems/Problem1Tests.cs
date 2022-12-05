namespace AdventOfCode2022.Tests.Problems;

using AdventOfCode2022.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem1Tests
{
    private readonly string[] _testInput =
    {
        "1000",
        "2000",
        "3000",
        "",
        "4000",
        "",
        "5000",
        "6000",
        "",
        "7000",
        "8000",
        "9000",
        "",
        "10000"
    };

    [Test]
    public void TestPartOne()
    {
        Assert.AreEqual(24000, Problem1.SolvePartOne(_testInput));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.AreEqual(45000, Problem1.SolvePartTwo(_testInput));
    }
}