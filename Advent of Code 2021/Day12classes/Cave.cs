using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021.Day12classes
{
    public class Cave
    {
        readonly string name;
        readonly bool smallCave;
        readonly List<Cave> reachable;
        public Cave(string n)
        {
            name = n;
            smallCave = (n[0] >= 'a' && n[0] <= 'z');
            reachable = new List<Cave>();
        }

        public void AddPath(Cave c)
        {
            reachable.Add(c);
        }

        public List<string> AllPaths(List<Cave> previous, bool smalltwice)
        {
            List<string> pathsfromhere = new List<string>();

            if (name.Equals("end"))
            {
                List<Cave> route = new List<Cave>(previous);
                route.Add(this);
                pathsfromhere.Add(convertPath(route));
            }
            else
            {
                if(!(smallCave && previous.Contains(this)))
                {
                    List<Cave> path = new List<Cave>(previous);
                    path.Add(this);
                    foreach (Cave c in reachable)
                    {
                        pathsfromhere.AddRange(c.AllPaths(path, smalltwice));
                    }
                }
                else if (smalltwice && !name.Equals("start"))
                {
                    List<Cave> path = new List<Cave>(previous);
                    path.Add(this);
                    foreach (Cave c in reachable)
                    {
                        pathsfromhere.AddRange(c.AllPaths(path, false));
                    }
                }
            }

            return pathsfromhere;
        }

        private string convertPath(List<Cave> path)
        {
            StringBuilder sb = new StringBuilder();
            foreach(Cave c in path)
            {
                sb.Append(c.name);
                sb.Append(',');
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
    }
}
