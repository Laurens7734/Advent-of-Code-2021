using System;
using System.Collections.Generic;
using System.Text;
using Advent_of_Code_2021.Day10classes;

namespace Advent_of_Code_2021.Days
{
    public class Day10 : Day
    {
        public Day10() : base("10")
        {
        }

        public override string Assignment1()
        {
            long totalScore = 0;
            foreach(string s in input)
            {
                Stack st = new Stack();
                foreach(char c in s)
                {
                    if (!st.Next(c))
                    {
                        totalScore += GetScore(c);
                        break;
                    }
                }
            }
            return totalScore.ToString();
        }

        public override string Assignment2()
        {
            List<long> scores = new List<long>();
            foreach (string s in input)
            {
                Stack st = new Stack();
                bool valid = true;
                foreach (char c in s)
                {
                    if (!st.Next(c))
                    {
                        valid = false;
                        break;
                    }
                }
                if (valid)
                {
                    scores.Add(st.GetCompletionScore());
                }
            }

            scores.Sort();
            return scores[scores.Count/2].ToString();
        }

        private int GetScore(char c)
        {
            switch (c)
            {
                case ')': return 3;
                case ']': return 57;
                case '}': return 1197;
                case '>': return 25137;
            }
            return 0;
        }
    }
}
