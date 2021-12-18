using System;
using System.Collections.Generic;
using System.Text;
using Advent_of_Code_2021.Day16classes;

namespace Advent_of_Code_2021.Days
{
    public class Day16 : Day
    {
        Packet start;
        string currentBinairy;
        public Day16() : base("16")
        {
            currentBinairy = ConvertToBinairy(input[0]);
            CreatePackets();
        }

        public override string Assignment1()
        {
            return start.SumVersionNumbers().ToString();
        }

        public override string Assignment2()
        {
            return start.GetValue().ToString();
        }

        private string ConvertToBinairy(string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach(char c in s)
            {
                switch (c)
                {
                    case '0': sb.Append("0000"); break;
                    case '1': sb.Append("0001"); break;
                    case '2': sb.Append("0010"); break;
                    case '3': sb.Append("0011"); break;
                    case '4': sb.Append("0100"); break;
                    case '5': sb.Append("0101"); break;
                    case '6': sb.Append("0110"); break;
                    case '7': sb.Append("0111"); break;
                    case '8': sb.Append("1000"); break;
                    case '9': sb.Append("1001"); break;
                    case 'A': sb.Append("1010"); break;
                    case 'B': sb.Append("1011"); break;
                    case 'C': sb.Append("1100"); break;
                    case 'D': sb.Append("1101"); break;
                    case 'E': sb.Append("1110"); break;
                    case 'F': sb.Append("1111"); break;
                }
            }
            return sb.ToString();
        }

        private long ConvertBinairy(string binairy)
        {
            long answer = 0;
            long multiplier = 1;
            
            for(int i = binairy.Length-1; i >=0; i--)
            {
                if (binairy[i] == '1')
                    answer += multiplier;
                multiplier *= 2;
            }

            return answer;
        }

        private void CreatePackets()
        {
            int version = (int)ConvertBinairy(currentBinairy[0..3]);
            int type = (int)ConvertBinairy(currentBinairy[3..6]);
            
            start = new Packet(version, type);
            if(type == 4)
            {
                currentBinairy = currentBinairy[6..];
                start.SetValue(ConvertBinairy(ReadValue()));
            }
            else
            {
                if(currentBinairy[6] == '1')
                {
                    int numberOfPackets = (int)ConvertBinairy(currentBinairy[7..18]);
                    currentBinairy = currentBinairy[18..];
                    for (int i = 0; i < numberOfPackets; i++)
                    {
                        CreateSubPacket(currentBinairy.Length, start);
                    }
                }
                else
                {
                    int bits = (int)ConvertBinairy(currentBinairy[7..22]);
                    currentBinairy = currentBinairy[22..];
                    while (bits > 0)
                    {
                        bits -= CreateSubPacket(bits, start);
                    }
                }
            }
        }

        private int CreateSubPacket(int maxLength, Packet parent)
        {
            int version = (int)ConvertBinairy(currentBinairy[0..3]);
            int type = (int)ConvertBinairy(currentBinairy[3..6]);
            int usedLength = 6;

            Packet current = new Packet(version, type);
            if (type == 4)
            {
                currentBinairy = currentBinairy[6..];
                string value = ReadValue();
                usedLength += (value.Length * 5) / 4;
                current.SetValue(ConvertBinairy(value));
            }
            else
            {
                if (currentBinairy[6] == '1')
                {
                    int numberOfPackets = (int)ConvertBinairy(currentBinairy[7..18]);
                    usedLength += 12;
                    currentBinairy = currentBinairy[18..];
                    for (int i = 0; i < numberOfPackets; i++)
                    {
                        usedLength += CreateSubPacket(currentBinairy.Length, current);
                    }
                }
                else
                {
                    int bits = (int)ConvertBinairy(currentBinairy[7..22]);
                    usedLength += 16 + bits;
                    currentBinairy = currentBinairy[22..];
                    while (bits > 0)
                    {
                        bits -= CreateSubPacket(bits, current);
                    }
                }
            }
            parent.AddPacket(current);
            return usedLength;
        }

        private string ReadValue()
        {
            StringBuilder sb = new StringBuilder();
            int position = 0;
            bool lastNotFound = true;
            while (lastNotFound)
            {
                if(currentBinairy[position] == '0')
                    lastNotFound = false;
                sb.Append(currentBinairy[(position + 1)..(position + 5)]);
                position += 5;
            }
            currentBinairy = currentBinairy[position..];
            return sb.ToString();
        }
    }
}
