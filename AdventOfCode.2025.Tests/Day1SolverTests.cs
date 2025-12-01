using AdventOfCode2025.Solvers;
using FluentAssertions;
using Moq;

namespace AdventOfCode2025.Tests;

public class Day1SolverTests
{
    private readonly Mock<IFileProvider> _fileHelperMock = new();

    [Theory]
    [InlineData("0", "L1", "R2")]
    [InlineData("3", "L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82")]
    [InlineData("2", "R50", "R100")]
    public void Part1(string expected, params string[] turns)
    {
        _fileHelperMock.Setup(fh => fh.GetFile(It.IsAny<int>()))
            .Returns(turns);

        Day1Solver solver = new(_fileHelperMock.Object);

        solver.Part1().Should().Be(expected);
    }

    [Theory]
    [InlineData("0", "L1", "R2")]
    [InlineData("6", "L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82")]
    [InlineData("9", "L68", "L30", "R48", "L5", "R60", "L55", "L1", "L399", "R14", "L82")]
    public void Part2(string expected, params string[] turns)
    {
        _fileHelperMock.Setup(fh => fh.GetFile(It.IsAny<int>()))
            .Returns(turns);

        Day1Solver solver = new(_fileHelperMock.Object);

        solver.Part2().Should().Be(expected);
    }
}
