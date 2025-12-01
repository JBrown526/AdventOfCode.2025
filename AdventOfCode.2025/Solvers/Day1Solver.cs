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
        IEnumerable<string> lines = _fileProvider.GetFile(Day);
        IEnumerable<Instruction> instructions = lines.Select(Instruction.Parse);

        int zeroes = 0;
        int position = 50;
        foreach (Instruction instruction in instructions)
        {
            position += instruction.Direction * instruction.Value;
            if (position % 100 == 0)
            {
                zeroes++;
            }
        }

        return zeroes.ToString();
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
