namespace AdventOfCode2022.Tests.Problems;

using AdventOfCode2022.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem18Tests
{
    private readonly string[] _testInput =
    {
        "2,2,2",
        "1,2,2",
        "3,2,2",
        "2,1,2",
        "2,3,2",
        "2,2,1",
        "2,2,3",
        "2,2,4",
        "2,2,6",
        "1,2,5",
        "3,2,5",
        "2,1,5",
        "2,3,5"
    };

    [Test]
    public void TestPartOne()
    {
        Assert.AreEqual(10, Problem18.SolvePartOne(new [] {"1,1,1", "2,1,1"}));
        Assert.AreEqual(64, Problem18.SolvePartOne(_testInput));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.AreEqual(58, Problem18.SolvePartTwo(_testInput));
    }
}