namespace AdventOfCode2025.Models.Day2;

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
}
