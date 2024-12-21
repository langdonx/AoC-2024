using Day02.Model;

namespace Day02.Service;

public class LevelAnalyzer : ILevelAnalyzer
{
    private static bool IsWithinRange(int difference) => difference > 0 && difference < 4;

    public bool IsAcceptableDecrease(Level level1, Level level2)
    {
        var difference = level1.Value - level2.Value;
        return IsWithinRange(difference);
    }

    public bool IsAcceptableIncrease(Level level1, Level level2)
    {
        var difference = level2.Value - level1.Value;
        return IsWithinRange(difference);
    }

    public bool IsSafeChange(bool increaseExpected, Level level1, Level level2)
    {
        return increaseExpected switch
        {
            true => IsAcceptableIncrease(level1, level2),
            false => IsAcceptableDecrease(level1, level2),
        };
    }
}
