    namespace AdventOfCode2022.Tests.Problems;

using AdventOfCode2022.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem23Tests
{
    private readonly string[] _testInput =
    {
        ".....",
        "..##.",
        "..#..",
        ".....",
        "..##.",
        "....."
    };
    
    private readonly string[] _testInput2 =
    {
        "..............",
        "..............",
        ".......#......",
        ".....###.#....",
        "...#...#.#....",
        "....#...##....",
        "...#.###......",
        "...##.#.##....",
        "....#..#......",
        "..............",
        "..............",
        ".............."
    };

    [Test]
    public void TestFindEmptySpaces()
    {
        var state = Problem23.ParseInput(_testInput2);
        Assert.AreEqual(27, Problem23.FindEmptySpaces(state));
    }

    [Test]
    public void TestPartOne()
    {
        Assert.AreEqual(25, Problem23.SolvePartOne(_testInput));
        Assert.AreEqual(110, Problem23.SolvePartOne(_testInput2));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.AreEqual(20, Problem23.SolvePartTwo(_testInput2));
    }
}