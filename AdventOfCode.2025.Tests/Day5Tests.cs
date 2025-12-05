using AdventOfCode2025.DataProviders;
using AdventOfCode2025.Models.Common;
using AdventOfCode2025.Solvers;
using FluentAssertions;
using Moq;
using Xunit.Abstractions;
using Xunit.Sdk;

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

    [Theory]
    [MemberData(nameof(GetDataForIdRangeMerge))]
    public void IdRangeMerge(TestCaseIdRangeMerge testCase)
    {
        IEnumerable<IdRange> result = testCase.Input.Merge();
        result.Should().BeEquivalentTo(testCase.Expected);
    }

    public static TheoryData<TestCaseIdRangeMerge> GetDataForIdRangeMerge()
    {
        return
        [
            new TestCaseIdRangeMerge
            {
                Description = "Single ID",
                Input = [new IdRange(1, 5)],
                Expected = [new IdRange(1, 5)],
            },
            new TestCaseIdRangeMerge
            {
                Description = "Overlapping range",
                Input = [new IdRange(1, 5), new IdRange(3, 8)],
                Expected = [new IdRange(1, 8)],
            },
            new TestCaseIdRangeMerge
            {
                Description = "Non-overlapping range",
                Input = [new IdRange(1, 5), new IdRange(8, 10)],
                Expected = [new IdRange(1, 5), new IdRange(8, 10)],
            },
            new TestCaseIdRangeMerge
            {
                Description = "Multiple overlapping ranges",
                Input = [new IdRange(1, 5), new IdRange(3, 8), new IdRange(7, 10)],
                Expected = [new IdRange(1, 10)],
            },
            new TestCaseIdRangeMerge
            {
                Description = "Multiple non-overlapping ranges",
                Input = [new IdRange(1, 5), new IdRange(8, 10), new IdRange(13, 17)],
                Expected = [new IdRange(1, 5), new IdRange(8, 10), new IdRange(13, 17)],
            },
        ];
    }

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
