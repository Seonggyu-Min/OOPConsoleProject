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
            if (galaxyMap.GalaxyRoom.TryGetValue(pointerPos, out GalaxyNodeInfo nodeInfo) && input == ConsoleKey.E)
            {
                Game.PushScene(new GalaxyInfoScene(nodeInfo));
            }
            Util.EscapeScene(input);
        }
    }
}
