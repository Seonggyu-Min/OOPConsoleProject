﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject
{
    public class Player
    {
        public Vector2 position { get; set; }
        public bool[,] IsMovableMap { get; set; }

        public Player(int x, int y)
        {
            position = new Vector2(x, y);
        }

        public void Print()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('P');
            Console.ResetColor();
        }

        public void Move(ConsoleKey input)
        {
            Vector2 targetPos = position;
            switch(input)
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
                position = targetPos;
            }
        }
    }
}
