using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode._07
{
    class Program
    {
        static void Main(string[] args)
        {
            var hPos = "16,1,2,0,4,2,7,1,2,14"
                .Split(',')
                .ToList()
                .ConvertAll(x => int.Parse(x))
                .OrderBy(o => o)
                .GroupBy(g => g)
                .ToList();
            var realPos = File.ReadAllText(@"C:\Users\kkalleru\source\repos\Personal\advent_of_code\AdventOfCode\AdventOfCode.07\input.txt")
                .Split(',')
                .ToList()
                .ConvertAll(x => int.Parse(x))
                .OrderBy(o => o)
                .GroupBy(g => g)
                .ToList();


            Console.WriteLine($"test (37) Fuel: {CalcFuel(hPos, out int testTarget)}");
            Console.WriteLine($"test (2) Pos: {testTarget}");
            Console.WriteLine($"testMegaburn Fuel: {CalcFuelBurn(hPos, out int testTargetBurn)}, position: {testTargetBurn}");
            Console.WriteLine($"real Fuel: {CalcFuel(realPos, out int realTarget)}");
            Console.WriteLine($"real Pos: {realTarget}");
            Console.WriteLine($"Megaburn Fuel: {CalcFuelBurn(realPos, out int realTargetBurn)}, position: {realTargetBurn}");
        }

        private static int CalcFuel(List<IGrouping<int, int>> positions, out int position)
        {
            int fuel = 0;
            position = 0;
            for (int i = positions.First().Key; i < positions.Last().Key; i++)
            {
                int acctualFuel = MoveToPosition(i, positions);
                if (fuel == 0 || acctualFuel < fuel) 
                { 
                    fuel = acctualFuel;
                    position = i;
                }
            }
            return fuel;
        }

        private static int MoveToPosition(int targetPosition, List<IGrouping<int, int>> positions)
        {
            int fuel = 0;
            foreach (var pos in positions)
            {
                if (pos.Key == targetPosition) continue;
                var range = pos.Key < targetPosition ? targetPosition - pos.Key : pos.Key - targetPosition;
                fuel += range * pos.Count();
            }
            return fuel;
        }

        private static int CalcFuelBurn(List<IGrouping<int, int>> positions, out int position)
        {
            int fuel = 0;
            position = 0;
            for (int i = positions.First().Key; i < positions.Last().Key; i++)
            {
                int acctualFuel = MoveToPositionBurn(i, positions);
                if (fuel == 0 || acctualFuel < fuel)
                {
                    fuel = acctualFuel;
                    position = i;
                }
            }
            return fuel;
        }

        private static int MoveToPositionBurn(int targetPosition, List<IGrouping<int, int>> positions)
        {
            int fuel = 0;
            foreach (var pos in positions)
            {
                if (pos.Key == targetPosition) continue;
                var range = pos.Key < targetPosition ? targetPosition - pos.Key : pos.Key - targetPosition;
                
                int start = 1;
                for (int i = 0; i < range; i++)
                {
                    fuel += start++ * pos.Count();
                }
            }
            return fuel;
        }
    }
}
