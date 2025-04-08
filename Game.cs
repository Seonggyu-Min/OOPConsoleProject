using OOPConsoleProject.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject
{
    public class Game
    {
        public static bool gameOver { get; set; }

        private static Dictionary<string, BaseScene> sceneDic;
        private static BaseScene curScene;

        private static Stack<BaseScene> sceneStack = new Stack<BaseScene>();

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
            
        }

        public static void ChangeScene(string sceneName)
        {
            curScene.Exit();
            curScene = sceneDic[sceneName];
            curScene.Enter();
        }

        public static void PushScene(string sceneName)
        {
            sceneStack.Push(curScene);
            curScene.Exit();
            curScene = sceneDic[sceneName];
            curScene.Enter();
        }

        public static void PopScene(string sceneName)
        {
            if (sceneStack.Count > 0)
            {
                curScene.Exit();
                curScene = sceneStack.Pop();
                curScene.Enter();
            }
        }
    }
}
