using System;
using System.Collections.Generic;
using System.Text;
using Advent_of_Code_2021.Day15classes;

namespace Advent_of_Code_2021.Days
{
    public class Day15 : Day
    {
        Square[,] map;
        public Day15() : base("15")
        {
            map = new Square[input.Count, input[0].Length];
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input[0].Length; j++)
                {
                    Square s = new Square(int.Parse(input[i][j].ToString()));
                    if (i > 0)
                    {
                        s.Up = map[i - 1, j];
                        map[i - 1, j].Down = s;
                    }
                    if (j > 0)
                    {
                        s.Left = map[i, j - 1];
                        map[i, j - 1].Right = s;
                    }
                    map[i, j] = s;
                }
            }
            map[input.Count - 1, input[0].Length - 1].SetEndpoint();
            for(int i = input.Count - 1; i >=0; i--)
            {
                for (int j = input[0].Length - 1; j >= 0; j--)
                {
                    map[i, j].CalculateShortestPath();
                }
            }
        }

        public override string Assignment1()
        {
            return map[0, 0].ShortestPath.ToString(); ;
        }

        public override string Assignment2()
        {
            Assignment2Map();
            return map[0, 0].ShortestPath.ToString(); ;
        }

        public void Assignment2Map()
        {
            map = new Square[input.Count*5, input[0].Length*5];
            for (int i = 0; i < input.Count; i++)
            {
                int[] yCords = new int[] { i, i + input.Count, i + input.Count * 2 , i + input.Count * 3 , i + input.Count * 4 };
                for (int j = 0; j < input[0].Length; j++)
                {
                    int[] xCords = new int[] { j, j + input[0].Length , j + input[0].Length * 2 , j + input[0].Length * 3 , j + input[0].Length * 4 };
                    int[] risks = RiskLevels(int.Parse(input[i][j].ToString()));
                    for(int a = 0; a < yCords.Length; a++)
                    {
                        for (int b = 0; b < yCords.Length; b++)
                        {
                            Square s = new Square(risks[a+b]);
                            if (i > 0)
                            {
                                s.Up = map[yCords[a]-1, xCords[b]];
                                map[yCords[a] - 1, xCords[b]].Down = s;
                                if(i == input.Count - 1 && a !=4)
                                {
                                    s.Down = map[yCords[a] + 1, xCords[b]];
                                    map[yCords[a] + 1, xCords[b]].Up = s;
                                }
                            }
                            if (j > 0)
                            {
                                s.Left = map[yCords[a], xCords[b]-1];
                                map[yCords[a], xCords[b]-1].Right = s;
                                if (j == input.Count - 1 && b != 4)
                                {
                                    s.Right = map[yCords[a], xCords[b] + 1];
                                    map[yCords[a], xCords[b] + 1].Left = s;
                                }
                            }
                            map[yCords[a], xCords[b]] = s;
                        }
                    }
                }
            }
            map[map.GetLength(0) - 1, map.GetLength(1) - 1].SetEndpoint();
            for (int i = map.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = map.GetLength(1) - 1; j >= 0; j--)
                {
                    map[i, j].CalculateShortestPath();
                }
            }
        }

        private int[] RiskLevels(int start)
        {
            int[] answer = new int[9];
            answer[0] = start;
            answer[1] = start + 1 > 9 ? (start + 1) % 9 : start + 1;
            answer[2] = start + 2 > 9 ? (start + 2) % 9 : start + 2;
            answer[3] = start + 3 > 9 ? (start + 3) % 9 : start + 3;
            answer[4] = start + 4 > 9 ? (start + 4) % 9 : start + 4;
            answer[5] = start + 5 > 9 ? (start + 5) % 9 : start + 5;
            answer[6] = start + 6 > 9 ? (start + 6) % 9 : start + 6;
            answer[7] = start + 7 > 9 ? (start + 7) % 9 : start + 7;
            answer[8] = start + 8 > 9 ? (start + 8) % 9 : start + 8;
            return answer;
        }
    }
}
