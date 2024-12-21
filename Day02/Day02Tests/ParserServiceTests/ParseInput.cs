using Day02.Model;
using Day02.Service;
using FluentAssertions;
using Xunit;

namespace Day02Tests.ParserServiceTests;

public class ParseInput
{
    // TODO if this wasn't AoC
    // TODO - test for non-numbers
    // TODO - test for different number of levels on each report
    // TODO - test for levels not perfectly separated by 1 space
    // TODO - test for negatives

    [Fact]
    public void EmptyStringReturnsZeroRows()
    {
        var sut = new ParserService();
        var puzzle = sut.ParseInput("");

        puzzle.Reports.Should().HaveCount(0);
    }

    [Fact]
    public void ReturnsRowPerNonEmptyLine()
    {
        var sut = new ParserService();
        var puzzle = sut.ParseInput("""
1
2

3

""");

        puzzle.Reports.Should().HaveCount(3);
    }

    [Fact]
    public void ReturnsCorrectNumberOfLevelsPerRow()
    {
        var sut = new ParserService();
        var puzzle = sut.ParseInput("""
1 2 3 4
5 6 7 8
9 10 11 12
""");

        puzzle.Reports.Should().HaveCount(3);
        puzzle.Reports.Should().AllSatisfy(p => p.Levels.Should().HaveCount(4));
    }

    [Fact]
    public void ReturnsCorrectReport()
    {
        var sut = new ParserService();
        var puzzle = sut.ParseInput("""
666 456 252 54746
1 0 1 2
986 65928 596854 3459
568 69 0 6587345
""");

        puzzle.Should().BeEquivalentTo(new Puzzle
        {
            Reports =
            [
                new()
                {
                    Levels =
                    [
                        new(666),
                        new(456),
                        new(252),
                        new(54746),
                    ],
                },
                new()
                {
                    Levels =
                    [
                        new(1),
                        new(0),
                        new(1),
                        new(2),
                    ],
                },
                new()
                {
                    Levels =
                    [
                        new(986),
                        new(65928),
                        new(596854),
                        new(3459),
                    ],
                },
                new()
                {
                    Levels =
                    [
                        new(568),
                        new(69),
                        new(0),
                        new(6587345),
                    ],
                },
            ],
        });
    }
}
