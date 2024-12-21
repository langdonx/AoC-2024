using Day02.Model;
using Day02.Service;
using FluentAssertions;
using Xunit;

namespace Day02Tests.LevelAnalyzerTests;

public class IsAcceptableDecrease
{
    [Theory]
    [InlineData(1, 1, false)] // same
    [InlineData(1, 2, false)] // increases...
    [InlineData(1, 3, false)]
    [InlineData(1, 4, false)]
    [InlineData(1, 5, false)]
    [InlineData(5, 1, false)] // decrease but too large
    [InlineData(5, 2, true)]
    [InlineData(5, 3, true)]
    [InlineData(5, 4, true)]
    [InlineData(9, 8, true)]
    public void Decreases(int value1, int value2, bool expectation)
    {
        var sut = new LevelAnalyzer();

        var result = sut.IsAcceptableDecrease(new Level(value1), new Level(value2));

        result.Should().Be(expectation);
    }
}
