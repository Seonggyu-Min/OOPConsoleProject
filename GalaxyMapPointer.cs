using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject
{
    public class GalaxyMapPointer
    {
        public Vector2 PointerPosition { get; set; }
        public bool[,] IsMovableMap { get; set; }

        public GalaxyMapPointer(int x, int y)
        {
            PointerPosition = new Vector2(x, y);
        }

        public void Print()
        {
            Console.SetCursorPosition(PointerPosition.x, PointerPosition.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('+');
            Console.ResetColor();
        }

        public void Move(ConsoleKey input)
        {
            Vector2 targetPos = PointerPosition;
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
                PointerPosition = targetPos;
            }
        }
    }
}
