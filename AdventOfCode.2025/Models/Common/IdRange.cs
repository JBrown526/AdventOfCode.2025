namespace AdventOfCode2025.Models.Common;

public readonly record struct IdRange(long FirstId, long LastId)
{
    public static IdRange Parse(string input)
    {
        string[] parts = input.Split('-', 2, StringSplitOptions.TrimEntries);
        return new IdRange(long.Parse(parts[0]), long.Parse(parts[1]));
    }

    public IEnumerable<long> GetIds()
    {
        for (long id = FirstId; id <= LastId; id++)
        {
            yield return id;
        }
    }

    public bool Contains(long id)
    {
        return id >= FirstId && id <= LastId;
    }
}

public static class IdRangeExtensions
{
    public static IEnumerable<IdRange> Merge(this IEnumerable<IdRange> idRanges)
    {
        List<IdRange> orderedRanges = idRanges.OrderBy(idRange => idRange.FirstId).ToList();

        long first = orderedRanges[0].FirstId;
        long last = orderedRanges[0].LastId;

        foreach (IdRange idRange in orderedRanges.Skip(1))
        {
            if (last < idRange.FirstId)
            {
                yield return new IdRange(first, last);
                first = idRange.FirstId;
            }

            if (last <= idRange.LastId)
            {
                last = idRange.LastId;
            }
        }

        // Return the remaining range
        yield return new IdRange(first, last);
    }
}
