using AdventOfCode2025.Models.Common;

namespace AdventOfCode2025.Models.Day6;

public class CephalopodWorksheet
{
    private readonly Grid<char> _worksheet;

    public CephalopodWorksheet(IEnumerable<IEnumerable<char>> worksheetLines)
    {
        _worksheet = new Grid<char>(worksheetLines);
    }

    public IEnumerable<CephalopodProblem> GetProblems()
    {
        char[] lastRow = _worksheet.GetRow(_worksheet.Rows - 1).ToArray();

        int height = _worksheet.Rows;
        int problemStartXPosition = 0;

        // The first column will always be the start of a problem, so can be skipped
        for (int i = 1; i < lastRow.Length; i++)
        {
            if (lastRow[i] == ' ')
            {
                continue;
            }

            Grid<char> problemSubGrid = _worksheet.GetSubGrid(
                new Coordinate(problemStartXPosition, 0),
                // This column is the start of the next problem, so move x back 2 to also skip the spacer
                new Coordinate(i - 2, height - 1));
            yield return new CephalopodProblem(problemSubGrid);

            problemStartXPosition = i;
        }

        // We'll have one problem remaining so special case its creation
        Grid<char> lastProblem = _worksheet.GetSubGrid(
            new Coordinate(problemStartXPosition, 0),
            new Coordinate(_worksheet.Columns - 1, height - 1));
        yield return new CephalopodProblem(lastProblem);
    }
}
