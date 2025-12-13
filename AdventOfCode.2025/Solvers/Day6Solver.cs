using AdventOfCode2025.DataProviders;
using AdventOfCode2025.Models.Day6;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode2025.Solvers;

public class Day6Solver : IAoCSolver
{
    private readonly IDataProvider _dataProvider;

    public int Day => 6;

    public Day6Solver([FromKeyedServices(DataProviderKind.LineDelimited)] IDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public string Part1()
    {
        IEnumerable<string> data = _dataProvider.GetData(Day);
        var worksheetLines = data.Select(line =>
            line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries));
        IncorrectCephalopodWorksheet worksheet = new(worksheetLines);

        long sum = 0;
        for (int i = 0; i < worksheet.NumberOfColumns; i++)
        {
            sum += worksheet.GetColumnNumbers(i).Aggregate(worksheet.GetColumnOperator(i));
        }

        return sum.ToString();
    }

    public string Part2()
    {
        IEnumerable<string> data = _dataProvider.GetData(Day);
        CephalopodWorksheet worksheet = new(data);

        var problems = worksheet.GetProblems().ToArray();

        long result = problems.Sum(sp => sp.Solve());

        return result.ToString();
    }
}
