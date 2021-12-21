using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021.Days
{
    public class Day21 : Day
    {
        Dictionary<int, int> rollList = new Dictionary<int, int> { { 3, 1 }, { 4, 3 }, { 5, 6 }, { 6, 7 }, { 7, 6 }, { 8, 3 }, { 9, 1 } };
        public Day21() : base("21")
        {
        }

        public override string Assignment1()
        {
            int p1 = int.Parse(input[0][(input[0].IndexOf(':') + 2)..]) - 1;
            int p2 = int.Parse(input[1][(input[1].IndexOf(':') + 2)..]) - 1;
            int score1 = 0;
            int score2 = 0;
            int dieRolls = 0;
            int nextroll = 1;
            while (score1 < 1000 && score2 < 1000)
            {
                int steps = 0;
                for (int i = 0; i < 3; i++)
                {
                    dieRolls++;
                    steps += nextroll;
                    nextroll++;
                    if (nextroll > 100)
                        nextroll = 1;
                }
                if (dieRolls % 6 == 3)
                {
                    p1 = (p1 + steps) % 10;
                    score1 += p1 + 1;
                }
                else
                {
                    p2 = (p2 + steps) % 10;
                    score2 += p2 + 1;
                }
            }
            return (dieRolls * Math.Min(score1, score2)).ToString();
        }

        public override string Assignment2()
        {
            int p1 = int.Parse(input[0][(input[0].IndexOf(':') + 2)..]) - 1;
            int p2 = int.Parse(input[1][(input[1].IndexOf(':') + 2)..]) - 1;
            Tuple<long, long> result = GameStep(0, 0, p1, p2, 1);
            return Math.Max(result.Item1,result.Item2).ToString();
        }

        private Tuple<long, long> GameStep(int s1, int s2, int p1, int p2, int turn)
        {
            long win1 = 0;
            long win2 = 0;
            for(int i = 3; i < 10; i++)
            {
                int score1 = s1;
                int score2 = s2;
                int pos1 = p1;
                int pos2 = p2;
                if (turn%2 == 1)
                {
                    pos1 = (p1 + i) % 10;
                    score1 = s1 + 1 + pos1;
                    if (score1 > 20)
                    {
                        win1+=rollList[i];
                        continue;
                    }
                        
                }
                else
                {
                    pos2 = (p2 + i) % 10;
                    score2 = s2 + 1 + pos2;
                    if (score2 > 20)
                    {
                        win2+=rollList[i];
                        continue;
                    }
                }
                Tuple<long, long> result = GameStep(score1, score2, pos1, pos2, turn + 1);
                win1 += rollList[i] * result.Item1;
                win2 += rollList[i] * result.Item2;
            }
            return new Tuple<long, long>(win1, win2);
        }
    }
}
