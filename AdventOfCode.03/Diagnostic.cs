using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode._03
{
    internal class Diagnostic
    {
        private List<string> diagnosticData = new List<string>();
        private int gammaRate = 0;
        private int epsilonRate = 0;
        private int oxygenGeneratorRating = 0;
        private int CO2ScrubberRating = 0;

        public Diagnostic() {}

        internal void ReadValue(string line)
        {
            diagnosticData.Add(line);
        }

        internal int CalculatePowerConsumption()
        {
            StringBuilder sbGamma = new StringBuilder();
            StringBuilder sbEpsilon = new StringBuilder();

            List<int> bits = new List<int>();
            foreach (var item in diagnosticData[0])
            {
                bits.Add(0);
            }

            for (int i = 0; i < diagnosticData.Count-1; i++)
            {
                diagnosticData.ForEach(x =>
                {
                    for (int i = 0; i < x.Length -1; i++)
                    {
                        bits[i] += int.Parse(x[i].ToString()) > 0 ? 1 : -1;
                    }
                });
            }
            bits.ForEach(x =>
            {
                if (x > 0)
                {
                    sbGamma.Append("1");
                    sbEpsilon.Append("0");
                } else
                {
                    sbGamma.Append("0");
                    sbEpsilon.Append("1");

                }
            });
            this.gammaRate = Convert.ToInt32(sbGamma.ToString(), 2);
            this.epsilonRate = Convert.ToInt32(sbEpsilon.ToString(), 2);

            return this.gammaRate * this.epsilonRate;
        }

        internal object CalculateLifeSupportRating()
        {
            CalculateOxygenGeneratorRating();
            CalculateCO2ScrubberRating();

            return this.CO2ScrubberRating * this.oxygenGeneratorRating;
        }

        private int FindRating(int position, List<string> ratings, bool keepLarger)
        {
            List<string> larger = new List<string>();
            List<string> lower = new List<string>();

            for (int i = 0; i < ratings.Count; i++)
            {
                if (int.Parse(ratings[i][position].ToString()) > 0) larger.Add(ratings[i]);
                else lower.Add(ratings[i]);
            }

            List<string> keep = new List<string>();
            if (larger.Count == lower.Count) keep = keepLarger ? larger : lower;
            else if (keepLarger) keep = larger.Count > lower.Count ? larger : lower;
            else keep = larger.Count < lower.Count ? larger : lower;

            return keep.Count <= 1 ? Convert.ToInt32(keep[0], 2) : FindRating(position+1, keep, keepLarger);
        }
        private void CalculateCO2ScrubberRating()
        {
            this.CO2ScrubberRating = FindRating(0, diagnosticData, false);
        }

        private void CalculateOxygenGeneratorRating()
        {
            this.oxygenGeneratorRating = FindRating(0, diagnosticData, true);
        }
    }
}