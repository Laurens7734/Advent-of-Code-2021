using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021.Day18classes
{
    public interface INumberPart
    {
        public void SetSide(Sides s);
        public void SetParrent(Pair p);

        public void Explode(int depth);
        public bool Split();

        public bool FindNextNumber(Sides search, int toAdd, Sides origin);
        public bool FindNextNumber(Sides search, int toAdd);
        public long GetMagnitude();
    }
}