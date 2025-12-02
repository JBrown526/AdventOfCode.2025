namespace AdventOfCode2025.DataProviders;

public class CommaSeparatedLineDataProvider : DataProviderBase
{
    public override IEnumerable<string> GetData(int day)
    {
        string path = GetFilePath(day);
        string text = File.ReadAllText(path);
        return text.Split(',', StringSplitOptions.TrimEntries);
    }
}
