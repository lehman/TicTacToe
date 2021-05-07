using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Game
    {
        public Grid Grid;
        public List<List<int>> Player_Counts;
        public Player Player1 = new Player();
        public Player Player2 = new Player();
        private int WinCount;

        public void CreateGrid(int rows, int cols, int numPlayers)
        {
            Grid = new Grid(rows, cols);
            Player_Counts = new List<List<int>>();
            for (int i = 0; i < numPlayers; i++)
            {
                Player_Counts.Add(new List<int>(new int[rows + cols + 2]));
            }
            WinCount = rows;
        }

        public void MakePlay(int playerIndex, int chosenRow, int chosenCol)
        {
            // TODO: make sure space to play is not already played on

            // update grid with move
            switch (playerIndex)
            {
                case 0:
                    Grid.grid[chosenRow][chosenCol].state = CellState.Player1Selected;
                    break;
                case 1:
                    Grid.grid[chosenRow][chosenCol].state = CellState.Player2Selected;
                    break;
                default:
                    break;
            }

            UpdateCounts(playerIndex, chosenRow, chosenCol);
        }

        public void UpdateCounts(int playerIndex, int chosenRow, int chosenCol)
        {
            // update row count
            Player_Counts[playerIndex][chosenRow]++;

            // update column count
            Player_Counts[playerIndex][chosenCol + Grid.grid_rows]++;

            // update diagonal count(s)
            if (chosenRow == chosenCol)
            {
                // on left to right, top to bottom diagonal
                Player_Counts[playerIndex][Grid.grid_rows + Grid.grid_cols]++;

                if (chosenRow + chosenCol + 1 == Grid.grid_rows)
                {
                    // on right to left, top to bottom diagonal
                    Player_Counts[playerIndex][Grid.grid_rows + Grid.grid_cols + 1]++;
                }
            }
        }

        public bool GameWon()
        {
            foreach (List<int> p in Player_Counts)
            {
                foreach (int count in p)
                {
                    if (count >= WinCount)
                    {
                        return true;
                    }
                }
            }

            return false;

            //if (Player_Counts[player][chosenRow] >= WinCount
            //    || Player_Counts[player][chosenRow + chosenCol * Grid.grid_rows] >= WinCount
            //    || Player_Counts[player][Grid.grid_rows * Grid.grid_cols] >= WinCount
            //    || Player_Counts[player][Grid.grid_rows * Grid.grid_cols + 1] >= WinCount)
            //{
            //    GameWon = true;
            //}
        }

        public void PrintGrid()
        {
            Console.WriteLine("\nPlaying Field:");
            for (int i = 0; i < Grid.grid_rows; i++)
            {
                for (int j = 0; j < Grid.grid_cols; j++)
                {
                    switch (Grid.grid[i][j].state)
                    {
                        case CellState.Empty:
                            Console.Write("-");
                            break;
                        case CellState.Player1Selected:
                            Console.Write(Player1.Icon);
                            break;
                        case CellState.Player2Selected:
                            Console.Write(Player2.Icon);
                            break;
                        default:
                            break;
                    }
                    //Console.Write(Grid.grid[i][j].state);
                }
                Console.WriteLine();
            }
        }

        public void PrintCounts()
        {
            Console.WriteLine("\nCounts:");
            for (int i = 0; i < Player_Counts.Count; i++)
            {
                Console.Write($"\nPlayer {i+1}: ");
                foreach (int count in Player_Counts[i])
                {
                    Console.Write($"{count} ");
                }
            }
            Console.WriteLine("\n");
        }
    }
}
