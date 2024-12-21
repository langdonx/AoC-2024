using Day02.Model;

namespace Day02.Service;

public interface ILevelAnalyzer
{
    bool IsAcceptableDecrease(Level level1, Level level2);
    bool IsAcceptableIncrease(Level level1, Level level2);
    public bool IsSafeChange(bool increaseExpected, Level level1, Level level2);
}
