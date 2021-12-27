using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021.Day25classes
{
    public class Cucumber
    {
        readonly char direction;
        public Square location;

        public Cucumber(char d, Square loc)
        {
            direction = d;
            location = loc;
        }

        public bool ShouldMove()
        {
            if (direction == 'r')
                return location.CheckRight();
            if (direction == 'd')
                return location.CheckDown();
            return false;
        }

        public void Move()
        {
            Square current = location;
            if (direction == 'r')
                location = location.Right;
            if (direction == 'd')
                location = location.Down;
            location.Occupant = this;
            current.Occupant = null;
        }
    }
}
