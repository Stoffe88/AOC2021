using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode._03
{
    class Program
    {
        private static Diagnostic diagnostic = new Diagnostic();
        static void Main(string[] args)
        {
            foreach (var line in File.ReadAllLines(@"C:\Users\kkalleru\source\repos\Personal\advent_of_code\AdventOfCode\AdventOfCode.03\input.txt"))
            {
                diagnostic.ReadValue(line);
            }

            Console.WriteLine($"Power consumtion is {diagnostic.CalculatePowerConsumption()}");
            Console.WriteLine($"Life support rating is {diagnostic.CalculateLifeSupportRating()}");
            Console.ReadKey();
        }
    }
}
