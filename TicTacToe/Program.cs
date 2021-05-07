using System;

namespace TicTacToe
{
    class Program
    {
        public Grid _grid;

        static void Main(string[] args)
        {
            var game = new Game();
            game.CreateGrid(3, 3, 2);

            // TODO: Dependency injection - create players and grid outside of game and pass them in

            game.Player1.Icon = "X";
            game.Player2.Icon = "O";
            bool gameWon = false;
            bool player1Turn = true;
            int rowPlayed;
            int colPlayed;

            game.PrintGrid();
            game.PrintCounts();

            bool spotTaken = false;

            while (!gameWon)
            {
                var player = player1Turn ? 1 : 2;

                do
                {
                    spotTaken = false;
                    Console.WriteLine($"Player {player}, select the row index to play: ");
                    rowPlayed = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"Player {player}, select the column index to play: ");
                    colPlayed = Convert.ToInt32(Console.ReadLine());

                    if (game.Grid.SpotTaken(rowPlayed, colPlayed))
                    {
                        Console.WriteLine("This spot is taken!");
                        spotTaken = true;
                    }
                } while (spotTaken);

                switch (player1Turn)
                {
                    case true:
                        game.MakePlay(0, rowPlayed, colPlayed);
                        break;
                    case false:
                        game.MakePlay(1, rowPlayed, colPlayed);
                        break;
                    default:
                        break;
                }

                game.PrintGrid();
                game.PrintCounts();

                // check if move resulted in a win
                if (game.GameWon())
                {
                    // if resulted in a win, announce win and end game
                    Console.WriteLine($"Player {player} won the game!");
                    gameWon = true;
                    break;
                }

                // TODO: Check if no more moves can be made (tie/draw)
                // if no win yet, go to next player's turn
                player1Turn = !player1Turn;
            }

            Console.Write("Game Over!");

            // TODO: Add Play again? once game is over
        }
    }
}