using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject
{
    public class FuelCollectMap
    {
        public char[,] MapData { get; private set; }
        public bool[,] Map { get; private set; }

        public HashSet<(int x, int y)> FuelPosition { get; private set; }

        public FuelCollectMap()
        {
            MapData = new char[7, 7]
            {
                { '#', '#', '#', '#', '#', '#', '#' },
                { '#', ' ', '#', '*', '#', '*', '#' },
                { '#', ' ', ' ', ' ', '*', ' ', '#' },
                { '#', 'E', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', '*', ' ', ' ', ' ', '#' },
                { '#', ' ', '#', ' ', '#', '*', '#' },
                { '#', '#', '#', '#', '#', '#', '#' },
            };

            Map = new bool[7, 7];

            FuelPosition = new HashSet<(int x, int y)>();

            for (int y = 0; y < MapData.GetLength(0); y++)
            {
                for (int x = 0; x < MapData.GetLength(1); x++)
                {
                    Map[y, x] = MapData[y, x] == '#' ? false : true;
                    if (MapData[y, x] == '*')
                        FuelPosition.Add((x, y));
                }
            }
        }

        public void PrintFuelMap()
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
