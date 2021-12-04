using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021.Day04classes
{
    public class Line
    {
        List<Square> squares;
        public Line()
        {
            squares = new List<Square>();
        }

        public void AddSquare(Square s)
        {
            squares.Add(s);
        }

        public int RowLength()
        {
            return squares.Count;
        }

        public Square GetSquareAtPosition(int position)
        {
            if (position >= 0 && position < squares.Count)
                return squares[position];
            return null;
        }

        public bool Filled()
        {
            foreach(Square s in squares)
            {
                if (!s.Called)
                    return false;
            }
            return true;
        }

        public int GetUnmarkedSum()
        {
            int sum = 0;
            foreach (Square s in squares)
            {
                if (!s.Called)
                    sum += s.Number;
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Square s in squares)
            {
                if (s.Called)
                    sb.Append('+');
                sb.Append(s.Number);
                sb.Append(' ');
            }
            return sb.ToString();
        }
    }
}
