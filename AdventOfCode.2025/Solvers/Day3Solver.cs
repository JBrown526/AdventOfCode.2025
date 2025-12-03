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
        IEnumerable<string> data = _dataProvider.GetData(Day);

        int totalJoltage = 0;
        foreach (string line in data)
        {
            char highestFirst = '0';
            char highestSecond = '0';
            // Check all but the last digit, we'll do a special case check on that in case the last digit is largest
            foreach (char joltage in line[..^1])
            {
                // If the joltage is higher than the first digit, then we have a new high number
                if (joltage > highestFirst)
                {
                    highestFirst = joltage;
                    highestSecond = '0';
                    continue;
                }

                if (joltage > highestSecond)
                {
                    highestSecond = joltage;
                }
            }

            if (line[^1] > highestSecond)
            {
                highestSecond = line[^1];
            }

            totalJoltage += int.Parse(new string([highestFirst, highestSecond]));
        }

        return totalJoltage.ToString();
    }

    public string Part2()
    {
        return "D3P2";
    }
}
