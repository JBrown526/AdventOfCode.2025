namespace AdventOfCode2025.Solvers;

public class Day1Solver : IAoCSolver
{
    private readonly IFileProvider _fileProvider;

    public int Day => 1;

    public Day1Solver(IFileProvider fileProvider)
    {
        _fileProvider = fileProvider;
    }

    public string Part1()
    {
        return "D1P1";
    }

    public string Part2()
    {
        return "D1P2";
    }

    private record struct Instruction(int Direction, int Value)
    {
        public static Instruction Parse(string line)
        {
            int direction = line[0] switch
            {
                'L' => -1,
                'R' => 1,
                _ => throw new ArgumentOutOfRangeException(nameof(line), line, "Line should start with 'L' or 'R'"),
            };
            int value = int.Parse(line[1..]);
            return new Instruction(direction, value);
        }
    }
}
