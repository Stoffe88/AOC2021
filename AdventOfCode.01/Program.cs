using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode._01
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> depths = new LinkedList<int>();
            foreach (string line in File.ReadAllLines(@"C:\Users\kkalleru\source\repos\Personal\advent_of_code\AdventOfCode\AdventOfCode.01\input.txt"))
            {
                depths.AddLast(int.Parse(line));
            };
            
            int largerThanPrevious = 0;
            var currentNode = depths.First;
            while (currentNode != null)
            {
                if (currentNode.Previous != null
                    && currentNode.Value > currentNode.Previous.Value) largerThanPrevious++;
                currentNode = currentNode.Next;
            }

            int largerThanThreePrevious = 0;
            currentNode = depths.First;
            while (currentNode.Next.Next.Next != null)
            {
                int firstNumber = currentNode.Value + currentNode.Next.Value + currentNode.Next.Next.Value;
                int secondNumber = currentNode.Next.Value + currentNode.Next.Next.Value + currentNode.Next.Next.Next.Value;
                if (firstNumber < secondNumber) largerThanThreePrevious++;
                currentNode = currentNode.Next;
            }

            Console.WriteLine($"Larger than previous measurements: {largerThanPrevious}");
            Console.WriteLine($"Larger than three previous measurements: {largerThanThreePrevious}");
            Console.ReadKey();
        }
    }
}
