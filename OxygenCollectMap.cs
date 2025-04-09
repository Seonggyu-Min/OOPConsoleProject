using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject
{
    public class OxygenCollectMap
    {
        public char[,] MapData { get; private set; }
        public bool[,] Map { get; private set; }

        public HashSet<(int x, int y)> OxygenPosition { get; private set; }
        public OxygenCollectMap()
        {
            MapData = new char[7, 7]
            {
                { '#', '#', '#', '#', '#', '#', '#' },
                { '#', ' ', '#', '&', '#', '&', '#' },
                { '#', ' ', ' ', ' ', '&', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', '&', ' ', ' ', ' ', '#' },
                { '#', ' ', '#', ' ', '#', '&', '#' },
                { '#', '#', '#', '#', '#', '#', '#' },
            };

            Map = new bool[7, 7];

            for (int y = 0; y < MapData.GetLength(0); y++)
            {
                for (int x = 0; x < MapData.GetLength(1); x++)
                {
                    Map[y, x] = MapData[y, x] == '#' ? false : true;
                    if (MapData[y, x] == '*')
                        OxygenPosition.Add((x, y));
                }
            }
        }

        public void PrintOxygenMap()
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
