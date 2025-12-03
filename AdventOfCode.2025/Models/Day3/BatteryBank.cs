namespace AdventOfCode2025.Models.Day3;

public class BatteryBank
{
    private readonly char[] _batteries;

    public BatteryBank(string batteries)
    {
        _batteries = batteries.ToCharArray();
    }

    public string MaximiseJoltage(int activationCount)
    {
        char[] activated = new char[activationCount];
        Array.Fill(activated, '0');

        // TODO: re-use this logic for subsequent sizes?
        // Regular flow - find the largest initial value
        foreach (char joltage in _batteries[..^activationCount])
        {
            for (int i = 0; i < activated.Length; i++)
            {
                // Is this a new highest-order activation?
                if (TryUpdateActivated(activated, joltage, i))
                {
                    break;
                }

                // It could still be a lower order activation
                for (int j = i+1; j < activated.Length; j++)
                {
                    if (TryUpdateActivated(activated, joltage, j))
                    {
                        break;
                    }
                }
            }
        }

        // Ending Flow - check the remainder
        for (int i = _batteries.Length - activationCount; i < _batteries.Length; i++)
        {
            char joltage = _batteries[i];
            int activatedIndex = i - (_batteries.Length - activationCount);

            if (TryUpdateActivated(activated, joltage, activatedIndex))
            {
                // As we're dealing with the last of the batteries, we now can just take the remainder directly
                Array.Copy(_batteries, i, activated, activatedIndex, activated.Length - activatedIndex);
                break;
            }
        }

        return new string(activated);
    }

    private static bool TryUpdateActivated(char[] activated, char joltage, int index)
    {
        if (joltage > activated[index])
        {
            activated[index] = joltage;
            // Reset all subsequent values
            Array.Fill(activated, '0', index + 1, activated.Length - index - 1);
            return true;
        }

        return false;
    }
}
