using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021.Day09classes
{
    public class Square
    {
        readonly int height;
        readonly int id;
        public bool isLowest;

        public Square Left { get; set; }
        public Square Right { get; set; }
        public Square Up { get; set; }
        public Square Down { get; set; }

        public Square(int h, int i)
        {
            height = h;
            id = i;
            isLowest = false;
        }

        public void CheckIfLowest()
        {
            if (Left != null && Left.height <= height)
                return;
            if (Right != null && Right.height <= height)
                return;
            if (Up != null && Up.height <= height)
                return;
            if (Down != null && Down.height <= height)
                return;
            isLowest = true;
        }

        public int GetRiskLevel()
        {
            if (isLowest)
                return height + 1;
            else
                return 0;
        }

        public int GetBasinSize()
        {
            if (!isLowest)
                return 0;
            Dictionary<int, Square> basin = new Dictionary<int, Square>();
            List<Square> toProcess = new List<Square>();
            basin.Add(id, this);
            toProcess.Add(this);
            while(toProcess.Count > 0)
            {
                Square current = toProcess[0];
                toProcess.RemoveAt(0);

                if (current.Left != null && current.Left.height < 9 && !basin.ContainsKey(current.Left.id))
                {
                    basin.Add(current.Left.id, current.Left);
                    toProcess.Add(current.Left);
                }
                if (current.Right != null && current.Right.height < 9 && !basin.ContainsKey(current.Right.id))
                {
                    basin.Add(current.Right.id, current.Right);
                    toProcess.Add(current.Right);
                }
                if (current.Up != null && current.Up.height < 9 && !basin.ContainsKey(current.Up.id))
                {
                    basin.Add(current.Up.id, current.Up);
                    toProcess.Add(current.Up);
                }
                if (current.Down != null && current.Down.height < 9 && !basin.ContainsKey(current.Down.id))
                {
                    basin.Add(current.Down.id, current.Down);
                    toProcess.Add(current.Down);
                }
            }
            return basin.Count;
        }
    }
}
