using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021.Day16classes
{
    public class Packet
    {
        public int version;
        public int typeId;
        public long value;
        List<Packet> subPackets;

        public Packet(int v, int t)
        {
            version = v;
            typeId = t;
            subPackets = new List<Packet>();
        }

        public void SetValue(long val)
        {
            value = val;
        }

        public void AddPacket(Packet p)
        {
            subPackets.Add(p);
        }

        public int SumVersionNumbers()
        {
            int answer = version;
            foreach(Packet p in subPackets)
            {
                answer += p.SumVersionNumbers();
            }
            return answer;
        }

        public long GetValue()
        {
            switch (typeId)
            {
                case 0: return Sum();
                case 1: return Product();
                case 2: return MinVal();
                case 3: return MaxVal();
                case 4: return value;
                case 5: return Greater();
                case 6: return Smaller();
                case 7: return Equal();
            }
            return -1;
        }

        private long Sum()
        {
            long answer = 0;
            foreach (Packet p in subPackets)
                answer += p.GetValue();
            return answer;
        }

        private long Product()
        {
            long answer = 1;
            foreach (Packet p in subPackets)
                answer *= p.GetValue();
            return answer;
        }

        private long MinVal()
        {
            long answer = long.MaxValue;
            foreach (Packet p in subPackets)
            {
                if (p.GetValue() < answer)
                    answer = p.GetValue();
            }
            return answer;
        }

        private long MaxVal()
        {
            long answer = 0;
            foreach (Packet p in subPackets)
            {
                if (p.GetValue() > answer)
                    answer = p.GetValue();
            }
            return answer;
        }

        private long Greater()
        {
            if (subPackets[0].GetValue() > subPackets[1].GetValue())
                return 1;
            else
                return 0;
        }

        private long Smaller()
        {
            if (subPackets[0].GetValue() < subPackets[1].GetValue())
                return 1;
            else
                return 0;
        }

        private long Equal()
        {
            if (subPackets[0].GetValue() == subPackets[1].GetValue())
                return 1;
            else
                return 0;
        }
    }
}
