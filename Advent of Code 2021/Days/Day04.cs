using System;
using System.Collections.Generic;
using System.Text;
using Advent_of_Code_2021.Day04classes;

namespace Advent_of_Code_2021.Days
{
    public class Day04 : Day
    {
        List<int> pulls;
        Dictionary<int, Square> squares;
        List<Board> boards;
        public Day04() : base("04")
        {
            pulls = new List<int>(Array.ConvertAll(input[0].Split(','), x => int.Parse(x)));
            squares = new Dictionary<int, Square>();
            boards = new List<Board>();

            Board b = new Board();
            for(int i = 2; i < input.Count; i++)
            {
                if (input[i].Equals(""))
                {
                    b.GenerateColumns();
                    boards.Add(b);
                    b = new Board();
                }
                else
                {
                    b.AddRow(ConvertRow(input[i]));
                }
            }
            if (b.HasRows())
            {
                b.GenerateColumns();
                boards.Add(b);
            }
        }

        public override string Assignment1()
        {
            bool winnerExists = false;
            Board winner = null;
            int position = 0;
            while (!winnerExists)
            {
                int number = pulls[position];
                position++;
                if (!squares.ContainsKey(number))
                    continue;

                squares[number].Called = true;
                foreach(Board b in boards)
                {
                    if (b.HasWon())
                    {
                        winnerExists = true;
                        winner = b;
                        break;
                    }
                }
            }
            long answer = winner.GetUnmarkedSum() * pulls[position - 1];
            return answer.ToString(); ;
        }

        public override string Assignment2()
        {
            foreach(Square s in squares.Values)
            {
                s.Called = false;
            }

            bool lastWinnerFound = false;
            Board lastWinner = null;
            int position = 0;
            while (!lastWinnerFound)
            {
                int number = pulls[position];
                position++;
                if (!squares.ContainsKey(number))
                    continue;

                squares[number].Called = true;
                List<Board> toRemove = new List<Board>();
                foreach (Board b in boards)
                {
                    if (b.HasWon())
                    {
                        if (boards.Count == 1)
                        {
                            lastWinnerFound = true;
                            lastWinner = b;
                        }
                        else
                        {
                            toRemove.Add(b);
                        }
                    }
                }
                foreach(Board bo in toRemove)
                {
                    boards.Remove(bo);
                }
            }
            long answer = lastWinner.GetUnmarkedSum() * pulls[position - 1];
            return answer.ToString(); ;
        }

        private Line ConvertRow(string row)
        {
            Line l = new Line();
            List<string> strings = new List<string>(row.Split(' '));
            strings = strings.FindAll(x => !x.Equals(""));
            int[] nums = Array.ConvertAll(strings.ToArray(), x => int.Parse(x));
            foreach(int i in nums)
            {
                Square square;
                if (!squares.ContainsKey(i))
                {
                    square = new Square(i);
                    squares.Add(i, square);
                }
                else
                {
                    square = squares[i];
                }
                l.AddSquare(square);
            }
            return l;
        }
    }
}
