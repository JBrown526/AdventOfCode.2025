using AdventOfCode2025.DataProviders;
using AdventOfCode2025.Models.Day4;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace AdventOfCode2025.Solvers;

public class Day4Solver : IAoCSolver
{
    private readonly IDataProvider _dataProvider;

    public int Day => 4;

    public Day4Solver([FromKeyedServices(DataProviderKind.LineDelimited)] IDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public string Part1()
    {
        IEnumerable<string> lines = _dataProvider.GetData(Day);
        Grid<char> grid = new(lines);

        long accessible = 0;
        foreach (Coordinate coordinate in grid.GetCoordinates())
        {
            if (grid[coordinate] != '@')
            {
                continue;
            }

            IEnumerable<char> adjacentValues = grid.GetAdjacentValues(coordinate);
            if (adjacentValues.Count(value => value == '@') < 4)
            {
                accessible++;
            }
        }

        return accessible.ToString();
    }

    public string Part2()
    {
        return "D4P2";
    }
}
