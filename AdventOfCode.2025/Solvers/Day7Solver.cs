using AdventOfCode2025.DataProviders;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode2025.Solvers;

public class Day7Solver : IAoCSolver
{
    private readonly IDataProvider _dataProvider;

    public int Day => 7;

    public Day7Solver([FromKeyedServices(DataProviderKind.LineDelimited)] IDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public string Part1()
    {
        return "D7P1";
    }

    public string Part2()
    {
        return "D7P2";
    }
}
