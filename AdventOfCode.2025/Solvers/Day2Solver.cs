using AdventOfCode2025.DataProviders;
using AdventOfCode2025.Models.Common;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;

namespace AdventOfCode2025.Solvers;

public partial class Day2Solver : IAoCSolver
{
    private readonly IDataProvider _dataProvider;

    public int Day => 2;

    public Day2Solver([FromKeyedServices(DataProviderKind.CommaSeparatedLine)] IDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public string Part1()
    {
        IEnumerable<string> data = _dataProvider.GetData(Day);
        IEnumerable<IdRange> idRanges = data.Select(IdRange.Parse);

        long idSum = 0;
        foreach (long id in idRanges.SelectMany(range => range.GetIds()))
        {
            string idString = id.ToString();
            if (idString[(idString.Length / 2)..] == idString[..(idString.Length / 2)])
            {
                idSum += id;
            }
        }

        return idSum.ToString();
    }

    public string Part2()
    {
        IEnumerable<string> data = _dataProvider.GetData(Day);
        IEnumerable<IdRange> idRanges = data.Select(IdRange.Parse);

        long idSum = 0;
        foreach (long id in idRanges.SelectMany(range => range.GetIds()))
        {
            string idString = id.ToString();
            if (RepeatedSequenceRegex.IsMatch(idString))
            {
                idSum += id;
            }
        }

        return idSum.ToString();
    }

    // We capture a group and then match that group as many times as possible, consuming the entire string
    [GeneratedRegex(@"^(\d+)\1+$")]
    private static partial Regex RepeatedSequenceRegex { get; }
}
