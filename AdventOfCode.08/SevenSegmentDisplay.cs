using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._08
{
    internal class SevenSegmentDisplay
    {
        private char[] displayWires = new char[7];
        private string rawData;
        private List<string> displayData;
        private List<string> numbers;


        public SevenSegmentDisplay(string line)
        {
            var data = line.Split('|').ToList();
            this.rawData = data[0];
            this.displayData = data[0].Split(' ').OrderBy(x => x.Length).Where(x => x.Length > 0).ToList();
            this.numbers = data[1].Split(' ').ToList();
            DecodeWires();
        }

        private void DecodeWires()
        {
            this.displayWires = this.displayData[9].ToCharArray();

            var letters = this.rawData.GroupBy(x => x).ToList();

            foreach (var letter in letters)
            {
                if (!char.IsLetter(letter.Key)) continue;
                if (letter.Count() == 8)
                {
                    if (this.displayData[0].Contains(letter.Key)) this.displayWires[2] = letter.Key;
                    else this.displayWires[0] = letter.Key;
                }
                if (letter.Count() == 7)
                {
                    if (this.displayData[2].Contains(letter.Key)) this.displayWires[3] = letter.Key;
                    else this.displayWires[6] = letter.Key;
                }
                if (letter.Count() == 6) this.displayWires[1] = letter.Key;
                if (letter.Count() == 4) this.displayWires[4] = letter.Key;
                if (letter.Count() == 9) this.displayWires[5] = letter.Key;
            }
        }

        internal int ReadDisplay()
        {
            StringBuilder sb = new StringBuilder();
            
            foreach (var number in this.numbers)
            {
                if (number.Length == 0) continue;
                if (number.Length == 2) sb.Append("1");
                else if (number.Length == 4) sb.Append("4");
                else if (number.Length == 3) sb.Append("7");
                else if (number.Length == 7) sb.Append("8");
                else if (number.Length == 6)
                {
                    if (!number.Contains(this.displayWires[3].ToString())) sb.Append("0");
                    else if (!number.Contains(this.displayWires[2].ToString())) sb.Append("6");
                    else sb.Append("9");
                }
                else
                {
                    if (!number.Contains(this.displayWires[1].ToString()) && !number.Contains(this.displayWires[5].ToString())) sb.Append("2");
                    else if (!number.Contains(this.displayWires[1].ToString()) && !number.Contains(this.displayWires[4].ToString())) sb.Append("3");
                    else sb.Append("5");
                }
            }
            return int.Parse(sb.ToString());
        }

        internal int GetOnes()
        {
            int rv = 0;
            foreach (var number in numbers)
            {
                if (number.Length == 2) rv++;
            }
            return rv;
        }

        internal int GetFours()
        {
            int rv = 0;
            foreach (var number in numbers)
            {
                if (number.Length == 4) rv++;
            }
            return rv;
        }

        internal int GetSevens()
        {
            int rv = 0;
            foreach (var number in numbers)
            {
                if (number.Length == 3) rv++;
            }
            return rv;
        }

        internal int GetEights()
        {
            int rv = 0;
            foreach (var number in numbers)
            {
                if (number.Length == 7) rv++;
            }
            return rv;
        }
    }
}