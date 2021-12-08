using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021.Days
{
    public class Day08 : Day
    {
        public Day08() : base("08")
        {
        }

        public override string Assignment1()
        {
            int count = 0;
            foreach (string s in input)
            {
                string[] nums = s.Substring(s.IndexOf('|')).Split(' ');
                foreach(string n in nums)
                {
                    switch (n.Length)
                    {
                        case 2:
                        case 3:
                        case 4:
                        case 7: count++; break;
                    }
                }
            }
            return count.ToString();
        }

        public override string Assignment2()
        {
            long total = 0;
            foreach (string s in input)
            {
                string[] parts = s.Split(" | ");
                string[] digits = parts[0].Split(' ');
                string[] nums = parts[1].Split(' ');
                string one = null, four = null;
                foreach(string st in digits)
                {
                    if (st.Length == 2)
                        one = st;
                    else if (st.Length == 4)
                        four = st;
                }
                int number = 0;
                for(int i = 0; i < nums.Length; i++)
                {
                    number += (int)(ParseInput(nums[i], one, four) * Math.Pow(10, nums.Length-(i+1)));
                }
                total += number;
            }
            return total.ToString();
        }

        private int ParseInput(string num, string one, string four)
        {
            switch (num.Length)
            {
                case 2: return 1;
                case 3: return 7;
                case 4: return 4;
                case 5: return SeperateFive(num, one, four);
                case 6: return SeperateSix(num, one, four);
                case 7: return 8;
            }
            return -1;
        }

        private int SeperateFive(string num, string one, string four)
        {
            if(num.Contains(one[0]) && num.Contains(one[1]))
            {
                return 3;
            }
            int count = 0;
            foreach(char c in four)
            {
                if (num.Contains(c))
                    count++;
            }
            if (count == 3)
                return 5;
            else
                return 2;
        }

        private int SeperateSix(string num, string one, string four)
        {
            if ((!num.Contains(one[0])) || (!num.Contains(one[1])))
                return 6;
            if (num.Contains(four[0]) && num.Contains(four[1]) && num.Contains(four[2]) && num.Contains(four[3]))
                return 9;
            else
                return 0;
        }
    }
}
