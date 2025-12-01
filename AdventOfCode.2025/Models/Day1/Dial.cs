using System.Diagnostics;

namespace AdventOfCode2025.Solvers;

[DebuggerDisplay("Position = {DialPosition}")]
public class Dial
{
    private int _value = 50;

    public int DialPosition
    {
        get
        {
            int mod = _value % 100;

            if (mod == 0)
            {
                return 0;
            }
            if (_value < 0)
            {
                return 100 + mod;
            }

            return mod;
        }
    }

    public Dial(int value = 50)
    {
        _value = value;
    }

    public void Move(Instruction instruction)
    {
        _value += instruction.Move();
    }
}
