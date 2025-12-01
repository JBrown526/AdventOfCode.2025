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
        Dial dial = new();
        foreach (Instruction instruction in instructions)
        {
            dial.Move(instruction);
            if (dial.DialPosition == 0)
            {
                zeroes++;
            }
        }

        return zeroes.ToString();
    }

    public string Part2()
    {
        IEnumerable<string> lines = _fileProvider.GetFile(Day);
        IEnumerable<Instruction> instructions = lines.Select(Instruction.Parse);

        int zeroes = 0;
        Dial dial = new();
        foreach (Instruction instruction in instructions)
        {
            int oldDialPosition = dial.DialPosition;
            dial.Move(instruction);
            int newDialPosition = dial.DialPosition;

            Console.WriteLine("Position: {0}, Zeroes: {1}", dial.DialPosition, zeroes);

            // Number of full turns
            zeroes += instruction.Value / 100;

            if (oldDialPosition == 0)
            {
                continue;
            }

            // If we turn right and the dial position is less than the old one, then we've passed 0
            if (instruction.Direction is Direction.R && newDialPosition < oldDialPosition)
            {
                zeroes++;
            }

            // If we turn left and the dial position is greater than the old one, then we've passed 0
            if (instruction.Direction is Direction.L && newDialPosition > oldDialPosition)
            {
                zeroes++;
            }
        }

        return zeroes.ToString();
    }
}
