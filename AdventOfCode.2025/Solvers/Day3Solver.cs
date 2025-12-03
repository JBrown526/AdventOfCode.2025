using AdventOfCode2025.DataProviders;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode2025.Solvers;

public class Day3Solver : IAoCSolver
{
    private readonly IDataProvider _dataProvider;

    public int Day => 3;

    public Day3Solver([FromKeyedServices(DataProviderKind.LineDelimited)] IDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public string Part1()
    {
        return "D3P1";
    }

    public string Part2()
    {
        return "D3P2";
    }
}
