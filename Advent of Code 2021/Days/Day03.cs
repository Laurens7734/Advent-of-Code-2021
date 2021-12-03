using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021.Days
{
    public class Day03 : Day
    {
        public Day03() : base("03")
        {
        }

        public override string Assignment1()
        {
            int[] counts = new int[input[0].Length];
            foreach(string s in input)
            {
                for(int i =0; i < s.Length; i++)
                {
                    if (s[i] == '1')
                        counts[i]++;
                }
            }

            long gamma = 0;
            long epsilon = 0;
            long toAdd = 1;

            for(int i = counts.Length-1; i >= 0; i--)
            {
                if (counts[i] > (input.Count / 2))
                    gamma += toAdd;
                else
                    epsilon += toAdd;
                toAdd *= 2;
            }

            return (gamma * epsilon).ToString();
        }

        public override string Assignment2()
        {
            long oxygenRating = findOxygenRating(input, 0);
            long CO2Rating = findCO2Rating(input, 0);
            return (oxygenRating * CO2Rating).ToString();
        }

        private long BinairyToNum(string s)
        {
            long answer = 0;
            long toAdd = 1;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '1')
                    answer += toAdd;
                
                toAdd *= 2;
            }
            return answer;
        }

        private long findOxygenRating(List<string> values, int position)
        {
            List<string> zero = new List<string>();
            List<string> one = new List<string>();

            foreach(string s in values)
            {
                if (s[position] == '1')
                    one.Add(s);
                else
                    zero.Add(s);
            }

            if (zero.Count == 1 && one.Count == 1)
                return BinairyToNum(one[0]);
            else if (zero.Count > one.Count)
                return findOxygenRating(zero, position + 1);
            else
                return findOxygenRating(one, position + 1);
        }

        private long findCO2Rating(List<string> values, int position)
        {
            List<string> zero = new List<string>();
            List<string> one = new List<string>();

            foreach (string s in values)
            {
                if (s[position] == '1')
                    one.Add(s);
                else
                    zero.Add(s);
            }

            if (zero.Count == 1 && one.Count == 1)
                return BinairyToNum(zero[0]);
            else if (zero.Count > one.Count)
                return findCO2Rating(one, position + 1);
            else
                return findCO2Rating(zero, position + 1);
        }
    }
}
