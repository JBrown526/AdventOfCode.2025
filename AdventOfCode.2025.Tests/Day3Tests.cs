using AdventOfCode2025.DataProviders;
using AdventOfCode2025.Models.Day3;
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
    [InlineData("987654321111", "987654321111111")]
    [InlineData("811111111119", "811111111111119")]
    [InlineData("434234234278", "234234234234278")]
    [InlineData("888911112111", "818181911112111")]
    [InlineData("3121910778619", "987654321111111", "811111111111119", "234234234234278", "818181911112111")]
    public void Part2(string expected, params string[] inputs)
    {
        _dataProviderMock.Setup(dp => dp.GetData(3)).Returns(inputs);

        Day3Solver solver = new(_dataProviderMock.Object);

        solver.Part2().Should().Be(expected);
    }

    [Theory]
    [InlineData("119", 1, "9")]
    [InlineData("119", 2, "19")]
    [InlineData("987654321111111", 2, "98")]
    [InlineData("811111111111119", 2, "89")]
    [InlineData("234234234234278", 2, "78")]
    [InlineData("818181911112111", 2, "92")]
    [InlineData("987654321111111", 12, "987654321111")]
    [InlineData("811111111111119", 12, "811111111119")]
    [InlineData("234234234234278", 12, "434234234278")]
    [InlineData("818181911112111", 12, "888911112111")]
    public void BatteryBankTests(string batteries, int activationCount, string expected)
    {
        BatteryBank bank = new(batteries);

        string result = bank.MaximiseJoltage(activationCount);

        result.Should().Be(expected);
    }
}
