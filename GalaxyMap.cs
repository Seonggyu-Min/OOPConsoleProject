
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

        public Dictionary<(int x, int y), GalaxyLocation> GalaxyRoom { get; private set; }

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

            GalaxyRoom = new Dictionary<(int x, int y), GalaxyLocation>
            {
                { (5, 1), GalaxyLocation.Start }, // 0번 Start
                
                { (3, 3), GalaxyLocation.Fuel }, // 1번
                { (7, 3), GalaxyLocation.Encounter },
                { (3, 5), GalaxyLocation.Oxygen },
                { (5, 5), GalaxyLocation.Encounter },
                { (7, 5), GalaxyLocation.Oxygen },
                { (3, 7), GalaxyLocation.Fuel },
                { (5, 7), GalaxyLocation.Fuel },
                { (7, 7), GalaxyLocation.Encounter },
                { (4, 9), GalaxyLocation.Encounter },
                { (7, 9), GalaxyLocation.Encounter }, // 10번

                { (6, 11), GalaxyLocation.End }, // 11번 End
            };
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
