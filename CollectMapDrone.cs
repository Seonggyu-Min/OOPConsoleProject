using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject
{
    public class CollectMapDrone
    {
        public Vector2 DronePosition { get; set; }
        public bool[,] IsMovableMap { get; set; }

        public CollectMapDrone(int x, int y) 
        {
            DronePosition = new Vector2(x, y);
        }

        public void Print()
        {
            Console.SetCursorPosition(DronePosition.x, DronePosition.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('D');
            Console.ResetColor();
        }

        public void Move(ConsoleKey input)
        {
            Vector2 targetPos = DronePosition;
            switch (input)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    targetPos.y--;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    targetPos.y++;
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    targetPos.x--;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    targetPos.x++;
                    break;
            }

            if (IsMovableMap[targetPos.y, targetPos.x] == true)
            {
                DronePosition = targetPos;
            }
        }

    }
}
