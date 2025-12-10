using AdventOfCode2025.DataProviders;
using AdventOfCode2025.Models.Day4;
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
        IncorrectCephalapodWorksheet worksheet = new(worksheetLines);

        long sum = 0;
        for (int i = 0; i < worksheet.NumberOfColumns; i++)
        {
            sum += worksheet.GetColumnNumbers(i).Aggregate(worksheet.GetColumnOperator(i));
        }

        return sum.ToString();
    }

    public string Part2()
    {
        return "D6P2";
    }
}

public class IncorrectCephalapodWorksheet
{
    private readonly Grid<string> _worksheet;

    public int NumberOfColumns => _worksheet.Columns;

    public IncorrectCephalapodWorksheet(IEnumerable<IEnumerable<string>> worksheetLines)
    {
        _worksheet = new Grid<string>(worksheetLines);
    }

    public IEnumerable<long> GetColumnNumbers(int columnIndex)
    {
        return _worksheet.GetColumn(columnIndex).Take(_worksheet.Rows - 1).Select(long.Parse);
    }

    public Func<long, long, long> GetColumnOperator(int columnIndex)
    {
        return _worksheet.GetColumn(columnIndex).Last() switch
        {
            "*" => (a, b) => a * b,
            "+" => (a, b) => a + b,
            _ => throw new InvalidOperationException("Invalid operator")
        };
    }
}
