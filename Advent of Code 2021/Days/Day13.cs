using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021.Days
{
    public class Day13 : Day
    {
        char[,] paper;
        readonly List<string> folds;

        public Day13() : base("13")
        {
            folds = new List<string>();
            foreach(string s in input)
            {
                if (s.StartsWith("fold"))
                    folds.Add(s[11..]);
            }
        }

        public override string Assignment1()
        {
            CreatePaper();
            string foldDirection = folds[0][..folds[0].IndexOf('=')];
            int foldcord = int.Parse(folds[0][(folds[0].IndexOf('=')+1)..]);
            if (foldDirection.Equals("y"))
                FoldY(foldcord);
            else if (foldDirection.Equals("x"))
                FoldX(foldcord);
            
            long count = 0;
            foreach(char c in paper)
            {
                if (c == '#')
                    count++;
            }
            return count.ToString();
        }

        public override string Assignment2()
        {
            CreatePaper();
            foreach(string fold in folds)
            {
                string foldDirection = fold[..fold.IndexOf('=')];
                int foldcord = int.Parse(fold[(fold.IndexOf('=') + 1)..]);
                if (foldDirection.Equals("y"))
                    FoldY(foldcord);
                else if (foldDirection.Equals("x"))
                    FoldX(foldcord);
            }
            PrintPaper();
            return "see printout for result";
        }

        private void CreatePaper()
        {
            int highestX = 0;
            int highestY = 0;
            List<Tuple<int, int>> points = new List<Tuple<int, int>>();
            foreach(string s in input)
            {
                if (s.Equals(""))
                    break;
                int x = int.Parse(s[..s.IndexOf(',')]);
                int y = int.Parse(s[(s.IndexOf(',') + 1)..]);
                if (x > highestX)
                    highestX = x;
                if (y > highestY)
                    highestY = y;
                points.Add(new Tuple<int, int>(x, y));
            }
            
            paper = new char[highestY + 1, highestX + 1];
            for(int i = 0; i <= highestY; i++)
            {
                for(int j = 0; j <= highestX; j++)
                {
                    paper[i, j] = '.';
                }
            }

            foreach(Tuple<int,int> point in points)
            {
                paper[point.Item2, point.Item1] = '#';
            }
        }

        private void FoldX(int xvalue)
        {
            char[,] foldedPaper = new char[paper.GetLength(0), xvalue];
            for(int i = 0; i < paper.GetLength(0); i++)
            {
                for(int j = 0; j < paper.GetLength(1); j++)
                {
                    if (j < xvalue)
                        foldedPaper[i, j] = paper[i, j];
                    else if (paper[i, j] == '#')
                        foldedPaper[i, (xvalue - (j - xvalue))] = '#';

                }
            }
            paper = foldedPaper;
        }

        private void FoldY(int yvalue)
        {
            char[,] foldedPaper = new char[yvalue, paper.GetLength(1)];
            for (int i = 0; i < paper.GetLength(0); i++)
            {
                for (int j = 0; j < paper.GetLength(1); j++)
                {
                    if (i < yvalue)
                        foldedPaper[i, j] = paper[i, j];
                    else if (paper[i, j] == '#')
                        foldedPaper[(yvalue - (i - yvalue)), j] = '#';

                }
            }
            paper = foldedPaper;
        }

        private void PrintPaper()
        {
            for(int i = 0; i < paper.GetLength(0); i++)
            {
                StringBuilder row = new StringBuilder();
                for(int j = 0; j < paper.GetLength(1); j++)
                {
                    row.Append(paper[i, j]);
                }
                Console.WriteLine(row.ToString());
            }
        }
    }
}
