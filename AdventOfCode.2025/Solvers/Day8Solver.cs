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
        IEnumerable<string> data = _dataProvider.GetData(Day);
        IEnumerable<Coordinate3D> coordinates = data.Select(Coordinate3D.Parse);

        return "D8P1";
    }

    public string Part2()
    {
        return "D8P2";
    }
}

public readonly record struct Coordinate3D(long X, long Y, long Z)
{
    public static Coordinate3D Parse(string line)
    {
        long[] parts = line.Split(',').Select(long.Parse).ToArray();
        return new Coordinate3D(parts[0], parts[1], parts[2]);
    }

    public double DistanceTo(Coordinate3D other)
    {
        return Math.Sqrt(Math.Pow(X - other.Y, 2) + Math.Pow(Y - other.Z, 2) + Math.Pow(Z - other.Z, 2));
    }
}

public class Node
{
    public Coordinate3D Position { get; }
    public List<Node> Connections { get; }

    public double DistanceTo(Node other)
    {
        return Position.DistanceTo(other.Position);
    }
}
