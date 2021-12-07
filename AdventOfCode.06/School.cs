using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._06
{
    internal class School
    {
        private long[] fishs = new long[9];
        public School()
        {}

        internal void CreateSchool(string fishData)
        {
            this.fishs = new long[9];
            fishData.Split(',').ToList().ConvertAll(x => int.Parse(x))
                .GroupBy(x => x)
                .ToList()
                .ForEach(x => this.fishs[x.Key] = x.Count());
        }

        internal long CountOnDay(int days)
        {
            for (int i = 0; i < days; i++)
            {
                long[] newFish = new long[9];
                for (int j = 0; j < this.fishs.Length; j++)
                {
                    if (j == 0) { 
                        newFish[8] = this.fishs[j];
                        newFish[6] += this.fishs[j];
                    }
                    else newFish[j - 1] += this.fishs[j];
                }
                this.fishs = newFish;
            }
            return this.fishs.Sum();
        }
    }
}