using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject
{
    public static class Util
    {
        public static void EscapeScene(ConsoleKey input)
        {
            if (input == ConsoleKey.Z || input == ConsoleKey.Escape)
            {
                Console.WriteLine("뒤로 갑니다 - 디버그용 문구");
                Thread.Sleep(500);
                Game.PopScene();
            }
        }
        public static void EscapeSceneWOKey()
        {
            Console.WriteLine("뒤로 갑니다 - 디버그용 문구");
            Thread.Sleep(500);
            Game.PopScene();
        }


        public static void PrintText(string text) { }
    }
}
