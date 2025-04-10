using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Scenes
{
    public class CockpitScene : BaseScene
    {
        private ConsoleKey input;

        GalaxyMapPointer galaxyMapPointer;
        GalaxyMap galaxyMap;

        public CockpitScene()
        {
            name = "Cockpit";
            
            galaxyMap = new GalaxyMap();

            galaxyMapPointer = new GalaxyMapPointer(5, 1);
            galaxyMapPointer.PointerPosition = new Vector2(5, 1);
            galaxyMapPointer.IsMovableMap = galaxyMap.Map;
        }


        public override void Render()
        {
            Console.Clear();
            galaxyMap.PrintGalaxyMap();
            galaxyMapPointer.Print();

            Console.SetCursorPosition(0, 14);
            ResourceManager.PrintFuel();
            Console.WriteLine();
            ResourceManager.PrintOxygen();

            Console.SetCursorPosition(15, 3);
            Util.PrintText("이 곳은 이동할 은하계를 선택할 수 있는 지도입니다.", ConsoleColor.Cyan);
            Console.SetCursorPosition(15, 4);
            Util.PrintText("WASD 혹은 방향키로 포인터를 이동하세요", ConsoleColor.Cyan);
            Console.SetCursorPosition(15, 5);
            Util.PrintText("방문하고자 하는 은하계에서 E를 누르면 선택할 수 있습니다.", ConsoleColor.Cyan);
            Console.SetCursorPosition(15, 6);
            Util.PrintText("뒤로 가려면 Z키 혹은 esc키를 누르세요.", ConsoleColor.Cyan);
        }
        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }
        public override void Update()
        {
            galaxyMapPointer.Move(input);
        }
        public override void Result()
        {
            var pointerPos = (galaxyMapPointer.PointerPosition.x, galaxyMapPointer.PointerPosition.y);
            if (TravelState.GalaxyNodePositionMap.TryGetValue(pointerPos, out int nodeId) && input == ConsoleKey.E)
            {
                GalaxyNodeInfo nodeInfo = TravelState.GetNodeInfo(nodeId);
                Game.PushScene(new GalaxyInfoScene(nodeInfo));
            }
            Util.EscapeScene(input);
        }
    }
}
