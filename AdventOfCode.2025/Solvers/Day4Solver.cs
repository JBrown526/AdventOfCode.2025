using AdventOfCode2025.DataProviders;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode2025.Solvers;

public class Day4Solver : IAoCSolver
{
    private IDataProvider _dataProvider;

    public int Day => 4;

    public Day4Solver([FromKeyedServices(DataProviderKind.LineDelimited)] IDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public string Part1()
    {
        return "D4P1";
    }

    public string Part2()
    {
        return "D4P2";
    }
}

public class ForkliftAccess
{
    private byte access
}
