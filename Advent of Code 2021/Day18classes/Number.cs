using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021.Day18classes
{
    public class Number : INumberPart
    {
        int value;
        Sides side;
        Pair parrent;

        public Number(int v)
        {
            value = v;
        }

        public void SetSide(Sides s)
        {
            side = s;
        }

        public void SetParrent(Pair p)
        {
            parrent = p;
        }

        public int GetValue()
        {
            return value;
        }

        public long GetMagnitude()
        {
            return value;
        }

        public void Explode(int depth)
        {
        }

        public bool Split()
        {
            if(value > 9)
            {
                Pair p = new Pair();
                Number left = new Number((int)Math.Floor((decimal)value / 2));
                left.SetParrent(p);
                left.SetSide(Sides.Left);

                Number right = new Number((int)Math.Ceiling((decimal)value / 2));
                right.SetParrent(p);
                right.SetSide(Sides.Right);

                p.AddLeft(left);
                p.AddRight(right);
                p.SetParrent(parrent);
                p.SetSide(side);
                if (side == Sides.Left)
                    parrent.AddLeft(p);
                else
                    parrent.AddRight(p);
                return true;
            }
            return false;
        }

        public bool FindNextNumber(Sides search, int toAdd, Sides origin)
        {
            value += toAdd;
            return true;
        }

        public bool FindNextNumber(Sides search, int toAdd)
        {
            value += toAdd;
            return true;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
