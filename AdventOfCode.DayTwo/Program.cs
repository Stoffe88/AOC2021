using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.DayTwo
{
    class Program
    {
        private static Coordinate coordinate = new Coordinate();
        private static Coordinate aimedCoordinate = new Coordinate();

        static void Main(string[] args)
        {
            List<MoveInstruction> moveInstructions = new List<MoveInstruction>();

            foreach (string line in File.ReadAllLines(@"C:\Users\kkalleru\source\repos\Personal\advent_of_code\AdventOfCode\AdventOfCode.DayTwo\input.txt"))
            {
                moveInstructions.Add(new MoveInstruction(instructions: line));
            };

            foreach (MoveInstruction instruction in moveInstructions)
            {
                coordinate.ExecuteInstruction(instruction);
                aimedCoordinate.ExecuteAimedInstruction(instruction);
            }

            Console.WriteLine($"Value of horizontal value multiplied with depth value: {coordinate.GetMultipliedValue()}");
            Console.WriteLine($"Value of horizontal value multiplied with depth value for aimed coordinate: {aimedCoordinate.GetMultipliedValue()}");

            Coordinate testCoordinate = new Coordinate();

            List<MoveInstruction> instructions = new List<MoveInstruction>
            {
                new MoveInstruction("forward 5"),
                new MoveInstruction("down 5"),
                new MoveInstruction("forward 8"),
                new MoveInstruction("up 3"),
                new MoveInstruction("down 8"),
                new MoveInstruction("forward 2")
            };
            foreach (var item in instructions)
            {
                testCoordinate.ExecuteAimedInstruction(item);
            }

            Console.WriteLine($"Value of test data: {testCoordinate.GetMultipliedValue()}");
            Console.ReadKey();
        }


    }
}
