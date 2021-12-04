using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021.Day04classes
{
    public class Board
    {
        List<Line> rows;
        List<Line> columns;

        public Board()
        {
            rows = new List<Line>();
            columns = new List<Line>();
        }

        public void AddRow(Line l)
        {
            rows.Add(l);
        }

        public void GenerateColumns()
        {
            for(int i = 0; i < rows[0].RowLength(); i++)
            {
                Line l = new Line();
                foreach(Line li in rows)
                {
                    l.AddSquare(li.GetSquareAtPosition(i));
                }
                columns.Add(l);
            }
        }

        public bool HasWon()
        {
            if (rows.Find(x => x.Filled()) != null)
                return true;
            if (columns.Find(x => x.Filled()) != null)
                return true;
            return false;
        }

        public int GetUnmarkedSum()
        {
            int sum = 0;
            foreach (Line l in rows)
            {
                sum += l.GetUnmarkedSum();
            }
            return sum;
        }

        public bool HasRows()
        {
            return rows.Count > 0;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("The full board:");
            foreach(Line l in rows)
            {
                sb.Append("\n");
                sb.Append(l.ToString());
            }
            return sb.ToString();
        }
    }
}
