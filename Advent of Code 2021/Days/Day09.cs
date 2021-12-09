using System;
using System.Collections.Generic;
using System.Text;
using Advent_of_Code_2021.Day09classes;

namespace Advent_of_Code_2021.Days
{
    public class Day09 : Day
    {
        Square[,] map;
        public Day09() : base("09")
        {
            map = new Square[input.Count, input[0].Length];
            int counter = 1;
            for(int i = 0; i < input.Count; i++)
            {
                for(int j = 0; j < input[0].Length; j++)
                {
                    Square s = new Square(int.Parse(input[i][j].ToString()), counter);
                    counter++;
                    if(i > 0)
                    {
                        s.Up = map[i - 1, j];
                        map[i - 1, j].Down = s;
                    }
                    if(j > 0)
                    {
                        s.Left = map[i, j - 1];
                        map[i, j - 1].Right = s;
                    }
                    map[i, j] = s;
                }
            }
            foreach(Square s in map)
            {
                s.CheckIfLowest();
            }
        }

        public override string Assignment1()
        {
            long total = 0;
            foreach(Square s in map)
            {
                total += s.GetRiskLevel();
            }
            return total.ToString();
        }

        public override string Assignment2()
        {
            List<int> sizes = new List<int>();
            foreach(Square s in map)
            {
                int size = s.GetBasinSize();
                if (size > 0)
                    sizes.Add(size);
            }
            sizes.Sort();
            long total = sizes[^1] * sizes[^2] * sizes[^3];
            return total.ToString();
        }
    }
}
