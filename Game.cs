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
        public static Ship ship { get; set; }
        public static Player player { get; set; }


        public static void Start()
        {
            Console.CursorVisible = false;

            gameOver = false;

            sceneDic = new Dictionary<string, BaseScene>();

            ship = new Ship();
            player = new Player(3, 3);

            sceneDic.Add("Title", new TitleScene());
            sceneDic.Add("Ship", new ShipScene());
            sceneDic.Add("Cockpit", new CockpitScene());
            // sceneDic.Add("GalaxyInfo", new GalaxyInfoScene());
            // sceneDic.Add("GalaxyResult", new GalaxyResultScene());
            sceneDic.Add("Ending", new EndingScene());

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
            curScene = sceneDic[sceneName];
        }

        public static void ChangeScene(BaseScene scene)
        {
            curScene = scene;
        }

        public static void PushScene(BaseScene scene)
        {
            sceneStack.Push(curScene);
            curScene = scene;
        }

        public static void PopScene()
        {
            if (sceneStack.Count > 0)
            {
                curScene = sceneStack.Pop();
            }

            else
            {
                Console.WriteLine("스택이 0 - 디버그용 문구");
                Util.ReadKey();
            }    
        }

        public static void SceneStackClear()
        {
            sceneStack.Clear();
        }

    }
}
