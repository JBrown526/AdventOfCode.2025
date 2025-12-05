using AdventOfCode2025.DataProviders;
using AdventOfCode2025.Solvers;
using FluentAssertions;
using Moq;

namespace AdventOfCode2025.Tests;

public class Day5Tests
{
    private readonly Mock<IDataProvider> _dataProviderMock = new();

    [Theory]
    [InlineData("3", "3-5", "10-14", "16-20", "12-18", "", "1", "5", "8", "11", "17", "32")]
    public void Part1(string expected, params string[] turns)
    {
        _dataProviderMock.Setup(fh => fh.GetData(5)).Returns(turns);

        Day5Solver solver = new(_dataProviderMock.Object);

        solver.Part1().Should().Be(expected);
    }

    [Theory]
    [InlineData("", "3-5", "10-14", "16-20", "12-18", "", "1", "5", "8", "11", "17", "32")]
    public void Part2(string expected, params string[] turns)
    {
        _dataProviderMock.Setup(fh => fh.GetData(5)).Returns(turns);

        Day5Solver solver = new(_dataProviderMock.Object);

        solver.Part2().Should().Be(expected);
    }
}
