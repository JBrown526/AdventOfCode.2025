namespace AdventOfCode2025.DataProviders;

public class LineOnlyDataProvider : DataProviderBase
{
    public override IEnumerable<string> GetData(int day)
    {
        string path = GetFilePath(day);
        return File.ReadLines(path);
    }
}
