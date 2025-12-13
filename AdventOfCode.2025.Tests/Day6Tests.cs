using AdventOfCode2025.DataProviders;
using AdventOfCode2025.Models.Common;
using AdventOfCode2025.Solvers;
using FluentAssertions;
using Moq;
using Xunit.Abstractions;

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
    [InlineData("3263827", "123 328  51 64 ", " 45 64  387 23 ", "  6 98  215 314", "*   +   *   +  ")]
    [InlineData("19142939947", "6612 1   135 7   466 771 324", "1526 22   37 67  435 483 533", "583  538  68 787 299 951 918", "922  279  25 566 26  668  96", "+    *   *   *   *   +   +  ")]
    public void Part2(string expected, params string[] input)
    {
        _dataProviderMock.Setup(dp => dp.GetData(6)).Returns(input);

        Day6Solver solver = new(_dataProviderMock.Object);

        solver.Part2().Should().Be(expected);
    }

    [Fact]
    public void GridTranspose()
    {
        Grid<char> original = new(["12", "34"]);
        Grid<char> expected = new(["31", "42"]);

        Grid<char> transposed = Grid<char>.CreateTransposed(original);

        transposed.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(GetDataForGetSubGrid))]
    public void GridGetSubGrid(TestCaseGetSubGrid testCase)
    {
        testCase.Input.GetSubGrid(testCase.TopLeft, testCase.BottomRight).Should().BeEquivalentTo(testCase.Expected);
    }

    public static TheoryData<TestCaseGetSubGrid> GetDataForGetSubGrid() =>
    [
        new()
        {
            Description = "Get subgrid from top left corner",
            Input = new Grid<char>(["0123", "4567", "89ab", "cdef"]),
            Expected = new Grid<char>(["01", "45"]),
            TopLeft = new Coordinate(0, 0),
            BottomRight = new Coordinate(1, 1),
        },
        new()
        {
            Description = "Get subgrid from middle",
            Input = new Grid<char>(["0123", "4567", "89ab", "cdef"]),
            Expected = new Grid<char>(["56", "9a"]),
            TopLeft = new Coordinate(1, 1),
            BottomRight = new Coordinate(2, 2),
        },
        new()
        {
            Description = "Get column",
            Input = new Grid<char>(["0123", "4567", "89ab", "cdef"]),
            Expected = new Grid<char>(["1", "5", "9", "d"]),
            TopLeft = new Coordinate(1, 0),
            BottomRight = new Coordinate(1, 3),
        },
        new()
        {
            Description = "Get row",
            Input = new Grid<char>(["0123", "4567", "89ab", "cdef"]),
            Expected = new Grid<char>(["4567"]),
            TopLeft = new Coordinate(0, 1),
            BottomRight = new Coordinate(3, 1),
        }
    ];

    public class TestCaseGetSubGrid : IXunitSerializable
    {
        public required string Description { get; init; }
        public required Grid<char> Input { get; init; }
        public required Grid<char> Expected { get; init; }
        public required Coordinate TopLeft { get; init; }
        public required Coordinate BottomRight { get; init; }

        public void Deserialize(IXunitSerializationInfo info)
        {
            info.GetValue<string>(nameof(Description));
            info.GetValue<Grid<char>>(nameof(Input));
            info.GetValue<Grid<char>>(nameof(Expected));
            info.GetValue<Coordinate>(nameof(TopLeft));
            info.GetValue<Coordinate>(nameof(BottomRight));
        }

        public void Serialize(IXunitSerializationInfo info)
        {
            info.AddValue(nameof(Description), Description);
            info.AddValue(nameof(Input), Input);
            info.AddValue(nameof(Expected), Expected);
            info.AddValue(nameof(TopLeft), TopLeft);
            info.AddValue(nameof(BottomRight), BottomRight);
        }
    }
}
