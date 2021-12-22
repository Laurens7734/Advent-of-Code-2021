using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2021.Day22classes
{
    public class Cuboid
    {
        readonly long minx, maxx, miny, maxy, minz, maxz; 
        readonly bool isOn;
        public Cuboid(long lx, long hx, long ly, long hy, long lz, long hz, bool on)
        {
            minx = lx;
            maxx = hx;
            miny = ly;
            maxy = hy;
            minz = lz;
            maxz = hz;
            isOn = on;
        }

        public long Count()
        {
            if (isOn)
            {
                return (maxx+1 - minx) * (maxy+1 - miny) * (maxz+1 - minz);
            }
            return 0;
        }

        public long Count(Cuboid dimentions)
        {
            if (isOn)
            {
                if (NoOverlap(dimentions))
                    return 0;
                long hx = Math.Min(maxx ,dimentions.maxx);
                long lx = Math.Max(minx, dimentions.minx);
                long hy = Math.Min(maxy, dimentions.maxy);
                long ly = Math.Max(miny, dimentions.miny);
                long hz = Math.Min(maxz, dimentions.maxz);
                long lz = Math.Max(minz, dimentions.minz);
                long total = (hx + 1 - lx) * (hy + 1 - ly) * (hz + 1 - lz);
                return total;
            }
            return 0;
        }

        public bool FullyContained(Cuboid cube)
        {
            return (cube.minx <= minx && cube.maxx >= maxx && cube.miny <= miny && cube.maxy >= maxy && cube.minz <= minz && cube.maxz >= maxz);
        }

        public bool NoOverlap(Cuboid cube)
        {
            return (minx > cube.maxx || maxx < cube.minx || miny > cube.maxy || maxy < cube.miny || minz > cube.maxz || maxz < cube.minz);
        }

        public List<Cuboid> RemoveOverlap(Cuboid cube)
        {
            List<Cuboid> response = new List<Cuboid>() { this };
            if(cube.minx >= minx && cube.minx <= maxx)
            {
                List<Cuboid> updatedResponse = new List<Cuboid>();
                foreach(Cuboid c in response)
                {
                    updatedResponse.AddRange(c.Split(cube.minx, false, 'x'));
                }
                response = updatedResponse;
            }
            if (cube.maxx >= minx && cube.maxx <= maxx)
            {
                List<Cuboid> updatedResponse = new List<Cuboid>();
                foreach (Cuboid c in response)
                {
                    updatedResponse.AddRange(c.Split(cube.maxx, true, 'x'));
                }
                response = updatedResponse;
            }
            if (cube.miny >= miny && cube.miny <= maxy)
            {
                List<Cuboid> updatedResponse = new List<Cuboid>();
                foreach (Cuboid c in response)
                {
                    updatedResponse.AddRange(c.Split(cube.miny, false, 'y'));
                }
                response = updatedResponse;
            }
            if (cube.maxy >= miny && cube.maxy <= maxy)
            {
                List<Cuboid> updatedResponse = new List<Cuboid>();
                foreach (Cuboid c in response)
                {
                    updatedResponse.AddRange(c.Split(cube.maxy, true, 'y'));
                }
                response = updatedResponse;
            }
            if (cube.minz >= minz && cube.minz <= maxz)
            {
                List<Cuboid> updatedResponse = new List<Cuboid>();
                foreach (Cuboid c in response)
                {
                    updatedResponse.AddRange(c.Split(cube.minz, false, 'z'));
                }
                response = updatedResponse;
            }
            if (cube.maxz >= minz && cube.maxz <= maxz)
            {
                List<Cuboid> updatedResponse = new List<Cuboid>();
                foreach (Cuboid c in response)
                {
                    updatedResponse.AddRange(c.Split(cube.maxz, true, 'z'));
                }
                response = updatedResponse;
            }
            
            return response.FindAll(a => a.NoOverlap(cube));
        }

        public List<Cuboid> Split(long cord, bool addToLower, char axis)
        {
            List<Cuboid> allCuboids = new List<Cuboid>();

            long newhigh = cord - 1;
            long newlow = cord + 1;
            if (addToLower)
                newhigh++;
            else
                newlow--;

            if (axis == 'x')
            {
                if(cord >= minx && cord <= maxx)
                {
                    Cuboid a = new Cuboid(minx, newhigh, miny, maxy, minz, maxz, isOn);
                    Cuboid b = new Cuboid(newlow, maxx, miny, maxy, minz, maxz, isOn);
                    if(!(a.minx > a.maxx))
                        allCuboids.Add(a);
                    if (!(b.minx > b.maxx))
                        allCuboids.Add(b);
                }
            }
            if (axis == 'y')
            {
                if (cord >= miny && cord <= maxy)
                {
                    Cuboid a = new Cuboid(minx, maxx, miny, newhigh, minz, maxz, isOn);
                    Cuboid b = new Cuboid(minx, maxx, newlow, maxy, minz, maxz, isOn);
                    if (!(a.miny > a.maxy))
                        allCuboids.Add(a);
                    if (!(b.miny > b.maxy))
                        allCuboids.Add(b);
                }
            }
            if (axis == 'z')
            {
                if (cord >= minz && cord <= maxz)
                {
                    Cuboid a = new Cuboid(minx, maxx, miny, maxy, minz, newhigh, isOn);
                    Cuboid b = new Cuboid(minx, maxx, miny, maxy, newlow, maxz, isOn);
                    if (!(a.minz > a.maxz))
                        allCuboids.Add(a);
                    if (!(b.minz > b.maxz))
                        allCuboids.Add(b);
                }
            }
            if (allCuboids.Count == 0)
                allCuboids.Add(this);
            return allCuboids;
        }

        public override string ToString()
        {
            return $"{Count()} are {isOn}";
        }
    }
}
