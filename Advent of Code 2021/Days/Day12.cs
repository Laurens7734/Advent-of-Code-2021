using System;
using System.Collections.Generic;
using System.Text;
using Advent_of_Code_2021.Day12classes;

namespace Advent_of_Code_2021.Days
{
    public class Day12 : Day
    {
        private Dictionary<string, Cave> allCaves;
        public Day12() : base("12")
        {
            allCaves = new Dictionary<string, Cave>();

            foreach(string s in input)
            {
                string s1 = s.Substring(0, s.IndexOf('-'));
                string s2 = s[(s.IndexOf('-') + 1)..];
                Cave c1, c2;

                if (allCaves.ContainsKey(s1))
                    c1 = allCaves[s1];
                else
                {
                    c1 = new Cave(s1);
                    allCaves.Add(s1, c1);
                }
                if (allCaves.ContainsKey(s2))
                    c2 = allCaves[s2];
                else
                {
                    c2 = new Cave(s2);
                    allCaves.Add(s2, c2);
                }

                c1.AddPath(c2);
                c2.AddPath(c1);
            }
        }

        public override string Assignment1()
        {
            return allCaves["start"].AllPaths(new List<Cave>(), false).Count.ToString();
        }

        public override string Assignment2()
        {
            return allCaves["start"].AllPaths(new List<Cave>(), true).Count.ToString();
        }
    }
}
