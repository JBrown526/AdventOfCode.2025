using AdventOfCode2025.Models.Common;

namespace AdventOfCode2025.Models.Day7;

public class Manifold
{
    private readonly Grid<char> _grid;

    public Manifold(Grid<char> grid)
    {
        _grid = grid;
    }

    public long CountSplits()
    {
        int width = _grid.Columns;
        char[] entryRow = _grid.GetRow(0).ToArray();

        var inputBeams = new bool[width];
        inputBeams[Array.IndexOf(entryRow, 'S')] = true;
        var outputBeams = new bool[width];

        long splits = 0;
        for (int i = 1; i < _grid.Rows; i++)
        {
            // copy over beams to the output in case there's no splitter
            Array.Copy(inputBeams, outputBeams, width);

            var row = _grid.GetRow(i).ToArray();

            int splitterIndex = Array.IndexOf(row, '^');
            while (splitterIndex != -1)
            {
                // if there's a beam coming in, split it in the output
                if (inputBeams[splitterIndex])
                {
                    splits++;
                    outputBeams[splitterIndex] = false;

                    if (splitterIndex > 0)
                    {
                        outputBeams[splitterIndex - 1] = true;
                    }

                    if (splitterIndex < width - 1)
                    {
                        outputBeams[splitterIndex + 1] = true;
                    }
                }

                // remove splitter and look for the next one
                row[splitterIndex] = '.';
                splitterIndex = Array.IndexOf(row, '^');
            }

            // make the output beams the next input
            Array.Copy(outputBeams, inputBeams, width);
        }

        return splits;
    }
}
