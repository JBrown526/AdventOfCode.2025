using AdventOfCode2025.DataProviders;
using AdventOfCode2025.Solvers;
using FluentAssertions;
using Moq;

namespace AdventOfCode2025.Tests;

public class Day4Tests
{
    private readonly Mock<IDataProvider> _dataProviderMock = new();

    [Theory]
    [InlineData("D4P1", "TODO")]
    public void Part1(string expected, params string[] inputs)
    {
        _dataProviderMock.Setup(dp => dp.GetData(3)).Returns(inputs);

        Day4Solver solver = new(_dataProviderMock.Object);

        solver.Part1().Should().Be(expected);
    }

    [Theory]
    [InlineData("D4P2", "TODO")]
    public void Part2(string expected, params string[] inputs)
    {
        _dataProviderMock.Setup(dp => dp.GetData(3)).Returns(inputs);

        Day4Solver solver = new(_dataProviderMock.Object);

        solver.Part2().Should().Be(expected);
    }
}
