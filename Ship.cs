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
        private char[,] mapData = new char[,]
        {
                { '#', '#', '#', '#', '#', '#', '#' },
                { '#', ' ', '#', ' ', '#', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', '#', ' ', '#', ' ', '#' },
                { '#', '#', '#', '#', '#', '#', '#' },
        };

        private bool[,] map = new bool[7, 7];

        

        public Ship()
        {
            for (int y = 0; y < mapData.GetLength(0); y++)
            {
                for (int x = 0; x < mapData.GetLength(1); x++)
                {
                    map[y, x] = mapData[y, x] == '#' ? false : true;
                }
            }



        }
    }

}

