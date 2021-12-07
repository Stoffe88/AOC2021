using System;
using System.IO;

namespace AdventOfCode._06
{
    class Program
    {
        internal static School school = new School();
        static void Main(string[] args)
        {
            school.CreateSchool(File.ReadAllText(@"C:\Users\kkalleru\source\repos\Personal\advent_of_code\AdventOfCode\AdventOfCode.06\input.txt"));
            Console.WriteLine($"On day 80 the school would be {school.CountOnDay(80)} fish big.");
            
            school.CreateSchool(File.ReadAllText(@"C:\Users\kkalleru\source\repos\Personal\advent_of_code\AdventOfCode\AdventOfCode.06\input.txt"));
            Console.WriteLine($"On day 256 the school would be {school.CountOnDay(256)} fish big.");
            
            Console.ReadKey();
        }
    }
}
