using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021.Day25classes
{
    public class Square
    {
        public Square Left { get; set; }
        public Square Right { get; set; }
        public Square Up { get; set; }
        public Square Down { get; set; }
        public Cucumber Occupant {get; set;}

        public Square()
        {
        }

        public bool IsFree()
        {
            return (Occupant == null);
        }

        public bool CheckRight()
        {
            return Right.IsFree();
        }

        public bool CheckDown()
        {
            return Down.IsFree();
        }
    }
}
