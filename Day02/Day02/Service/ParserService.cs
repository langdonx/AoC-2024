using System;
using System.Linq;
using Day02.Model;

namespace Day02.Service;

public class ParserService : IParserService
{
    public Puzzle ParseInput(string s)
    {
        var reports = (s ?? "")
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(line =>
            {
                var levels = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(l => new Level(int.Parse(l)))
                    .ToList();

                return new Report
                {
                    Levels = levels,
                };
            })
            .ToList();

        return new Puzzle
        {
            Reports = reports,
        };
    }
}
