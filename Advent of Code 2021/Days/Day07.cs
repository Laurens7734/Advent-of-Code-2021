using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2021.Days
{
    public class Day07 : Day
    {
        readonly List<int> start;
        public Day07() : base("07")
        {
            start = new List<int>(Array.ConvertAll(input[0].Split(','), x => int.Parse(x)));
            start.Sort();
        }

        public override string Assignment1()
        {
            List<long> results = new List<long>();
            for(int i = start[0]; i < start[^1]; i++)
            {
                long result = 0;
                foreach(int j in start)
                {
                    result += Math.Abs(i - j);
                }
                results.Add(result);
            }
            results.Sort();
            return results[0].ToString();
        }

        public override string Assignment2()
        {
            List<long> results = new List<long>();
            for (int i = start[0]; i < start[^1]; i++)
            {
                long result = 0;
                foreach (int j in start)
                {
                    long diff = Math.Abs(i - j);
                    result += ((diff + 1) * diff) / 2;
                }
                results.Add(result);
            }
            results.Sort();
            return results[0].ToString();
        }
    }
}
