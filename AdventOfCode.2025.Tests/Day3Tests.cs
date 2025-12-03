using AdventOfCode2025.DataProviders;
using AdventOfCode2025.Solvers;
using FluentAssertions;
using Moq;

namespace AdventOfCode2025.Tests;

public class Day3Tests
{
    private readonly Mock<IDataProvider> _dataProviderMock = new();

    [Theory]
    [InlineData("98", "987654321111111")]
    [InlineData("89", "811111111111119")]
    [InlineData("78", "234234234234278")]
    [InlineData("92", "818181911112111")]
    [InlineData("357", "987654321111111", "811111111111119", "234234234234278", "818181911112111")]
    public void Part1(string expected, params string[] inputs)
    {
        _dataProviderMock.Setup(dp => dp.GetData(3)).Returns(inputs);

        Day3Solver solver = new(_dataProviderMock.Object);

        solver.Part1().Should().Be(expected);
    }

    [Theory]
    [InlineData("TODO", "987654321111111")]
    [InlineData("TODO", "811111111111119")]
    [InlineData("TODO", "234234234234278")]
    [InlineData("TODO", "818181911112111")]
    [InlineData("TODO", "987654321111111", "811111111111119", "234234234234278", "818181911112111")]
    public void Part2(string expected, params string[] inputs)
    {
        _dataProviderMock.Setup(dp => dp.GetData(3)).Returns(inputs);

        Day3Solver solver = new(_dataProviderMock.Object);

        solver.Part2().Should().Be(expected);
    }
}
