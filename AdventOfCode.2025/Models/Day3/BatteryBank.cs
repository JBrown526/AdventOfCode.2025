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
        int surplus = _batteries.Length - activationCount;
        Stack<char> activated = new(activationCount);

        foreach (char joltage in _batteries)
        {
            // If we still have to remove values, and the value on the top of the stack is smaller than the new value
            // then drop the value and keep the incoming one
            while (surplus > 0 && activated.Count > 0 && activated.Peek() < joltage)
            {
                activated.Pop();
                surplus--;
            }

            activated.Push(joltage);
        }

        // If we still have a surplus, drop the last values, they will by definition be smaller
        while (activated.Count > activationCount)
        {
            activated.Pop();
        }

        // The biggest numbers are on the bottom of the stack, so we need to reverse it
        return new string(activated.Reverse().ToArray());
    }
}
