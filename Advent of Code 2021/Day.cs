using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021
{
    public abstract class Day
    {
        protected readonly List<string> input;

        public Day(string daynum)
        {
            List<string> result = new List<string>();
            System.IO.StreamReader file = new System.IO.StreamReader($"Datafiles/Day{daynum}.txt");
            string line;
            while ((line = file.ReadLine()) != null)
            {
                result.Add(line);
            }
            input = result;
        }

        public abstract string Assignment1();
        public abstract string Assignment2();
    }
}
