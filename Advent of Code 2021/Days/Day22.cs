using System;
using System.Collections.Generic;
using System.Text;
using Advent_of_Code_2021.Day22classes;

namespace Advent_of_Code_2021.Days
{
    public class Day22 : Day
    {
        List<Cuboid> cuboids;
        public Day22() : base("22")
        {
            cuboids = new List<Cuboid>();
            foreach(string s in input)
            {
                Cuboid c = ParseString(s);
                List<Cuboid> toAdd = new List<Cuboid>() { c };
                List<Cuboid> toRemove = new List<Cuboid>() { };
                foreach (Cuboid cube in cuboids)
                {
                    if (cube.NoOverlap(c))
                        continue;
                    toRemove.Add(cube);
                    if (cube.FullyContained(c))
                        continue;
                    toAdd.AddRange(cube.RemoveOverlap(c));
                }
                foreach(Cuboid cube in toRemove)
                    cuboids.Remove(cube);
                cuboids.AddRange(toAdd);
            }
        }

        public override string Assignment1()
        {
            long total = 0;
            Cuboid dimentions = new Cuboid(-50, 50, -50, 50, -50, 50, false);
            foreach(Cuboid c in cuboids)
            {
                total += c.Count(dimentions);
            }
            return total.ToString();
        }

        public override string Assignment2()
        {
            long total = 0;
            foreach (Cuboid c in cuboids)
            {
                total += c.Count();
            }
            return total.ToString();
        }

        private Cuboid ParseString(string s)
        {
            bool on = s.StartsWith("on");
            long lx = 0, hx = 0, ly = 0, hy = 0, lz = 0, hz = 0;
            string[] cords = s[3..].Trim().Split(',');
            foreach (string st in cords)
            {
                long low = long.Parse(st[(st.IndexOf('=') + 1)..st.IndexOf('.')]);
                long high = long.Parse(st[(st.LastIndexOf('.') + 1)..]);

                if (st.StartsWith('x'))
                {
                    lx = low;
                    hx = high;
                }
                else if (st.StartsWith('y'))
                {
                    ly = low;
                    hy = high;
                }
                else if (st.StartsWith('z'))
                {
                    lz = low;
                    hz = high;
                }
            }
            return new Cuboid(lx, hx, ly, hy, lz, hz, on);
        }
    }
}
