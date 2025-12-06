using AdventOfCode2025.DataProviders;
using AdventOfCode2025.Solvers;
using FluentAssertions;
using Moq;

namespace AdventOfCode2025.Tests;

public class Day6Tests
{
    private readonly Mock<IDataProvider> _dataProviderMock = new();

    [Theory]
    [InlineData("4277556", "123 328  51 64 ", " 45 64  387 23 ", "  6 98  215 314", "*   +   *   +  ")]
    public void Part1(string expected, params string[] input)
    {
        _dataProviderMock.Setup(dp => dp.GetData(6)).Returns(input);

        Day6Solver solver = new(_dataProviderMock.Object);

        solver.Part1().Should().Be(expected);
    }

    [Theory]
    [InlineData("4277556", "123 328  51 64 ", " 45 64  387 23 ", "  6 98  215 314", "*   +   *   +  ")]
    public void Part2(string expected, params string[] input)
    {
        _dataProviderMock.Setup(dp => dp.GetData(6)).Returns(input);

        Day6Solver solver = new(_dataProviderMock.Object);

        solver.Part2().Should().Be(expected);
    }
}
