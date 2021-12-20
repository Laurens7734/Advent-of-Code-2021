using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021.Day19classes
{
    public class Scanner
    {
        public int Id { get; }
        readonly int overlap;
        Dictionary<string,Beacon> knownBeacons;
        public long xcord, ycord, zcord;

        public Scanner(int i, int o)
        {
            Id = i;
            overlap = o;
            knownBeacons = new Dictionary<string, Beacon>();
        }

        public void AddBeacon(Beacon b)
        {
            if (knownBeacons.ContainsKey(b.ToString()))
                return;

            foreach(Beacon be in knownBeacons.Values)
            {
                be.AddNeighbour(b);
                b.AddNeighbour(be);
            }
            knownBeacons.Add(b.ToString(), b);
        }

        public long GetBeaconCount()
        {
            return knownBeacons.Count;
        }

        public List<Tuple<Beacon, Beacon>> FindOverlap(Scanner s)
        {
            List<Tuple<Beacon, Beacon>> matches = new List<Tuple<Beacon, Beacon>>();
            foreach(Beacon b in knownBeacons.Values)
            {
                foreach(Beacon be in s.knownBeacons.Values)
                {
                    if(b.MatchDistances(overlap-1, be))
                    {
                        matches.Add(new Tuple<Beacon, Beacon>(b, be));
                    }
                }
            }
            if (matches.Count >= overlap)
                return matches;
            return null;
        }

        public List<Beacon> GetTranslatedList(Func<Beacon, Beacon> translate)
        {
            List<Beacon> beacons = new List<Beacon>();
            foreach(Beacon b in knownBeacons.Values)
            {
                Beacon translation = translate(b);
                beacons.Add(new Beacon(translation.xcord + xcord, translation.ycord + ycord, translation.zcord + zcord));
            }
            return beacons;
        }

        public void SetCords(long x, long y, long z)
        {
            xcord = x;
            ycord = y;
            zcord = z;
        }
    }
}
