using System;
using System.Collections.Generic;
using System.Text;
using Advent_of_Code_2021.Day25classes;

namespace Advent_of_Code_2021.Days
{
    public class Day25 : Day
    {
        Square[,] map;
        List<Cucumber> right;
        List<Cucumber> down;
        public Day25() : base("25")
        {
            map = new Square[input.Count, input[0].Length];
            right = new List<Cucumber>();
            down = new List<Cucumber>();

            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input[0].Length; j++)
                {
                    Square s = new Square();
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
                    if (i == input.Count - 1)
                    {
                        s.Down = map[0, j];
                        map[0, j].Up = s;
                    }
                    if (j == input[0].Length-1)
                    {
                        s.Right = map[i, 0];
                        map[i, 0].Left = s;
                    }
                    map[i, j] = s;
                    if (input[i][j] != '.')
                    {
                        Cucumber c = null;
                        if (input[i][j] == 'v')
                        {
                            c = new Cucumber('d', s);
                            down.Add(c);
                        }
                        if (input[i][j] == '>')
                        {
                            c = new Cucumber('r', s);
                            right.Add(c);
                        }
                        s.Occupant = c;
                        c.location = s;
                    }
                }
            }
        }

        public override string Assignment1()
        {
            bool movement = true;
            long steps = 0;
            while (movement)
            {
                steps++;
                List<Cucumber> MoveRight = right.FindAll(x => x.ShouldMove());
                MoveRight.ForEach(x => x.Move());
                List<Cucumber> MoveDown = down.FindAll(x => x.ShouldMove());
                MoveDown.ForEach(x => x.Move());
                if (MoveRight.Count + MoveDown.Count == 0)
                    movement = false;
            }
            return steps.ToString();
        }

        public override string Assignment2()
        {
            return "";
        }
    }
}
