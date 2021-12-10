using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode._08
{
    class Program
    {
        private static List<SevenSegmentDisplay> display = new List<SevenSegmentDisplay>();
        static void Main(string[] args)
        {
            foreach (var line in File.ReadAllLines(@"C:\Users\kkalleru\source\repos\Personal\advent_of_code\AdventOfCode\AdventOfCode.08\input.txt"))
            {
                display.Add(new SevenSegmentDisplay(line));
            }

            int count = 0;
            int sum = 0;
            foreach (var display in display)
            {
                count += display.GetOnes();
                count += display.GetFours();
                count += display.GetSevens();
                count += display.GetEights();
                sum += display.ReadDisplay();
            }
            Console.WriteLine($"Unique numbercount is {count}");
            Console.WriteLine($"Sum of all displays are {sum}");
        }
    }
}
