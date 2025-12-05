using AdventOfCode2025.DataProviders;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode2025.Solvers;

public class Day5Solver : IAoCSolver
{
    private readonly IDataProvider _dataProvider;

    public Day5Solver([FromKeyedServices(DataProviderKind.LineDelimited)] IDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public int Day => 5;

    public string Part1()
    {
        return "D5P1";
    }

    public string Part2()
    {
        return "D5P2";
    }
}
