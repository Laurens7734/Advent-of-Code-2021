using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021.Day04classes
{
    public class Square
    {
        public int Number { get; }
        public bool Called { get; set; }

        public Square(int num)
        {
            Number = num;
            Called = false;
        }
    }
}
