using AdventOfCode2025.DataProviders;
using AdventOfCode2025.Models.Day1;
using AdventOfCode2025.Solvers;
using FluentAssertions;
using Moq;

namespace AdventOfCode2025.Tests;

public class Day1SolverTests
{
    private readonly Mock<IDataProvider> _fileHelperMock = new();

    [Theory]
    [InlineData("0", "L1", "R2")]
    [InlineData("3", "L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82")]
    [InlineData("2", "R50", "R100")]
    public void Part1(string expected, params string[] turns)
    {
        _fileHelperMock.Setup(fh => fh.GetData(It.IsAny<int>()))
            .Returns(turns);

        Day1Solver solver = new(_fileHelperMock.Object);

        solver.Part1().Should().Be(expected);
    }

    [Theory]
    [InlineData("0", "L1", "R2")]
    [InlineData("6", "L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82")]
    [InlineData("9", "L68", "L30", "R48", "L5", "R60", "L55", "L1", "L399", "R14", "L82")]
    [InlineData("21", "L50", "L1000", "R1000")]
    [InlineData("21", "R50", "R1000", "L1000")]
    [InlineData("1", "L50")]
    [InlineData("1", "R50")]
    public void Part2(string expected, params string[] turns)
    {
        _fileHelperMock.Setup(fh => fh.GetData(It.IsAny<int>()))
            .Returns(turns);

        Day1Solver solver = new(_fileHelperMock.Object);

        solver.Part2().Should().Be(expected);
    }

    [Theory]
    [InlineData(50, 82, "L68")]
    [InlineData(-18, 52, "L30")]
    [InlineData(-48, 0, "R48")]
    [InlineData(0, 95, "L5")]
    [InlineData(-5, 55, "R60")]
    [InlineData(55, 0, "L55")]
    [InlineData(0, 99, "L1")]
    [InlineData(-1, 0, "L99")]
    [InlineData(-100, 14, "R14")]
    [InlineData(-86, 32, "L82")]
    [InlineData(100, 5, "R5")]
    [InlineData(100, 0, "R500")]
    [InlineData(100, 0, "L500")]
    public void DialTests(int startValue, int expectedPosition, string instructionString)
    {
        Dial dial = new(startValue);
        Instruction instruction = Instruction.Parse(instructionString);

        dial.Move(instruction);

        dial.Position.Should().Be(expectedPosition);
    }
}
