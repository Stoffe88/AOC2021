using System;
using System.IO;

namespace AdventOfCode.DayTwo
{
    class Program
    {
        private static Coordinate coordinate = new Coordinate();

        static void Main(string[] args)
        {
            foreach (string line in File.ReadAllLines(@"C:\Users\kkalleru\source\repos\Personal\advent_of_code\AdventOfCode\AdventOfCode.DayTwo\input.txt"))
            {
                coordinate.ExecuteInstruction(new MoveInstruction(instructions: line));
            };

            Console.WriteLine($"Value of horizontal value multiplied with depth value: {coordinate.GetMultipliedValue()}");
            Console.WriteLine($"Value of horizontal value multiplied with aimed depth value: {coordinate.GetAimedMultipliedValue()}");

            Console.ReadKey();
        }


    }
}
