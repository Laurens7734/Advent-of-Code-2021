using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021.Days
{
    public class Day01: Day
    {
        private List<int> nums;
        public Day01() : base("01")
        {
            nums = new List<int>();
            foreach (string s in input)
                nums.Add(int.Parse(s));
        }

        public override string Assignment1()
        {
            int increaseCount = 0;

            for(int i =1; i < nums.Count; i++)
            {
                if (nums[i] > nums[i - 1])
                    increaseCount++;
            }
            return increaseCount.ToString();
        }

        public override string Assignment2()
        {
            int increaseCount = 0;
            List<int> windowSum = new List<int>();

            for (int i = 2; i < nums.Count; i++)
            {
                windowSum.Add(nums[i] + nums[i - 1] + nums[i - 2]);
            }

            for (int i = 1; i < windowSum.Count; i++)
            {
                if (windowSum[i] > windowSum[i - 1])
                    increaseCount++;
            }

            return increaseCount.ToString();
        }
    }
}
