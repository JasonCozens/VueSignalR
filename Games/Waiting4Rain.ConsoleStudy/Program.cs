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
            Console.SetWindowSize(16, 14);
            Console.CursorVisible = false;

            var board = new Board
            {
                new List<string>{ "A", "B", "C", "D", "E" },
                new List<string>{ "F", "G", "H", "I", "J" },
                new List<string>{ "K", "L", "M", "N", "O" },
                new List<string>{ "P", "Q", "R", "S", "T" },
                new List<string>{ "U", "V", "W", "X", "_" }
            };

            DisplayBoard(board);
            Task.Delay(3000).Wait();
            Shuffle(board, 2500);

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

        private static void DisplayBoard(Board board)
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

        private static void Shuffle(Board board, int shuffleCount)
        {
            var map = new Dictionary<int, string>
            {
                { 0, "left" },
                { 1, "up" },
                { 2, "right" },
                { 3, "down" }
            };

            var random = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < shuffleCount; i++)
            {
                board.MoveTile(map[random.Next(0, 4)]);
                DisplayBoard(board);
                //Task.Delay(5).Wait();
            }
        }

        private static void M()
        {

        }
    }
}
