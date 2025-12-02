using AdventOfCode2025.DataProviders;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode2025.Solvers;

public class Day2Solver : IAoCSolver
{
    private readonly IDataProvider _dataProvider;

    public int Day => 2;

    public Day2Solver([FromKeyedServices(DataProviderKind.CommaSeparatedLine)] IDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public string Part1()
    {
        return "D2P1";
    }

    public string Part2()
    {
        return "D2P2";
    }
}
