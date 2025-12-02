namespace AdventOfCode2025.DataProviders;

public class LineBasedDataProvider : DataProviderBase
{
    public override IEnumerable<string> GetData(int day)
    {
        string path = GetFilePath(day);
        return File.ReadLines(path);
    }
}
