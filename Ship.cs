using OOPConsoleProject.Enums;
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

        public Dictionary<AddonType, Addon> InstalledAddons { get; private set; }

        public Dictionary<(int x, int y), AddonType> AddonLocation { get; private set; }

        public Ship()
        {
            MapData = new char[7, 7]
            {
                { '#', '#', '#', '#', '#', '#', '#' },
                { '#', 'F', '#', 'O', '#', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', 'A', ' ', ' ', ' ', 'C', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', 'R', '#', 'I', '#', ' ', '#' },
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


            InstalledAddons = new Dictionary<AddonType, Addon>();

            AddonFactory factory = new AddonFactory();
            InstalledAddons[AddonType.Fuel] = factory.CreateAddon("기본 연료 포집 드론");
            InstalledAddons[AddonType.Oxygen] = factory.CreateAddon("기본 산소 포집 드론");
            InstalledAddons[AddonType.Interaction] = factory.CreateAddon("기본 상호작용 드론");
            InstalledAddons[AddonType.Radar] = factory.CreateAddon("기본 레이더");

            AddonLocation = new Dictionary<(int x, int y), AddonType>

            {
                { (1, 1), AddonType.Fuel },
                { (1, 5), AddonType.Oxygen },
                { (3, 1), AddonType.Radar },
                { (3, 5), AddonType.Interaction }
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

