using Day02.Model;

namespace Day02.Service;

public interface IReportAnalyzer
{
    bool IsReportSafe(Report report, bool useProblemDampener = false);
}
