using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021.Day18classes
{
    public class Pair : INumberPart
    {
        public INumberPart left;
        INumberPart right;
        Sides side;
        Pair parrent;

        public Pair()
        {
        }

        public void AddLeft(INumberPart part)
        {
            left = part;
        }

        public void AddRight(INumberPart part)
        {
            right = part;
        }

        public void SetSide(Sides s)
        {
            side = s;
        }

        public void SetParrent(Pair p)
        {
            parrent = p;
        }

        public long GetMagnitude()
        {
            long ans = 3 * left.GetMagnitude();
            ans += 2 * right.GetMagnitude();

            return ans;
        }

        public void Explode(int depth)
        {
            if (depth < 4)
            {
                left.Explode(depth + 1);
                right.Explode(depth + 1);
            }
            else
            {
                if(left.GetType() != typeof(Number) || right.GetType() != typeof(Number))
                {
                    throw new Exception("Can't explode pair containing more pairs");
                }
                int toLeft = ((Number)left).GetValue();
                int toRight = ((Number)right).GetValue();

                parrent.FindNextNumber(Sides.Left, toLeft, side);
                parrent.FindNextNumber(Sides.Right, toRight, side);

                Number n = new Number(0);
                n.SetParrent(parrent);
                n.SetSide(side);
                if (side == Sides.Left)
                    parrent.AddLeft(n);
                else
                    parrent.AddRight(n);
            }
        }

        public bool Split()
        {
            if (left.Split())
                return true;
            else
                return right.Split();
        }

        public bool FindNextNumber(Sides search, int toAdd, Sides origin)
        {
            if(search != origin)
            {
                if (search == Sides.Left)
                {
                    if(left.FindNextNumber(search, toAdd))
                        return true;
                }
                else
                {
                    if(right.FindNextNumber(search, toAdd))
                        return true;
                } 
            }
            if (parrent != null)
                return parrent.FindNextNumber(search, toAdd, side);
            else
                return false;
        }

        public bool FindNextNumber(Sides search, int toAdd)
        {
            //when going down the tree directions reverse
            if (search != Sides.Left)
            {
                if (left.FindNextNumber(search, toAdd))
                    return true;
                else
                    return right.FindNextNumber(search, toAdd);
            }
            else
            {
                if (right.FindNextNumber(search, toAdd))
                    return true;
                else
                    return left.FindNextNumber(search, toAdd);
            }
        }

        public override string ToString()
        {
            return $"[{left},{right}]";
        }
    }
}
