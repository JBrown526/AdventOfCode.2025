using AdventOfCode2025.DataProviders;
using AdventOfCode2025.Models.Day2;
using AdventOfCode2025.Solvers;
using FluentAssertions;
using Moq;

namespace AdventOfCode2025.Tests;

public class Day2Tests
{
    private readonly Mock<IDataProvider> _dataProviderMock = new();

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
    [InlineData("1-2", 1L, 2L)]
    [InlineData("11-22", 11L, 12L, 13L, 14L, 15L, 16L, 17L, 18L, 19L, 20L, 21L, 22L)]
    public void IdRangeGetIds(string input, params long[] expected)
    {
        IdRange result = IdRange.Parse(input);
        result.GetIds().Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData("1227775554", "11-22", "95-115", "998-1012", "1188511880-1188511890", "222220-222224",
        "1698522-1698528", "446443-446449", "38593856-38593862", "565653-565659", "824824821-824824827",
        "2121212118-2121212124")]
    public void Part1(string expected, params string[] inputs)
    {
        _dataProviderMock.Setup(dp => dp.GetData(2)).Returns(inputs);

        Day2Solver solver = new(_dataProviderMock.Object);

        solver.Part1().Should().Be(expected);
    }

    [Theory]
    [InlineData("33", "11-22")]
    [InlineData("2121212121", "2121212118-2121212124")]
    [InlineData("4174379265", "11-22", "95-115", "998-1012", "1188511880-1188511890", "222220-222224",
        "1698522-1698528", "446443-446449", "38593856-38593862", "565653-565659", "824824821-824824827",
        "2121212118-2121212124")]
    public void Part2(string expected, params string[] inputs)
    {
        _dataProviderMock.Setup(dp => dp.GetData(2)).Returns(inputs);

        Day2Solver solver = new(_dataProviderMock.Object);

        solver.Part2().Should().Be(expected);
    }
}
