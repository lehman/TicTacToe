using System.Collections.Generic;

namespace TicTacToe
{
    public class Grid
    {
        public int grid_rows { get; }
        public int grid_cols { get; }
        public List<List<Cell>> grid;

        public Grid(int rows, int cols)
        {
            grid_rows = rows;
            grid_cols = cols;
            grid = new List<List<Cell>>();

            for (int i = 0; i < rows; i++)
            {
                grid.Add(new List<Cell>());
                for (int j = 0; j < cols; j++)
                {
                    grid[i].Add(new Cell());
                }
            }
        }

        public bool SpotTaken(int row, int col)
        {
            return grid[row - 1][col - 1].state != CellState.Empty;
        }
    }
}
