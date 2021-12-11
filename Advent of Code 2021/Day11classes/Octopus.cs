using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021.Day11classes
{
    public class Octopus
    {
        public static long totalFlashes = 0;
        public static int flashcount = 0;
        
        int energy;
        bool flashed;
        List<Octopus> neighbours;

        public Octopus(int start)
        {
            energy = start;
            flashed = false;
            neighbours = new List<Octopus>();
        }

        public void AddNeighbour(Octopus octo)
        {
            neighbours.Add(octo);
        }

        public void NextStep()
        {
            if (!flashed)
            {
                energy++;
                if (energy > 9)
                {
                    flashed = true;
                    totalFlashes++;
                    flashcount++;
                    neighbours.ForEach(x => x.NextStep());
                }
            }
        }

        public void Reset()
        {
            if (flashed)
                energy = 0;
            flashed = false;
            flashcount = 0;
        }

        public void Reset(int start)
        {
            energy = start;
            flashed = false;
            flashcount = 0;
        }
    }
}
