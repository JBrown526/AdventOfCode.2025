using AdventOfCode2025.DataProviders;
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
        return "D6P1";
    }

    public string Part2()
    {
        return "D6P2";
    }
}
