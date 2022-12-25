namespace AdventOfCode2022.Tests.Problems;

using AdventOfCode2022.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem25Tests
{
    private readonly string[] _testInput =
    {
        "1=-0-2",
        "12111",
        "2=0=",
        "21",
        "2=01",
        "111",
        "20012",
        "112",
        "1=-1=",
        "1-12",
        "12",
        "1=",
        "122"
    };

    [Test]
    public void TestPartOne()
    {
        Assert.AreEqual("2=-1=0", Problem25.SolvePartOne(_testInput));
    }

    [TestCase("1=-0-2", 1747)]
    [TestCase("12111", 906)]
    [TestCase("2=0=", 198)]
    [TestCase("21", 11)]
    [TestCase("2=01", 201)]
    [TestCase("111", 31)]
    [TestCase("20012", 1257)]
    [TestCase("112", 32)]
    [TestCase("1=-1=", 353)]
    [TestCase("1-12", 107)]
    [TestCase("12", 7)]
    [TestCase("1=", 3)]
    [TestCase("122", 37)]
    [TestCase("2=-1=0", 4890)]
    [TestCase("2-1022011111", 90032031)]
    public void TestLongToSnafu(string expectedResult, int input)
    {
        Assert.AreEqual(expectedResult, Problem25.LongToSnafu(input));
    }

    [TestCase("1=-0-2", 1747)]
    [TestCase("12111", 906)]
    [TestCase("2=0=", 198)]
    [TestCase("21", 11)]
    [TestCase("2=01", 201)]
    [TestCase("111", 31)]
    [TestCase("20012", 1257)]
    [TestCase("112", 32)]
    [TestCase("1=-1=", 353)]
    [TestCase("1-12", 107)]
    [TestCase("12", 7)]
    [TestCase("1=", 3)]
    [TestCase("122", 37)]
    [TestCase("2=-1=0", 4890)]
    [TestCase("2-1022011111", 90032031)]
    public void TestSnafuToInt(string input, int expectedResult)
    {
        Assert.AreEqual(expectedResult, Problem25.SnafuToLong(input));
    }
}