using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021.Days
{
    public class Day06 : Day
    {
        int[] startingPosition;
        public Day06() : base("06")
        {
            startingPosition = new int[7];
            string[] nums = input[0].Split(',');
            foreach(string s in nums)
            {
                startingPosition[int.Parse(s)]++;
            }
        }

        public override string Assignment1()
        {
            int[] fish = new int[9];
            for (int i = 0; i < startingPosition.Length; i++)
            {
                fish[i] = startingPosition[i];
            }
            for (int i = 0; i < 80; i++)
            {
                int newFish = fish[0];
                for (int j = 1; j < fish.Length; j++)
                {
                    fish[j - 1] = fish[j];
                }
                fish[6] += newFish;
                fish[8] = newFish;
            }
            long sum = 0;
            foreach (int i in fish)
                sum += i;
            return sum.ToString();
        }

        public override string Assignment2()
        {
            long[] fish = new long[9];
            for (int i = 0; i < startingPosition.Length; i++)
            {
                fish[i] = startingPosition[i];
            }
            for (int i = 0; i < 256; i++)
            {
                long newFish = fish[0];
                for (int j = 1; j < fish.Length; j++)
                {
                    fish[j - 1] = fish[j];
                }
                fish[6] += newFish;
                fish[8] = newFish;
            }
            long sum = 0;
            foreach (long i in fish)
                sum += i;
            return sum.ToString();
        }
    }
}
