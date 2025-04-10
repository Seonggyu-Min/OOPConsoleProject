using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject
{
    public static class GameManager
    {
        public static void GameOverReason(string reason)
        {
            Util.PrintText(reason, 100, ConsoleColor.Red);
            Util.DelayedText("GAME OVER");
            Console.WriteLine();
            Util.PrintText("아무 키나 눌러 끝냅니다...", 100, ConsoleColor.Red);
            Console.ReadKey(true);
            Game.gameOver = true;
        }



    }
}
