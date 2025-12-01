namespace AdventOfCode2025;

public class FileProvider : IFileProvider
{
    public IEnumerable<string> GetFile(int day)
    {
        string path = Path.Combine("AdventOfCode.2025", "inputs", $"day{day:D2}.txt");
        return File.ReadLines(path);
    }
}
