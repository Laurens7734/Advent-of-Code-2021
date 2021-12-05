using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021.Days
{
    public class Day05 : Day
    {
        public Day05() : base("05")
        {
        }

        public override string Assignment1()
        {
            Dictionary<string, int> vents = new Dictionary<string, int>();

            foreach (string s in input)
            {
                string[] points = s.Split(" -> ");
                string[] pointA = points[0].Split(',');
                string[] pointB = points[1].Split(',');
                int x1 = int.Parse(pointA[0]);
                int y1 = int.Parse(pointA[1]);
                int x2 = int.Parse(pointB[0]);
                int y2 = int.Parse(pointB[1]);

                if (x1 != x2 && y1 != y2)
                    continue;
                foreach(string st in GetAllCordsBetween(x1, y1, x2, y2))
                {
                    if (vents.ContainsKey(st))
                        vents[st]++;
                    else
                        vents.Add(st, 1);
                }
            }
            int count = 0;
            foreach(int i in vents.Values)
            {
                if (i > 1)
                    count++;
            }
            return count.ToString(); ;
        }

        public override string Assignment2()
        {
            Dictionary<string, int> vents = new Dictionary<string, int>();

            foreach (string s in input)
            {
                string[] points = s.Split(" -> ");
                string[] pointA = points[0].Split(',');
                string[] pointB = points[1].Split(',');
                int x1 = int.Parse(pointA[0]);
                int y1 = int.Parse(pointA[1]);
                int x2 = int.Parse(pointB[0]);
                int y2 = int.Parse(pointB[1]);

                foreach (string st in GetAllCordsBetween(x1, y1, x2, y2))
                {
                    if (vents.ContainsKey(st))
                        vents[st]++;
                    else
                        vents.Add(st, 1);
                }
            }
            int count = 0;
            foreach (int i in vents.Values)
            {
                if (i > 1)
                    count++;
            }
            return count.ToString(); ;
        }

        private List<string> GetAllCordsBetween(int x1, int y1, int x2, int y2)
        {
            int steps = Math.Max(Math.Abs(x1-x2), Math.Abs(y1 - y2));
            int stepx = (x2 - x1) / steps;
            int stepy = (y2 - y1) / steps;
            List<string> cords = new List<string>();
            for(int i = 0; i <= steps; i++)
            {
                cords.Add($"{x1+(i*stepx)},{y1+(i*stepy)}");
            }
            return cords;
        }
    }
}
