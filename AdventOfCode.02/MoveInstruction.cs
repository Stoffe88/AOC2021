using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._02
{
    internal class MoveInstruction
    {
        private string direction;
        private int directionLenght;

        public MoveInstruction(string instructions)
        {
            var instructionParts = instructions.Split(' ');
            this.direction = instructionParts[0];
            int.TryParse(instructionParts[1], out this.directionLenght);
        }
        internal string GetDirection()
        {
            return this.direction;
        }
        internal int GetDirectionLenght()
        {
            return this.directionLenght;
        }
    }
}
