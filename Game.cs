using OOPConsoleProject.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject
{
    class Game
    {
        public static bool gameOver { get; set; }

        private static Dictionary<string, BaseScene> sceneDic;
        private static BaseScene curScene;

        public static void Start()
        {
            Console.CursorVisible = false;

            gameOver = false;

            sceneDic = new Dictionary<string, BaseScene>();

            sceneDic.Add("Title", new TitleScene());
            sceneDic.Add("Ship", new ShipScene());

            curScene = sceneDic["Title"];

        }

        public static void Run()
        {
            Start();

            while (!gameOver)
            {
                Console.Clear();
                curScene.Render();
                curScene.Input();
                Console.WriteLine();
                curScene.Update();
                Console.WriteLine();
                curScene.Result();
            }
        }

        public static void End()
        {
            gameOver = true;
        }

        public static void ChangeScene(string sceneName)
        {
            curScene.Exit();
            curScene = sceneDic[sceneName];
            curScene.Enter();
        }
    }
}
