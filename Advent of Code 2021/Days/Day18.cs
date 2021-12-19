using System;
using System.Collections.Generic;
using System.Text;
using Advent_of_Code_2021.Day18classes;

namespace Advent_of_Code_2021.Days
{
    public class Day18 : Day
    {
        public Day18() : base("18")
        {
        }

        public override string Assignment1()
        {
            List<INumberPart> numbers = new List<INumberPart>();
            foreach(string s in input)
            {
                numbers.Add(ParseNumber(s));
            }
            INumberPart answer = numbers[0];
            for(int i = 1; i < numbers.Count; i++)
            {
                answer = AddNumbers(answer, numbers[i]);
            }
            
            return answer.GetMagnitude().ToString();
        }

        public override string Assignment2()
        {
            long highestMagnitude = 0;
            for(int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input.Count; j++)
                {
                    if(i != j)
                    {
                        long mag = AddNumbers(ParseNumber(input[i]), ParseNumber(input[j])).GetMagnitude();
                        if (mag > highestMagnitude)
                            highestMagnitude = mag;
                    }
                }
            }
            return highestMagnitude.ToString(); ;
        }

        private INumberPart ParseNumber(string num)
        {
            List<Pair> stack = new List<Pair>();
            stack.Add(new Pair());
            Sides side = Sides.Left;
            foreach(char c in num)
            {
                if(c == '[')
                {
                    Pair p = new Pair();
                    p.SetParrent(stack[^1]);
                    p.SetSide(side);
                    if (side == Sides.Left)
                        stack[^1].AddLeft(p);
                    else
                        stack[^1].AddRight(p);
                    side = Sides.Left;
                    stack.Add(p);
                }
                else if(c == ']')
                {
                    stack.RemoveAt(stack.Count - 1);
                }
                else if(c == ',')
                {
                    side = Sides.Right;
                }
                else
                {
                    Number n = new Number(int.Parse(c.ToString()));
                    n.SetSide(side);
                    n.SetParrent(stack[^1]);
                    if (side == Sides.Left)
                        stack[^1].AddLeft(n);
                    else
                        stack[^1].AddRight(n);
                    side = Sides.Left;
                }
            }
            return stack[0].left;
        }

        private INumberPart AddNumbers(INumberPart a, INumberPart b)
        {
            Pair answer = new Pair();
            answer.AddLeft(a);
            answer.AddRight(b);

            a.SetParrent(answer);
            a.SetSide(Sides.Left);
            
            b.SetParrent(answer);
            b.SetSide(Sides.Right);

            answer.Explode(0);
            while (answer.Split())
            {
                answer.Explode(0);
            }

            return answer;
        }
    }
}
