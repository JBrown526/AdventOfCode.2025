using AdventOfCode2025.Solvers;
using FluentAssertions;

namespace AdventOfCode2025.Tests;

public class Day2Tests
{
    [Theory]
    [InlineData("1-2", 1, 2)]
    [InlineData("11-22", 11, 22)]
    public void IdRangeParsing(string input, long firstId, long lastId)
    {
        IdRange result = IdRange.Parse(input);

        result.FirstId.Should().Be(firstId);
        result.LastId.Should().Be(lastId);
    }

    [Theory]
    [InlineData("1-2", 1, 2)]
    [InlineData("11-22", 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22)]
    public void IdRangeGetIds(string input, params long[] expected)
    {
        IdRange result = IdRange.Parse(input);
        result.GetIds().Should().BeEquivalentTo(expected);
    }
}
