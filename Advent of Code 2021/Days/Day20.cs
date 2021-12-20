using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021.Days
{
    public class Day20 : Day
    {
        readonly Dictionary<int, char> convertor;
        readonly char[,] image;
        public Day20() : base("20")
        {
            convertor = new Dictionary<int, char>();
            for (int i = 0; i < input[0].Length; i++)
            {
                convertor.Add(i, input[0][i]);
            }

            long xdim = input[2].Length;
            long ydim = input.Count - 2;
            image = new char[ydim, xdim];
            for(int i = 0; i < xdim; i++)
            {
                for(int j = 0; j < ydim; j++)
                {
                    image[j,i] = input[j+2][i];
                }
            }
        }

        public override string Assignment1()
        {
            char[,] pic = image;
            for(int i = 0; i < 2; i++)
            {
                pic = ProcessStep(pic, i);
            }

            long counter = 0;
            foreach(char c in pic)
            {
                if (c == '#')
                    counter++;
            }
            return counter.ToString();
        }

        public override string Assignment2()
        {
            char[,] pic = image;
            for (int i = 0; i < 50; i++)
            {
                pic = ProcessStep(pic, i);
            }

            long counter = 0;
            foreach (char c in pic)
            {
                if (c == '#')
                    counter++;
            }
            return counter.ToString();
        }

        private char[,] ProcessStep(char[,] start, int step)
        {
            char def = '.';
            if (convertor[0] == '#')
            {
                if(step%2 == 1 || convertor[511] == '#')
                    def = '#';
            }

            char[,] response = new char[start.GetLength(0)+2, start.GetLength(1)+2];
            for(int i = 0; i < response.GetLength(0); i++)
            {
                for (int j = 0; j < response.GetLength(1); j++)
                {
                    response[i, j] = CalculateValue(j, i, def, start);
                }
            }
            return response;
        }

        private char CalculateValue(int x, int y, char def, char[,] start)
        {
            int count = 0;
            int maxx = start.GetLength(1);
            int maxy = start.GetLength(0);

            count += '#' == ((x > 1 && y > 1) ? start[y - 2, x - 2] : def) ? 256 : 0;
            count += '#' == ((x > 0 && x < maxx+1 && y > 1) ? start[y - 2, x - 1] : def) ? 128 : 0;
            count += '#' == ((x < maxx && y > 1) ? start[y - 2, x] : def) ? 64 : 0;
            count += '#' == ((x > 1 && y > 0 && y < maxy+1) ? start[y - 1, x - 2] : def) ? 32 : 0;
            count += '#' == ((x > 0 && x < maxx+1 && y > 0 && y < maxy+1) ? start[y - 1, x - 1] : def) ? 16 : 0;
            count += '#' == ((x < maxx && y > 0 && y < maxy+1) ? start[y - 1, x] : def) ? 8 : 0;
            count += '#' == ((x > 1 && y < maxy) ? start[y, x - 2] : def) ? 4 : 0;
            count += '#' == ((x > 0 && x < maxx+1 && y < maxy) ? start[y , x - 1] : def) ? 2 : 0;
            count += '#' == ((x < maxx && y < maxy) ? start[y,x] : def) ? 1 : 0;

            return convertor[count];
        }
    }
}
