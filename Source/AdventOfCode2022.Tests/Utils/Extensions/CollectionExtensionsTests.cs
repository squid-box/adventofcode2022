namespace AdventOfCode2022.Tests.Utils.Extensions;

using System.Collections.Generic;
using AdventOfCode2022.Utils.Extensions;
using NUnit.Framework;

[TestFixture]
public class CollectionExtensionsTests
{
    [TestCase(new[] {"1"}, new[] { 1 })]
    [TestCase(new[] {"1", "2", "3"}, new[] { 1, 2, 3 })]
    public void TestAsInt(ICollection<string> input, ICollection<int> expected)
    {
        Assert.AreEqual(expected, input.AsInt());
    }

    [TestCase(new[] { "1" }, new[] { 1L })]
    [TestCase(new[] { "1", "2", "3" }, new[] { 1L, 2L, 3L })]
    public void TestAsLong(ICollection<string> input, ICollection<long> expected)
    {
        Assert.AreEqual(expected, input.AsLong());
    }

    [TestCase(new[] { "" }, 0)]
    [TestCase(new[] { "A Line", "", "Another line" }, 2)]
    [TestCase(new[] { null, "A Line", "", "Another line" }, 2)]
    public void TestWithNoEmptyLines(ICollection<string> input, int expectedLines)
    {
        Assert.AreEqual(expectedLines, input.WithNoEmptyLines().Count);
    }

    [Test]
    public void TestSplitByBlankLines()
    {
        var inputOne = new List<string>
        {
            "Line",
            "Another line",
            "",
            "Third line"
        };

        Assert.AreEqual(2, inputOne.SplitByBlankLines().Count);

        var inputTwo = new List<string>
        {
            "Line",
            "Another line",
            "",
            "Third line",
            "",
            "",
            "Fourth line"
        };

        Assert.AreEqual(3, inputTwo.SplitByBlankLines().Count);
    }
}