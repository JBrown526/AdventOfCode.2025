using AdventOfCode2025.DataProviders;
using AdventOfCode2025.Models.Day4;
using AdventOfCode2025.Solvers;
using FluentAssertions;
using Moq;

namespace AdventOfCode2025.Tests;

public class Day4Tests
{
    private readonly Mock<IDataProvider> _dataProviderMock = new();

    [Theory]
    [InlineData("0", "..", "..")]
    [InlineData("1", "@.", "..")]
    [InlineData("2", "@@", "..")]
    [InlineData("2", "@.", "@.")]
    [InlineData("2", "@.", ".@")]
    [InlineData("3", "@@", "@.")]
    [InlineData("3", "@@", ".@")]
    [InlineData("3", "@.", "@@")]
    [InlineData("4", "@@", "@@")]
    [InlineData("0", "...", "...", "...")]
    [InlineData("1", "@..", "...", "...")]
    [InlineData("2", "@@.", "...", "...")]
    [InlineData("2", "@.@", "...", "...")]
    [InlineData("2", "@..", "@..", "...")]
    [InlineData("2", "@..", ".@.", "...")]
    [InlineData("2", "@..", "..@", "...")]
    [InlineData("2", "@..", "...", "@..")]
    [InlineData("2", "@..", "...", ".@.")]
    [InlineData("2", "@..", "...", "..@")]
    [InlineData("3", "@@@", "...", "...")]
    [InlineData("3", "@@.", "@..", "...")]
    [InlineData("3", "@@.", ".@.", "...")]
    [InlineData("3", "@@.", "..@", "...")]
    [InlineData("3", "@@.", "...", "@..")]
    [InlineData("3", "@@.", "...", ".@.")]
    [InlineData("3", "@@.", "...", "..@")]
    [InlineData("13", "..@@.@@@@.", "@@@.@.@.@@", "@@@@@.@.@@", "@.@@@@..@.", "@@.@@@@.@@", ".@@@@@@@.@", ".@.@.@.@@@",
        "@.@@@.@@@@", ".@@@@@@@@.", "@.@.@@@.@.")]
    public void Part1(string expected, params string[] inputs)
    {
        _dataProviderMock.Setup(dp => dp.GetData(4)).Returns(inputs);

        Day4Solver solver = new(_dataProviderMock.Object);

        solver.Part1().Should().Be(expected);
    }

    [Theory]
    [InlineData("0", "..", "..")]
    [InlineData("1", "@.", "..")]
    [InlineData("2", "@@", "..")]
    [InlineData("2", "@.", "@.")]
    [InlineData("2", "@.", ".@")]
    [InlineData("3", "@@", "@.")]
    [InlineData("3", "@@", ".@")]
    [InlineData("3", "@.", "@@")]
    [InlineData("4", "@@", "@@")]
    [InlineData("D4P2", "..@@.@@@@.", "@@@.@.@.@@", "@@@@@.@.@@", "@.@@@@..@.", "@@.@@@@.@@", ".@@@@@@@.@",
        ".@.@.@.@@@",
        "@.@@@.@@@@", ".@@@@@@@@.", "@.@.@@@.@.")]
    public void Part2(string expected, params string[] inputs)
    {
        _dataProviderMock.Setup(dp => dp.GetData(4)).Returns(inputs);

        Day4Solver solver = new(_dataProviderMock.Object);

        solver.Part2().Should().Be(expected);
    }

    [Theory]
    [InlineData(0, 0, '0', "01", "23")]
    [InlineData(1, 0, '1', "01", "23")]
    [InlineData(0, 1, '2', "01", "23")]
    [InlineData(1, 1, '3', "01", "23")]
    public void GridIndexerTests(int x, int y, char expected, params string[] gridLines)
    {
        Grid<char> grid = new(gridLines);

        grid[new Coordinate(x, y)].Should().Be(expected);
    }

    [Theory]
    [InlineData(1, 2, "..")]
    [InlineData(2, 1, ".", ".")]
    public void GridPropertyTests(int expectedRows, int expectedColumns, params string[] gridLines)
    {
        Grid<char> grid = new(gridLines);

        grid.Columns.Should().Be(expectedColumns);
        grid.Rows.Should().Be(expectedRows);
    }

    [Theory]
    [InlineData(0, 0, "2", "1234")]
    [InlineData(1, 0, "13", "1234")]
    [InlineData(2, 0, "24", "1234")]
    [InlineData(3, 0, "3", "1234")]
    [InlineData(0, 0, "234", "12", "34")]
    [InlineData(1, 0, "134", "12", "34")]
    [InlineData(0, 1, "124", "12", "34")]
    [InlineData(1, 1, "123", "12", "34")]
    [InlineData(0, 0, "245", "123", "456", "789")]
    [InlineData(0, 1, "12578", "123", "456", "789")]
    [InlineData(0, 2, "458", "123", "456", "789")]
    [InlineData(1, 0, "13456", "123", "456", "789")]
    [InlineData(1, 1, "12346789", "123", "456", "789")]
    [InlineData(1, 2, "45679", "123", "456", "789")]
    [InlineData(2, 0, "256", "123", "456", "789")]
    [InlineData(2, 1, "23589", "123", "456", "789")]
    [InlineData(2, 2, "568", "123", "456", "789")]
    public void GridGetAdjacentTest(int x, int y, string expected, params string[] gridLines)
    {
        Grid<char> grid = new(gridLines);

        IEnumerable<char> result = grid.GetAdjacentValues(new Coordinate(x, y));
        new string(result.ToArray()).Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData("1234", "1234")]
    [InlineData("1234", "12", "34")]
    public void GridEnumerate(string expected, params string[] gridLines)
    {
        Grid<char> grid = new(gridLines);

        grid.ToArray<char>().Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void GridCoordinatesEnumerate()
    {
        Grid<char> grid = new(["123", "456"]);

        IEnumerable<Coordinate> result = grid.GetCoordinates();

        result.Should().BeEquivalentTo([
            new Coordinate(0, 0), new Coordinate(1, 0), new Coordinate(2, 0),
            new Coordinate(0, 1), new Coordinate(1, 1), new Coordinate(2, 1),
        ]);
    }
}
