namespace AdventOfCode2025.DataProviders;

public interface IDataProvider
{
    IEnumerable<string> GetData(int day);
}

public abstract class DataProviderBase : IDataProvider
{
    public abstract IEnumerable<string> GetData(int day);

    protected static string GetFilePath(int day)
    {
        return Path.Combine("inputs", $"day{day:D2}.txt");
    }
}
