using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject
{
    public class Player
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }

        public Player(int x, int y)
        {
            PosX = x;
            PosY = y;
        }

        public void Move(int dx, int dy)
        {
            PosX += dx;
            PosY += dy;
        }
    }
}
