using AdventOfCode2025.DataProviders;
using AdventOfCode2025.Solvers;
using FluentAssertions;
using Moq;

namespace AdventOfCode2025.Tests;

public class Day7Tests
{
    private readonly Mock<IDataProvider> _dataProviderMock = new();

    [Theory]
    [InlineData("21",
        ".......S.......",
        "...............",
        ".......^.......",
        "...............",
        "......^.^......",
        "...............",
        ".....^.^.^.....",
        "...............",
        "....^.^...^....",
        "...............",
        "...^.^...^.^...",
        "...............",
        "..^...^.....^..",
        "...............",
        ".^.^.^.^.^...^.",
        "...............")]
    public void Part1(string expected, params string[] input)
    {
        _dataProviderMock.Setup(dp => dp.GetData(7)).Returns(input);

        Day7Solver solver = new(_dataProviderMock.Object);

        solver.Part1().Should().Be(expected);
    }

    [Theory]
    [InlineData("40",
        ".......S.......",
        "...............",
        ".......^.......",
        "...............",
        "......^.^......",
        "...............",
        ".....^.^.^.....",
        "...............",
        "....^.^...^....",
        "...............",
        "...^.^...^.^...",
        "...............",
        "..^...^.....^..",
        "...............",
        ".^.^.^.^.^...^.",
        "...............")]
    public void Part2(string expected, params string[] input)
    {
        _dataProviderMock.Setup(dp => dp.GetData(7)).Returns(input);

        Day7Solver solver = new(_dataProviderMock.Object);

        solver.Part2().Should().Be(expected);
    }
}
