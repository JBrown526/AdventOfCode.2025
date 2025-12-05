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

        long accessible = grid.GetCoordinates()
            .Where(coordinate => grid[coordinate] == '@')
            .Select(coordinate => grid.GetAdjacentValues(coordinate))
            .Count(adjacent => adjacent.Count(value => value == '@') < 4);

        return accessible.ToString();
    }

    public string Part2()
    {
        IEnumerable<string> lines = _dataProvider.GetData(Day);
        Grid<char> grid = new(lines);

        long accessible = 0;
        long newlyAccessible = 0;
        do
        {
            newlyAccessible = 0;

            foreach (Coordinate coordinate in grid.GetCoordinates())
            {
                if (grid[coordinate] != '@')
                {
                    continue;
                }

                IEnumerable<char> adjacentValues = grid.GetAdjacentValues(coordinate);
                if (adjacentValues.Count(value => value == '@') < 4)
                {
                    grid[coordinate] = '.';
                    newlyAccessible++;
                }
            }

            accessible += newlyAccessible;
        } while (newlyAccessible > 0);

        return accessible.ToString();
    }
}
