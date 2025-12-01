namespace AdventOfCode2025.Solvers;

public readonly record struct Instruction(Direction Direction, int Value)
{
    public static Instruction Parse(string line)
    {
        Direction direction = line[0] switch
        {
            'L' => Direction.L,
            'R' => Direction.R,
            _ => throw new ArgumentOutOfRangeException(nameof(line), line, "Line should start with 'L' or 'R'"),
        };
        int value = int.Parse(line[1..]);
        return new Instruction(direction, value);
    }

    public int Move() => (int)Direction * Value;
}
