using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject
{
    public class Ship
    {
        public char[,] MapData { get; private set; }
        public bool[,] Map { get; private set; }
        public Ship()
        {
            MapData = new char[7, 7]
            {
                { '#', '#', '#', '#', '#', '#', '#' },
                { '#', ' ', '#', ' ', '#', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', '#', ' ', '#', ' ', '#' },
                { '#', '#', '#', '#', '#', '#', '#' },
            };

            Map = new bool[7, 7];

            for (int y = 0; y < MapData.GetLength(0); y++)
            {
                for (int x = 0; x < MapData.GetLength(1); x++)
                {
                    Map[y, x] = MapData[y, x] == '#' ? false : true;
                }
            }
        }
    }

}

