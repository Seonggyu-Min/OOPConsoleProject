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
                Console.Clear();
                Console.WriteLine("뒤로 갑니다");
                ReadKey();
                Game.PopScene();
            }
        }
        public static void EscapeSceneWOKey()
        {
            Console.WriteLine("뒤로 갑니다");
            ReadKey();
            Game.PopScene();
        }


        public static void PrintText(string text)
        {
            Console.WriteLine(text);
        }

        public static void PrintText(string text, int time)
        {
            Console.WriteLine(text);
            Thread.Sleep(time);
        }

        public static void PrintText(string text, ConsoleColor textColor)
        {
            Console.ForegroundColor = textColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void PrintText(string text, int time, ConsoleColor textColor)
        {
            Console.ForegroundColor = textColor;
            Thread.Sleep(time);
            Console.WriteLine(text); 
            Console.ResetColor();
        }

        public static void DelayedText(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }
        }

        public static void ReadKey()
        {
            Console.WriteLine();
            Util.PrintText("아무 키나 누르세요...", ConsoleColor.Green);
            Console.ReadKey(true);
        }
    }
}
