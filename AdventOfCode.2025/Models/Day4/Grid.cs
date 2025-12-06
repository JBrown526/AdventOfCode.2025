using System.Collections;

namespace AdventOfCode2025.Models.Day4;

public class Grid<T> : IEnumerable<T>
{
    private readonly T[][] _grid;

    public int Columns => _grid[0].Length;

    // We expect the grid to always have the same number of rows
    public int Rows => _grid.Length;

    public Grid(IEnumerable<IEnumerable<T>> elements)
    {
        _grid = elements.Select(line => line.ToArray()).ToArray();
    }

    /// <summary>
    /// Index into the grid, starting from the top left corner.
    /// </summary>
    /// <param name="coordinate">The cell coordinate.</param>
    public T this[Coordinate coordinate]
    {
        get => _grid[coordinate.Y][coordinate.X];
        set => _grid[coordinate.Y][coordinate.X] = value;
    }

    public static Grid<T> CreateTransposed(Grid<T> grid)
    {
        var transposedGrid = new T[grid.Columns][];

        for (int i = 0; i < grid.Rows; i++)
        {
            for (int j = 0; j < grid.Columns; j++)
            {
                // ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
                transposedGrid[j] ??= new T[grid.Rows];
                transposedGrid[j][i] = grid._grid[i][j];
            }
        }

        return new Grid<T>(transposedGrid);
    }

    /// <summary>
    /// Get the values of the adjacent cells to this one.
    /// </summary>
    public IEnumerable<T> GetAdjacentValues(Coordinate cell)
    {
        for (int yModifier = -1; yModifier <= 1; yModifier++)
        {
            for (int xModifier = -1; xModifier <= 1; xModifier++)
            {
                Coordinate adjacentCell = new(cell.X + xModifier, cell.Y + yModifier);

                // If x or y is off the grid, skip them. Also skip if we are on the cell itself
                if (adjacentCell.IsOutOfBounds(0, Columns, 0, Rows) || (xModifier == 0 && yModifier == 0))
                {
                    continue;
                }

                yield return this[adjacentCell];
            }
        }
    }

    public IEnumerable<Coordinate> GetCoordinates()
    {
        for (int y = 0; y < Rows; y++)
        {
            for (int x = 0; x < Columns; x++)
            {
                yield return new Coordinate(x, y);
            }
        }
    }

    public IEnumerable<T> GetRow(int row) => _grid[row];
    public IEnumerable<T> GetColumn(int column) => _grid.Select(line => line[column]);

    public IEnumerator<T> GetEnumerator()
    {
        return _grid.SelectMany(line => line).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
