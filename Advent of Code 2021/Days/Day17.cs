using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021.Days
{
    public class Day17 : Day
    {
        int lowX, highX, lowY, highY;
        
        public Day17() : base("17")
        {
            string[] ranges = input[0][12..].Split(',');
            foreach(string s in ranges)
            {
                string st = s.Trim();
                int low = int.Parse(st[(st.IndexOf('=') + 1)..st.IndexOf('.')]);
                int high = int.Parse(st[(st.LastIndexOf('.') + 1)..]);
                if (st.StartsWith('x'))
                {
                    lowX = low;
                    highX = high;
                }
                else if (st.StartsWith('y'))
                {
                    lowY = low;
                    highY = high;
                }
            }
        }

        public override string Assignment1()
        {
            int idealX = 0;
            int total = 0;
            while(total < lowX)
            {
                idealX++;
                total += idealX;
            }
            long highestY = 0;
            for (int i = 0; i < Math.Abs(lowY); i++)
            {
                if(Hits(idealX, i))
                {
                    int highest = (i * (i + 1)) / 2;
                    if (highest > highestY)
                        highestY = highest;
                }
            }
            return highestY.ToString(); ;
        }

        public override string Assignment2()
        {
            int smallestX = 0;
            long total = 0;
            while (total < lowX)
            {
                smallestX++;
                total += smallestX;
            }
            total = 0;
            for(int x = smallestX; x <= highX; x++)
            {
                for(int y = lowY; y < Math.Abs(lowY); y++)
                {
                    if (Hits(x, y))
                        total++;
                }
            }
            return total.ToString();
        }

        private bool Hits(int startX, int startY)
        {
            int xPosition = 0, yPosition = 0;
            int xVel = startX, yVel = startY;
            while(xPosition <= highX && xVel > 0)
            {
                xPosition += xVel;
                yPosition += yVel;
                xVel -= 1;
                yVel -= 1;
                if (xPosition >= lowX && xPosition <= highX && yPosition >= lowY && yPosition <= highY)
                    return true;
            }
            if(xPosition >= lowX && xPosition <= highX && yPosition > lowY)
            {
                while(yPosition > lowY)
                {
                    yPosition += yVel;
                    yVel -= 1;
                    if (yPosition >= lowY && yPosition <= highY)
                        return true;
                }
            }
            return false;
        }
    }
}
