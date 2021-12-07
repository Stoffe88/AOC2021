using System.Linq;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;

namespace AdventOfCode._04
{
    internal class BingoGame
    {
        private List<int> bingoNumbers = new List<int>();
        private List<BingoBoard> bingoBoards = new List<BingoBoard>();
        private int[][] bingoCombos = new int[12][] {
            new int[] {0, 1, 2, 3, 4},
            new int[] {5, 6, 7, 8, 9 },
            new int[] { 10, 11, 12, 13, 14 },
            new int[] { 15, 16, 17, 18, 19 },
            new int[] { 20, 21, 22, 23, 24 },
            new int[] { 0, 5, 10, 15, 20 },
            new int[] { 1, 6, 11, 16, 21 },
            new int[] { 2, 7, 12, 17, 22 },
            new int[] { 3, 8, 13, 18, 23 },
            new int[] { 4, 9, 14, 19, 24 },
            new int[] { 0, 6, 12, 18, 24 },
            new int[] { 4, 8, 12, 16, 20 }
        };
        public BingoGame()
        {}

        internal List<BingoBoard> Play()
        {
            List<BingoBoard> rv = new List<BingoBoard>();
            foreach (int number in this.bingoNumbers)
            {
                foreach (BingoBoard board in bingoBoards)
                {
                    board.DotNumber(number);
                    if (HasBingo(board))
                    {
                        board.CalculatePoints(number);
                        rv.Add(board);
                    }
                }
                foreach (BingoBoard board in rv)
                {
                    if (bingoBoards.Contains(board)) bingoBoards.Remove(board);
                }
            }
            return rv;
        }

        internal void GameSetup(string gameData)
        {
            string[] data = gameData.Split("\n\n");
            SetupNumbers(data.First());
            SetupBoards(data.Skip(1).ToArray());
        }

        private void SetupBoards(string[] data)
        {
            bingoBoards.RemoveRange(0, bingoBoards.Count);
            foreach (string boardData in data)
            {
                this.bingoBoards.Add(new BingoBoard(boardData));
            }
        }

        private void SetupNumbers(string numbers)
        {
            this.bingoNumbers.RemoveRange(0, this.bingoNumbers.Count);
            var nums = numbers.Split(',');
            foreach (var num in nums)
            {
                this.bingoNumbers.Add(int.Parse(num));
            }
        }
        
        private bool HasBingo(BingoBoard board)
        {
            foreach (var combo in bingoCombos)
            {
                if (board.dottedNumbers[combo[0]]
                    && board.dottedNumbers[combo[1]]
                    && board.dottedNumbers[combo[2]]
                    && board.dottedNumbers[combo[3]]
                    && board.dottedNumbers[combo[4]]) return true;
            }
            return false;
        }

    }

    internal class BingoBoard
    {
        internal int[] numbers = new int[25];
        internal bool[] dottedNumbers = new bool[25];
        internal int points = 0;
        public BingoBoard(string board)
        {
            while (board.Contains("\n"))
            {
                board = Regex.Replace(board, @"\r\n?|\n", " "); 
            }
            var numbers = board.Split(' ').ToList();
            while (numbers.Contains(""))
            {
                numbers.Remove("");
            }
            //for (int i = 0; i < this.numbers.Length; i++)
            //{
                this.numbers = numbers.ConvertAll<int>(x => int.Parse(x)).ToArray();
                //try
                //{
                //    int.TryParse(numbers[i], out this.numbers[i]);
                //}
                //catch (Exception)
                //{
                //    int.TryParse(numbers[i++], out this.numbers[i]);
                //    i++;// this.numbers[i] = int.Parse(numbers[i]);

                //}
            //}
        }

        internal int CalculatePoints(int bingoNumber)
        {
            int sum = 0;
            for (int i = 0; i < this.numbers.Length; i++)
            {
                sum += this.dottedNumbers[i] ? 0 : this.numbers[i];
            }
            this.points = sum * bingoNumber;
            return this.points;
        }

        internal void DotNumber(int numberToDot)
        {
            if (numbers.Contains(numberToDot))
            {
                dottedNumbers[Array.IndexOf(numbers, numberToDot)] = true;
            }
        }
    }
}