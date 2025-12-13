using AdventOfCode2025.Models.Day4;

namespace AdventOfCode2025.Models.Day6;

public class CephalopodProblem
{
    private readonly Grid<char> _problem;

    public CephalopodProblem(Grid<char> problem)
    {
        _problem = problem;
    }

    public long Solve()
    {
        // operator will always be bottom left element
        char @operator = _problem[new Coordinate(0, _problem.Rows - 1)];
        Func<long, long, long> aggregationFunction = GetAggregationFunction(@operator);

        long[] numbers = new long[_problem.Columns];
        for (int i = _problem.Columns - 1; i >= 0; i--)
        {
            // skip the last row as it is the operator row
            IEnumerable<char> problemColumn = _problem.GetColumn(i).Take(_problem.Rows - 1);

            string numberString = string.Join("", problemColumn.Where(char.IsDigit));
            long number = long.Parse(numberString);
            numbers[i] = number;
        }

        return numbers.Aggregate(aggregationFunction);
    }

    private static Func<long, long, long> GetAggregationFunction(char @operator)
    {
        return @operator switch
        {
            '*' => (a, b) => a * b,
            '+' => (a, b) => a + b,
            _ => throw new InvalidOperationException("Invalid operator"),
        };
    }
}
