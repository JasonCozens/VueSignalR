using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Waiting4Rain.Games.TileGame;

/// <summary>
/// What can you do with console so it can be tested?
/// </summary>
namespace Waiting4Rain.ConsoleStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(9, 7);
            Console.CursorVisible = false;

            var board = new Board
            {
                new List<string>{ "A", "B", "C" },
                new List<string>{ "D", "E", "F" },
                new List<string>{ "G", "H", "_" },
            };

            while (true)
            {
                DisplayBoard(board);
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow) board.MoveTile("up");
                if (key == ConsoleKey.RightArrow) board.MoveTile("right");
                if (key == ConsoleKey.DownArrow) board.MoveTile("down");
                if (key == ConsoleKey.LeftArrow) board.MoveTile("left");
            }
        }

        private static void DisplayBoard(List<List<string>> board)
        {
            for (int row = 0; row < board.Count; row++)
            {
                for (int col = 0; col < board[0].Count; col++)
                {
                    Console.CursorTop = 1 + 2 * row;
                    Console.CursorLeft = 2 + 2 * col;
                    Console.Write(board[row][col]);
                }
            }
        }
    }
}
