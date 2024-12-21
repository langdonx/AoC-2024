using System.Linq;
using Day02.Model;

namespace Day02.Service;

public class ReportAnalyzer(ILevelAnalyzer levelAnalyzer) : IReportAnalyzer
{
    public bool IsReportSafe(Report report, bool useProblemDampener = false)
    {
        if (report.Levels.Count < 2)
        {
            return false;
        }

        var countDecreases = 0;
        var countIncreases = 0;

        for (var i = 0; i < report.Levels.Count - 1; i++)
        {
            countDecreases += levelAnalyzer.IsAcceptableDecrease(report.Levels[i], report.Levels[i + 1]) ? 1 : 0;
            countIncreases += levelAnalyzer.IsAcceptableIncrease(report.Levels[i], report.Levels[i + 1]) ? 1 : 0;
        }

        var isReportSafe = countDecreases == report.Levels.Count - 1 || countIncreases == report.Levels.Count - 1;

        if (isReportSafe == true)
        {
            // report is safe without dampener, yay
            return true;
        }

        if (useProblemDampener == true)
        {
            // giving up on trying to do a cute algorithm, too many annoying edge cases, brute force time
            for (var i = 0; i < report.Levels.Count; i++)
            {
                var levelsMinusOne = report.Levels.Select(l => l).ToList();
                levelsMinusOne.RemoveAt(i);

                var reportMinusOne = new Report
                {
                    Levels = levelsMinusOne,
                };

                // recurse, 
                var isReportMinusOneSafe = IsReportSafe(reportMinusOne, useProblemDampener: false);

                if (isReportMinusOneSafe == true)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
