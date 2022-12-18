namespace AdventOfCode2022.Tests.Problems;

using AdventOfCode2022.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem16Tests
{
    private readonly string[] _testInput =
    {
        "Valve AA has flow rate=0; tunnels lead to valves DD, II, BB",
        "Valve BB has flow rate=13; tunnels lead to valves CC, AA",
        "Valve CC has flow rate=2; tunnels lead to valves DD, BB",
        "Valve DD has flow rate=20; tunnels lead to valves CC, AA, EE",
        "Valve EE has flow rate=3; tunnels lead to valves FF, DD",
        "Valve FF has flow rate=0; tunnels lead to valves EE, GG",
        "Valve GG has flow rate=0; tunnels lead to valves FF, HH",
        "Valve HH has flow rate=22; tunnel leads to valve GG",
        "Valve II has flow rate=0; tunnels lead to valves AA, JJ",
        "Valve JJ has flow rate=21; tunnel leads to valve II"
    };

    [Test]
    public void TestPartOne()
    {
        Assert.AreEqual(1651, Problem16.SolvePartOne(_testInput));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.AreEqual(-1, Problem16.SolvePartTwo(_testInput));
    }
}