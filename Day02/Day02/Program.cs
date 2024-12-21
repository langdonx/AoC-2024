using System;
using System.Diagnostics;
using System.Linq;
using Day02.Service;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();
serviceCollection.AddTransient<IInputProvider, InputProvider>();
serviceCollection.AddTransient<ILevelAnalyzer, LevelAnalyzer>();
serviceCollection.AddTransient<IParserService, ParserService>();
serviceCollection.AddTransient<IReportAnalyzer, ReportAnalyzer>();
var serviceProvider = serviceCollection.BuildServiceProvider();

var _inputProvider = serviceProvider.GetRequiredService<IInputProvider>();
var _parserService = serviceProvider.GetRequiredService<IParserService>();
var _reportAnalyzer = serviceProvider.GetRequiredService<IReportAnalyzer>();

var puzzle = _parserService.ParseInput(_inputProvider.GetInput());

// part 1
var sw = Stopwatch.StartNew();
var numberOfSafeReports = puzzle.Reports
    .Where(r => _reportAnalyzer.IsReportSafe(r) == true)
    .Count();

Console.WriteLine($"Part 1: {numberOfSafeReports} in {sw.ElapsedMilliseconds}ms");

// part 2
sw.Restart();
var numberOfSafeReportsUsingProblemDampener = puzzle.Reports
    .Where(r =>
    {
        var result = _reportAnalyzer.IsReportSafe(r, useProblemDampener: true);
        return result;
    })
    .Count();

Console.WriteLine($"Parse 2: {numberOfSafeReportsUsingProblemDampener} in {sw.ElapsedMilliseconds}ms");
