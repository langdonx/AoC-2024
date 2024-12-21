using Day02.Model;
using Day02.Service;
using FluentAssertions;
using Xunit;

namespace Day02Tests.LevelAnalyzerTests;

public class IsAcceptableIncrease
{
    [Theory]
    [InlineData(1, 1, false)] // same
    [InlineData(1, 2, true)]
    [InlineData(1, 3, true)]
    [InlineData(1, 4, true)]
    [InlineData(1, 5, false)] // too large
    [InlineData(5, 1, false)] // decreases...
    [InlineData(5, 2, false)]
    [InlineData(5, 3, false)]
    [InlineData(5, 4, false)]
    [InlineData(9, 8, false)]
    public void Inreases(int value1, int value2, bool expectation)
    {
        var sut = new LevelAnalyzer();

        var result = sut.IsAcceptableIncrease(new Level(value1), new Level(value2));

        result.Should().Be(expectation);
    }
}
