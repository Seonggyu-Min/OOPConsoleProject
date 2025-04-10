using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Scenes
{
    public class EndingScene : BaseScene
    {
        public override void Render()
        {
            Console.Clear();
            Util.PrintText("지구에 도착했습니다!", 500);
            Util.PrintText("긴 여정 끝에 무사히 돌아왔습니다...", 1000);
            Util.PrintText("축하합니다!", 1000, ConsoleColor.Cyan);
            Console.WriteLine();
            Util.DelayedText("GAME CLEAR!!!");
        }

        public override void Input()
        {
            Util.ReadKey();
        }

        public override void Update() { }

        public override void Result()
        {
            Game.gameOver = true;
        }
    }
}
