using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021.Days
{
    public class Day02 : Day
    {
        long depth;
        long horizontal;
        long aim;

        public Day02() : base("02")
        {
            depth = 0;
            horizontal = 0;
            aim = 0;
        }

        public override string Assignment1()
        {
            foreach(string s in input)
            {
                string[] parts = s.Split(' ');
                long num = long.Parse(parts[1]);
                switch (parts[0])
                {
                    case "up": depth -= num; break;
                    case "down": depth += num; break;
                    case "forward": horizontal += num; break;
                }
            }
            return (depth*horizontal).ToString();
        }

        public override string Assignment2()
        {
            depth = 0;
            horizontal = 0;
            aim = 0;
            foreach (string s in input)
            {
                string[] parts = s.Split(' ');
                long num = long.Parse(parts[1]);
                switch (parts[0])
                {
                    case "up": aim -= num; break;
                    case "down": aim += num; break;
                    case "forward": horizontal += num; depth += (num * aim); break;
                }
            }
            return (depth * horizontal).ToString();
        }
    }
}
