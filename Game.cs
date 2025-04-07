using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject
{
    class Game
    {
        private static bool gameOver;

        public static void Start()
        {
            Console.CursorVisible = false;

            gameOver = false;
        }

        public static void Run()
        {
            Start();

            while (!gameOver)
            {

            }
        }

        public static void End()
        {
            gameOver = true;
        }
    }
}
