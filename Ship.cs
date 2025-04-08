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

        public Dictionary<(int x, int y), ShipRoomLocation> Room { get; private set; }

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

            Room = new Dictionary<(int x, int y), ShipRoomLocation>
            {
                { (1, 3), ShipRoomLocation.AddonBay },
                { (5, 3), ShipRoomLocation.Cockpit }
            };
        }
        
        public void PrintMap()
        {
            for (int y = 0; y < MapData.GetLength(0); y++)
            {
                for (int x = 0; x < MapData.GetLength(1); x++)
                {
                    Console.Write(MapData[y, x]);
                }
                Console.WriteLine();
            }
        }

    }

}

