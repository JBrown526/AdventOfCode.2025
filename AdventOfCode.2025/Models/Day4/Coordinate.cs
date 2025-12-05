namespace AdventOfCode2025.Models.Day4;

public readonly record struct Coordinate(int X, int Y)
{
    public bool IsOutOfBounds(int minX, int maxX, int minY, int maxY)
    {
        return X < minX || X >= maxX || Y < minY || Y >= maxY;
    }
}
