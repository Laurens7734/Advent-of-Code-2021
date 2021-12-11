using System;
using System.Collections.Generic;
using System.Text;
using Advent_of_Code_2021.Day11classes;

namespace Advent_of_Code_2021.Days
{
    public class Day11 : Day
    {
        Octopus[,] grid;
        public Day11() : base("11")
        {
            grid = new Octopus[input.Count, input[0].Length];
            for(int i = 0; i < input.Count; i++)
            {
                for(int j = 0; j < input[0].Length; j++)
                {
                    Octopus o = new Octopus(int.Parse(input[i][j].ToString()));
                    if(i > 0)
                    {
                        o.AddNeighbour(grid[i - 1, j]);
                        grid[i - 1, j].AddNeighbour(o);
                        if (j > 0)
                        {
                            o.AddNeighbour(grid[i, j - 1]);
                            grid[i, j - 1].AddNeighbour(o);
                            o.AddNeighbour(grid[i - 1, j - 1]);
                            grid[i - 1, j - 1].AddNeighbour(o);
                        }
                        if(j < input[0].Length - 1)
                        {
                            o.AddNeighbour(grid[i - 1, j + 1]);
                            grid[i - 1, j + 1].AddNeighbour(o);
                        }
                    }
                    else if (j > 0)
                    {
                        o.AddNeighbour(grid[i, j - 1]);
                        grid[i, j - 1].AddNeighbour(o);
                    }
                    grid[i, j] = o;
                }
            }
        }

        public override string Assignment1()
        {
            for(int i = 0; i < 100; i++)
            {
                foreach(Octopus o in grid)
                {
                    o.NextStep();
                }
                foreach (Octopus o in grid)
                {
                    o.Reset();
                }
            }
            return Octopus.totalFlashes.ToString();
        }

        public override string Assignment2()
        {
            ResetGrid();

            int step = 0;
            bool stillLooking = true;
            while(stillLooking)
            {
                step++;
                foreach (Octopus o in grid)
                {
                    o.NextStep();
                }
                if(Octopus.flashcount == grid.Length)
                {
                    stillLooking = false;
                }
                foreach (Octopus o in grid)
                {
                    o.Reset();
                }
            }
            return step.ToString();
        }

        private void ResetGrid()
        {
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input[0].Length; j++)
                {
                    grid[i,j].Reset(int.Parse(input[i][j].ToString()));
                }
            }
        }
    }
}
