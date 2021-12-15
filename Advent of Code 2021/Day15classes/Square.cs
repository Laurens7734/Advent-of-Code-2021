using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021.Day15classes
{
    public class Square
    {
        readonly int risk;
        public long ShortestPath { get; private set; }

        public Square Left { get; set; }
        public Square Right { get; set; }
        public Square Up { get; set; }
        public Square Down { get; set; }

        public Square(int r)
        {
            risk = r;
            ShortestPath = long.MaxValue-20;
        }

        public long PathRisk()
        {
            return risk + ShortestPath;
        }

        public void CalculateShortestPath()
        {
            long shortest = ShortestPath;
            if (Left != null && Left.PathRisk() < shortest)
                shortest = Left.PathRisk();
            if (Right != null && Right.PathRisk() < shortest)
                shortest = Right.PathRisk();
            if (Up != null && Up.PathRisk() < shortest)
                shortest = Up.PathRisk();
            if (Down != null && Down.PathRisk() < shortest)
                shortest = Down.PathRisk();

            if(shortest != ShortestPath){
                ShortestPath = shortest;

                if (Right != null)
                    Right.NewPath(PathRisk());
                if (Down != null)
                    Down.NewPath(PathRisk());
            }
        }

        public void NewPath(long length)
        {
            if (length < ShortestPath)
                CalculateShortestPath();
        }

        public void SetEndpoint()
        {
            ShortestPath = 0;
        }
    }
}
