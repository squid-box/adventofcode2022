namespace AdventOfCode2022.Tests.Problems;

using AdventOfCode2022.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem19Tests
{
    private readonly string[] _testInput =
    {
        "Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 2 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 2 ore and 7 obsidian.",
        "Blueprint 2: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 8 clay. Each geode robot costs 3 ore and 12 obsidian."
    };

    [Test]
    public void TestPartOne()
    {
        Assert.AreEqual(33, Problem19.SolvePartOne(_testInput));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.AreEqual(-1, Problem19.SolvePartTwo(_testInput));
    }
}