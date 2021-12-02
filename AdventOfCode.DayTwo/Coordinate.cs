using System;

namespace AdventOfCode.DayTwo
{
    public class Coordinate
    {
        private int horizontal;
        private int depth;
        private int aim;

        public Coordinate(int horizontal, int depth)
        {
            this.horizontal = horizontal;
            this.depth = depth;
            this.aim = 0;
        }
        public Coordinate()
        {
            this.horizontal = 0;
            this.depth = 0;
            this.aim = 0;
        }

        internal void ExecuteInstruction(MoveInstruction instruction)
        {
            switch (instruction.GetDirection())
            {
                case "forward":
                    this.horizontal += instruction.GetDirectionLenght();
                    break;
                case "up":
                    this.depth -= instruction.GetDirectionLenght();
                    break;
                case "down":
                    this.depth += instruction.GetDirectionLenght();
                    break;
                default:
                    break;
            }
        }

        internal void ExecuteAimedInstruction(MoveInstruction instruction)
        {
            switch (instruction.GetDirection())
            {
                case "forward":
                    this.horizontal += instruction.GetDirectionLenght();
                    this.depth += instruction.GetDirectionLenght() * this.aim;
                    break;
                case "up":
                    this.aim -= instruction.GetDirectionLenght();
                    break;
                case "down":
                    this.aim += instruction.GetDirectionLenght();
                    break;
                default:
                    break;
            }
        }

        internal int GetMultipliedValue()
        {
            return this.depth * this.horizontal;
        }
    }
}