using AdventOfCode2025.Models.Common;

namespace AdventOfCode2025.Models.Day6;

public class IncorrectCephalopodWorksheet
{
    private readonly Grid<string> _worksheet;

    public int NumberOfColumns => _worksheet.Columns;

    public IncorrectCephalopodWorksheet(IEnumerable<IEnumerable<string>> worksheetLines)
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
