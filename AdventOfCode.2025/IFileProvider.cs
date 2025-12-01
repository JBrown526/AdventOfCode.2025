namespace AdventOfCode2025;

public interface IFileProvider
{
    IEnumerable<string> GetFile(int day);
}
