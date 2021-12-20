using System;
using System.Collections.Generic;
using System.Text;
using Advent_of_Code_2021.Day19classes;

namespace Advent_of_Code_2021.Days
{
    public class Day19 : Day
    {
        List<Scanner> scanners;
        Scanner s0;
        public Day19() : base("19")
        {
            scanners = new List<Scanner>();
            Scanner sc = null;
            foreach(string s in input)
            {
                if (s.Equals(""))
                    continue;
                if (s.StartsWith("---"))
                {
                    sc = new Scanner(int.Parse(s.Split(' ')[2]), 12);
                    scanners.Add(sc);
                    continue;
                }
                long[] cords = Array.ConvertAll(s.Split(','), x => long.Parse(x));
                Beacon b = new Beacon(cords[0], cords[1], cords[2]);
                sc.AddBeacon(b);
            }
            s0 = scanners.Find(x => x.Id == 0);
            s0.SetCords(0, 0, 0);
        }

        public override string Assignment1()
        {
            List<Scanner> haveNoCords = new List<Scanner>(scanners);
            haveNoCords.Remove(s0);
            bool looking = true;
            while (looking)
            {
                List<int> done = new List<int>();
                foreach(Scanner s in haveNoCords)
                {
                    List<Tuple<Beacon, Beacon>> pairs = s0.FindOverlap(s);
                    if (pairs == null)
                        continue;

                    done.Add(s.Id);
                    Func<Beacon, Beacon> translation = CalculateTranslation(pairs[0], pairs[1]);
                    long scanx = pairs[0].Item1.xcord - translation(pairs[0].Item2).xcord;
                    long scany = pairs[0].Item1.ycord - translation(pairs[0].Item2).ycord;
                    long scanz = pairs[0].Item1.zcord - translation(pairs[0].Item2).zcord;
                    s.SetCords(scanx, scany, scanz);
                    foreach (Beacon b in s.GetTranslatedList(translation))
                    {
                        s0.AddBeacon(b);
                    }
                }
                if (done.Count == haveNoCords.Count)
                    looking = false;
                else
                    haveNoCords.RemoveAll(x => done.Contains(x.Id));
            }
            return s0.GetBeaconCount().ToString();
        }

        public override string Assignment2()
        {
            long biggest = 0;
            for(int i = 0; i < scanners.Count-1; i++)
            {
                for(int j = i+1; j < scanners.Count; j++)
                {
                    long dist = Math.Abs(scanners[i].xcord - scanners[j].xcord) + Math.Abs(scanners[i].ycord - scanners[j].ycord) + Math.Abs(scanners[i].zcord - scanners[j].zcord);
                    if (dist > biggest)
                        biggest = dist;
                }
            }
            return biggest.ToString();
        }

        private Func<Beacon, Beacon> CalculateTranslation(Tuple<Beacon,Beacon> b1, Tuple<Beacon,Beacon> b2)
        {
            long xdif1 = b1.Item1.xcord - b2.Item1.xcord;
            long ydif1 = b1.Item1.ycord - b2.Item1.ycord;
            long zdif1 = b1.Item1.zcord - b2.Item1.zcord;

            long xdif2 = b1.Item2.xcord - b2.Item2.xcord;
            long ydif2 = b1.Item2.ycord - b2.Item2.ycord;
            long zdif2 = b1.Item2.zcord - b2.Item2.zcord;

            Func<Beacon, long> xtrans = FindTranslation(xdif1, xdif2, ydif2, zdif2);
            Func<Beacon, long> ytrans = FindTranslation(ydif1, xdif2, ydif2, zdif2);
            Func<Beacon, long> ztrans = FindTranslation(zdif1, xdif2, ydif2, zdif2);

            return (a => new Beacon(xtrans(a), ytrans(a), ztrans(a)));
        }

        private Func<Beacon, long> FindTranslation(long real, long altx, long alty, long altz)
        {
            if (real == altx)
                return (a => a.xcord);
            if (real == alty)
                return (a => a.ycord);
            if (real == altz)
                return (a => a.zcord);
            if (real == -altx)
                return (a => -a.xcord);
            if (real == -alty)
                return (a => -a.ycord);
            if (real == -altz)
                return (a => -a.zcord);
            return (a => 0);
        }
    }
}
