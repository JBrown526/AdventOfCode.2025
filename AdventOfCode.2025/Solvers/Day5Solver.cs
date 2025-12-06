using AdventOfCode2025.DataProviders;
using AdventOfCode2025.Models.Common;
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
        string[] data = _dataProvider.GetData(Day).ToArray();
        // id ranges are separated from IDs by an empty string
        int splitIndex = data.IndexOf("");

        IEnumerable<IdRange> parsedRanges = data[..splitIndex].Select(IdRange.Parse);
        IEnumerable<long> checkIds = data[(splitIndex + 1)..].Select(long.Parse);

        List<IdRange> coalescedRanges = parsedRanges.Merge().ToList();

        long inRange = 0;
        foreach (long checkId in checkIds)
        {
            if (coalescedRanges.Any(range => range.Contains(checkId)))
            {
                inRange += 1;
            }
        }

        return inRange.ToString();
    }

    public string Part2()
    {
        string[] data = _dataProvider.GetData(Day).ToArray();
        // id ranges are separated from IDs by an empty string
        int splitIndex = data.IndexOf("");

        IEnumerable<IdRange> ranges = data[..splitIndex].Select(IdRange.Parse).Merge();

        return ranges.SelectMany(r => r.GetIds()).LongCount().ToString();
    }
}
