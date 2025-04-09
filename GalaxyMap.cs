
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject
{

    public class GalaxyMap
    {
        public char[,] MapData { get; private set; }
        public bool[,] Map { get; private set; }

        public GalaxyMap()
        {
            MapData = new char[,]
            {
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                { '#', ' ', ' ', ' ', ' ', 'S', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', '/', ' ', '\\', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', '@', ' ', ' ', ' ', '@', ' ', ' ', '#' },
                { '#', ' ', ' ', '/', ' ', '\\', ' ', '|', ' ', ' ', '#' },
                { '#', ' ', ' ', '@', ' ', '@', ' ', '@', ' ', ' ', '#' },
                { '#', ' ', ' ', '|', ' ', '|', '\\', '|', ' ', ' ', '#' },
                { '#', ' ', ' ', '@', ' ', '@', ' ', '@', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', '\\', '/', ' ', '|', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', '@', ' ', ' ', '@', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', '\\', '/', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', 'E', ' ', ' ', ' ', '#' },
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
            };


            Map = new bool[13, 11];

            for (int y = 0; y < MapData.GetLength(0); y++)
            {
                for (int x = 0; x < MapData.GetLength(1); x++)
                {
                    Map[y, x] = MapData[y, x] == '#' ? false : true;
                }
            }
        }

        public void PrintGalaxyMap()
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
