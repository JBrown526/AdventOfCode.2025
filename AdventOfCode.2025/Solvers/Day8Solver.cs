using AdventOfCode2025.DataProviders;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode2025.Solvers;

public class Day8Solver : IAoCSolver
{
    private readonly IDataProvider _dataProvider;

    public Day8Solver([FromKeyedServices(DataProviderKind.LineDelimited)] IDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public int Day => 8;

    public string Part1()
    {
        throw new NotImplementedException();
    }

    public string Part2()
    {
        throw new NotImplementedException();
    }
}
