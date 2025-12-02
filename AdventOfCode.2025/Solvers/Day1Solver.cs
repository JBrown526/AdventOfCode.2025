using AdventOfCode2025.Models.Day1;

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
            if (dial.Position == 0)
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
            int oldDialPosition = dial.Position;
            dial.Move(instruction);
            int newDialPosition = dial.Position;

            int fullTurns = instruction.Value / 100;

            if (instruction.Direction is Direction.R)
            {
                zeroes += fullTurns;

                // Check if we wrapped around
                if (newDialPosition < oldDialPosition)
                {
                    zeroes++;
                }

                continue;
            }

            if (instruction.Direction is Direction.L)
            {
                // If we're at zero, only need to count full turns
                if (oldDialPosition == 0)
                {
                    zeroes += fullTurns;
                    continue;
                }

                // We would wrap around
                if (instruction.Value > oldDialPosition)
                {
                    zeroes += ((instruction.Value - oldDialPosition - 1) / 100) + 1;
                }

                if (newDialPosition == 0)
                {
                    zeroes++;
                }
            }
        }

        return zeroes.ToString();
    }
}
