using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021.Days
{
    public class Day14 : Day
    {
        readonly Dictionary<string, string> inserts;
        public Day14() : base("14")
        {
            inserts = new Dictionary<string, string>();
            for (int i = 2; i < input.Count; i++)
            {
                string start = input[i][0..2];
                string insert = $"{input[i][0]}{input[i][^1]}{input[i][1]}";
                inserts.Add(start, insert);
            }
        }

        public override string Assignment1()
        {
            string current = input[0];
            for(int i = 0; i < 10; i++)
            {
                current = PerformStep(current);
            }
            Dictionary<char, long> counts = new Dictionary<char, long>();
            foreach(char c in current)
            {
                if (counts.ContainsKey(c))
                    counts[c]++;
                else
                    counts.Add(c, 1);
            }
            List<long> totals = new List<long>(counts.Values);
            totals.Sort();
            return (totals[^1]-totals[0]).ToString();
        }

        public override string Assignment2()
        {
            string current = input[0];
            Dictionary<char, long> counts = new Dictionary<char, long>();
            Dictionary<string, Dictionary<char, long>> countsPerPair = LetterCounts(40);
            for (int i = 0; i < current.Length - 1; i++)
            {
                counts = MergeCounts(counts, countsPerPair[current[i..(i + 2)]]);
            }
            counts[current[^1]]++;
            List<long> totals = new List<long>(counts.Values);
            totals.Sort();
            return (totals[^1] - totals[0]).ToString();
        }

        private string PerformStep(string start)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < start.Length-1; i++)
            {
                sb.Append(inserts[$"{start[i]}{start[i + 1]}"][0..2]);
            }
            sb.Append(start[^1]);
            return sb.ToString();
        }

        private Dictionary<string,Dictionary<char, long>> LetterCounts(int turns)
        {
            Dictionary<string, Dictionary<char, long>> answer = new Dictionary<string, Dictionary<char, long>>();
            foreach(KeyValuePair<string, string> pair in inserts)
            {
                Dictionary<char, long> counts = new Dictionary<char, long>();
                foreach(char c in pair.Value[0..2])
                {
                    if (counts.ContainsKey(c))
                        counts[c]++;
                    else
                        counts.Add(c, 1);
                }
                answer.Add(pair.Key, counts);
            }
            for(int i = 1; i < turns; i++)
            {
                Dictionary<string, Dictionary<char, long>> update = new Dictionary<string, Dictionary<char, long>>();
                foreach (KeyValuePair<string, string> pair in inserts)
                {
                    Dictionary<char, long> pair1 = answer[pair.Value[0..2]];
                    Dictionary<char, long> pair2 = answer[pair.Value[1..]];
                    update.Add(pair.Key, MergeCounts(pair1,pair2));
                }
                answer = update;
            }
            return answer;
        }

        private Dictionary<char, long> MergeCounts(Dictionary<char, long> d1, Dictionary<char, long> d2)
        {
            Dictionary<char, long> answer = new Dictionary<char, long>(d1);
            foreach(KeyValuePair<char, long> row in d2)
            {
                if (answer.ContainsKey(row.Key))
                    answer[row.Key] += row.Value;
                else
                   answer.Add(row.Key, row.Value);
            }
            return answer;
        }
    }
}
