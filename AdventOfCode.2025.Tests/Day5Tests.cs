using AdventOfCode2025.DataProviders;
using AdventOfCode2025.Models.Common;
using AdventOfCode2025.Solvers;
using FluentAssertions;
using Moq;
using Xunit.Abstractions;
using Xunit.Sdk;
using Range = Moq.Range;

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
    [InlineData("14", "3-5", "10-14", "16-20", "12-18", "", "1", "5", "8", "11", "17", "32")]
    public void Part2(string expected, params string[] turns)
    {
        _dataProviderMock.Setup(fh => fh.GetData(5)).Returns(turns);

        Day5Solver solver = new(_dataProviderMock.Object);

        solver.Part2().Should().Be(expected);
    }

    [Theory]
    [InlineData(false, "1-3", 0)]
    [InlineData(true, "1-3", 1)]
    [InlineData(true, "1-3", 2)]
    [InlineData(true, "1-3", 3)]
    [InlineData(false, "1-3", 4)]
    public void IdRangeContains(bool expected, string rangeString, long searchValue)
    {
        IdRange range = IdRange.Parse(rangeString);

        range.Contains(searchValue).Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(GetDataForIdRangeMerge))]
    public void IdRangeMerge(TestCaseIdRangeMerge testCase)
    {
        IEnumerable<IdRange> result = testCase.Input.Merge();
        result.Should().BeEquivalentTo(testCase.Expected);
    }

    public static TheoryData<TestCaseIdRangeMerge> GetDataForIdRangeMerge() =>
    [
        new()
        {
            Description = "Single ID",
            Input = [new IdRange(1, 5)],
            Expected = [new IdRange(1, 5)],
        },
        new()
        {
            Description = "Overlapping range",
            Input = [new IdRange(1, 5), new IdRange(3, 8)],
            Expected = [new IdRange(1, 8)],
        },
        new()
        {
            Description = "Non-overlapping range",
            Input = [new IdRange(1, 5), new IdRange(8, 10)],
            Expected = [new IdRange(1, 5), new IdRange(8, 10)],
        },
        new()
        {
            Description = "Multiple overlapping ranges",
            Input = [new IdRange(1, 5), new IdRange(3, 8), new IdRange(7, 10)],
            Expected = [new IdRange(1, 10)],
        },
        new()
        {
            Description = "Multiple non-overlapping ranges",
            Input = [new IdRange(1, 5), new IdRange(8, 10), new IdRange(13, 17)],
            Expected = [new IdRange(1, 5), new IdRange(8, 10), new IdRange(13, 17)],
        },
        new()
        {
            Description = "Mixed ranges",
            Input = [new IdRange(1, 2), new IdRange(2, 5), new IdRange(6, 7), new IdRange(7, 11), new IdRange(15, 20)],
            Expected = [new IdRange(1, 5), new IdRange(6, 11), new IdRange(15, 20)]
        },
        new()
        {
            Description = "Shrinking range",
            Input = [new IdRange(1, 10), new IdRange(4, 6), new IdRange(8, 11)],
            Expected = [new IdRange(1, 11)]
        }
    ];

    public class TestCaseIdRangeMerge : IXunitSerializable
    {
        public required string Description { get; init; }
        public required IEnumerable<IdRange> Input { get; init; }
        public required IEnumerable<IdRange> Expected { get; init; }

        public void Deserialize(IXunitSerializationInfo info)
        {
            info.GetValue<string>(nameof(Description));
            info.GetValue<IEnumerable<IdRange>>(nameof(Input));
            info.GetValue<IEnumerable<IdRange>>(nameof(Expected));
        }

        public void Serialize(IXunitSerializationInfo info)
        {
            info.AddValue(nameof(Description), Description);
            info.AddValue(nameof(Input), Input);
            info.AddValue(nameof(Expected), Expected);
        }
    }
}
