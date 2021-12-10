using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021.Day10classes
{
    public class Stack
    {
        List<char> unresolved;

        public Stack()
        {
            unresolved = new List<char>();
        }

        public bool Next(char c)
        {
            switch (c)
            {
                case '(':
                case '[':
                case '{':
                case '<': unresolved.Add(c); return true;
                case ')':
                case ']':
                case '}':
                case '>': return Resolve(c);
            }
            return false;
        }

        public long GetCompletionScore()
        {
            long score = 0;
            for(int i = 1; i <= unresolved.Count; i++)
            {
                score *= 5;
                score += FindScore(unresolved[^i]);
            }
            return score;
        }

        private bool Resolve(char c)
        {
            if (unresolved.Count == 0)
                return false;

            if(FindMatch(unresolved[^1]) == c)
            {
                unresolved.RemoveAt(unresolved.Count-1);
                return true;
            }

            return false;

        }

        private char FindMatch(char c)
        {
            switch (c)
            {
                case '(': return ')';
                case '[': return ']';
                case '{': return '}';
                case '<': return '>';
            }
            return 'e';
        }

        private int FindScore(char c)
        {
            switch (c)
            {
                case '(': return 1;
                case '[': return 2;
                case '{': return 3;
                case '<': return 4;
            }
            return 0;
        }
    }
}
