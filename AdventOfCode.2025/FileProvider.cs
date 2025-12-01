namespace AdventOfCode2025;

public class FileProvider : IFileProvider
{
    public IEnumerable<string> GetFile(int day)
    {
        return File.ReadLines(Path.Combine("inputs", $"day{day:N2}.txt"));
    }
}
