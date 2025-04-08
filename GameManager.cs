using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject
{
    public class GameManager
    {
        public void GameOverReason(string reason)
        {
            Console.WriteLine($"{reason}의 이유로 게임오버입니다.");
            Game.gameOver = true;
        }



    }
}
