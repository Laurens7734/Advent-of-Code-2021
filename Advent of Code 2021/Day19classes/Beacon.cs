using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021.Day19classes
{
    public class Beacon
    {
        Dictionary<long, List<Beacon>> neighbours;
        public long xcord, ycord, zcord;

        public Beacon(long x, long y, long z)
        {
            xcord = x;
            ycord = y;
            zcord = z;
            neighbours = new Dictionary<long, List<Beacon>>();
        }

        public bool MatchDistances(int amount, Beacon b)
        {
            int count = 0;
            foreach(long l in b.neighbours.Keys)
            {
                if (neighbours.ContainsKey(l))
                    count += Math.Min(neighbours[l].Count, b.neighbours[l].Count);
            }
            return count >= amount;
        }

        public void AddNeighbour(Beacon b)
        {
            long dist = Math.Abs(b.xcord - xcord) + Math.Abs(b.ycord - ycord) + Math.Abs(b.zcord - zcord);
            if (!neighbours.ContainsKey(dist))
                neighbours.Add(dist, new List<Beacon>());
            neighbours[dist].Add(b);
        }

        public override string ToString()
        {
            return $"[{xcord},{ycord},{zcord}]";
        }
    }
}
