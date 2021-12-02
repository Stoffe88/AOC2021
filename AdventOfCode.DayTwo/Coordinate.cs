using System;

namespace AdventOfCode.DayTwo
{
    public class Coordinate
    {
        private int simpleHorizontal = 0;
        private int horizontal = 0;
        private int simpleDepth = 0;
        private int depth = 0;
        private int aim = 0;

        public Coordinate()
        { }

        internal void ExecuteInstruction(MoveInstruction instruction)
        {
            switch (instruction.GetDirection())
            {
                case "forward":
                    this.simpleHorizontal += instruction.GetDirectionLenght();
                    this.horizontal += instruction.GetDirectionLenght();
                    this.depth += instruction.GetDirectionLenght() * this.aim;
                    break;
                case "up":
                    this.simpleDepth -= instruction.GetDirectionLenght();
                    this.aim -= instruction.GetDirectionLenght();
                    break;
                case "down":
                    this.simpleDepth += instruction.GetDirectionLenght();
                    this.aim += instruction.GetDirectionLenght();
                    break;
                default:
                    break;
            }
        }
        internal int GetMultipliedValue()
        {
            return this.simpleDepth * this.simpleHorizontal;
        }
        internal int GetAimedMultipliedValue(){
            return this.depth * this.horizontal;
        }
    }
}