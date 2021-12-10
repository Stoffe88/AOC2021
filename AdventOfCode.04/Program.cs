using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode._04
{
    class Program
    {
        private static BingoGame bingoGame = new BingoGame();
        static void Main(string[] args)
        {
            bingoGame.GameSetup(File.ReadAllText(@"C:\Users\kkalleru\source\repos\Personal\advent_of_code\AdventOfCode\AdventOfCode.04\input.txt"));

            List<BingoBoard> bingoBoards = bingoGame.Play();

            Console.WriteLine($"Winning board has {bingoBoards[0].points} points.");
            Console.WriteLine($"Last board has {bingoBoards[bingoBoards.Count-1].points} points.");
            Console.ReadKey();
        }
    }
}
