using Day02.Model;
using Day02.Service;
using FluentAssertions;
using Xunit;

namespace Day02Tests.ReportAnalyzerTests;

public class IsReportSafe
{
    [Fact]
    public void ReturnsFalseForEmptyReport()
    {
        var sut = new ReportAnalyzer(new LevelAnalyzer());
        var report = new Report();

        var result = sut.IsReportSafe(report);

        result.Should().BeFalse();
    }

    [Fact]
    public void ReturnsTrueForAllIncreasingNumbersWithinRange()
    {
        var sut = new ReportAnalyzer(new LevelAnalyzer());
        var report = new Report
        {
            Levels =
            [
                new(1),
                new(2), // +1
                new(4), // +2
                new(7), // +3
            ],
        };

        var result = sut.IsReportSafe(report);

        result.Should().BeTrue();
    }

    [Fact]
    public void ReturnsFalseForIncreasingThenDecreasingNumbers()
    {
        var sut = new ReportAnalyzer(new LevelAnalyzer());
        var report = new Report
        {
            Levels =
            [
                new(1),
                new(2),
                new(1), // decrease
            ],
        };

        var result = sut.IsReportSafe(report);

        result.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalseForIncreasingMoreThanThree()
    {
        var sut = new ReportAnalyzer(new LevelAnalyzer());
        var report = new Report
        {
            Levels =
            [
                new(1),
                new(5), // +4
            ],
        };

        var result = sut.IsReportSafe(report);

        result.Should().BeFalse();
    }

    [Fact]
    public void ReturnsTrueForAllDecreasingNumbersWithinRange()
    {
        var sut = new ReportAnalyzer(new LevelAnalyzer());
        var report = new Report
        {
            Levels =
            [
                new(9),
                new(8), // -1
                new(6), // -2
                new(3), // -3
            ],
        };

        var result = sut.IsReportSafe(report);

        result.Should().BeTrue();
    }

    [Fact]
    public void ReturnsFalseForDecreasingThenIncreasingNumbers()
    {
        var sut = new ReportAnalyzer(new LevelAnalyzer());
        var report = new Report
        {
            Levels =
            [
                new(2),
                new(1),
                new(2), // increase
            ],
        };

        var result = sut.IsReportSafe(report);

        result.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalseForDecreasingMoreThanThree()
    {
        var sut = new ReportAnalyzer(new LevelAnalyzer());
        var report = new Report
        {
            Levels =
            [
                new(5),
                new(1), // -4
            ],
        };

        var result = sut.IsReportSafe(report);

        result.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalseForMoreThanOneOutOfRangeValueWithDampenerThresholdAtOne()
    {
        var sut = new ReportAnalyzer(new LevelAnalyzer());
        var report = new Report
        {
            Levels =
            {
                new Level(1),
                new Level(2),
                new Level(19), // 1st bad value
                new Level(3), // back on track
                new Level(4),
                new Level(19), // 2nd bad value
            },
        };

        var result = sut.IsReportSafe(report, useProblemDampener: true);

        result.Should().BeFalse();
    }

    [Fact]
    public void SkipFirstLevel()
    {
        var sut = new ReportAnalyzer(new LevelAnalyzer());
        var report = new Report
        {
            Levels =
            {
                new Level(1), // skip this and it's safe
                new Level(19),
                new Level(20),
            },
        };

        var result = sut.IsReportSafe(report, useProblemDampener: true);

        result.Should().BeTrue();
    }

    [Fact]
    public void SkipLastLevel()
    {
        var sut = new ReportAnalyzer(new LevelAnalyzer());
        var report = new Report
        {
            Levels =
            {
                new Level(1),
                new Level(2),
                new Level(19), // skip this and it's safe
            },
        };

        var result = sut.IsReportSafe(report, useProblemDampener: true);

        result.Should().BeTrue();
    }

    [Fact]
    public void SkipsMiddleLevel()
    {
        var sut = new ReportAnalyzer(new LevelAnalyzer());
        var report = new Report
        {
            Levels =
            {
                new Level(1),
                new Level(2),
                new Level(19), // skip this and it's safe
                new Level(3),
            },
        };

        var result = sut.IsReportSafe(report, useProblemDampener: true);

        result.Should().BeTrue();
    }
}
