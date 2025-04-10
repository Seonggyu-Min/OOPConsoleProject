using OOPConsoleProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Scenes
{
    public class FuelCollectionScene : BaseScene
    {
        private ConsoleKey input;

        FuelCollectMap map;
        CollectMapDrone drone;
        Addon addon;
        GalaxyNodeInfo nodeInfo;

        public FuelCollectionScene(Addon addon, GalaxyNodeInfo nodeInfo)
        {
            name = "FuelCollection";

            this.addon = addon;
            this.nodeInfo = nodeInfo;

            map = new FuelCollectMap();
            drone = new CollectMapDrone(1, 3);
            drone.DronePosition = new Vector2(1, 3);
            drone.IsMovableMap = map.Map;
        }

        public override void Render()
        {
            Console.Clear();
            map.PrintFuelMap();
            drone.Print();

            Console.SetCursorPosition(0, 14);
            ResourceManager.PrintFuel();
            Console.WriteLine();
            ResourceManager.PrintOxygen();

            Console.SetCursorPosition(15, 2);
            Util.PrintText("WASD 또는 방향키로 드론을 움직여 연료 * 을 모두 수집하세요!", ConsoleColor.Cyan);

            if (map.FuelPosition.Count == 0)
            {
                Console.SetCursorPosition(15, 4);
                Util.PrintText("모든 연료를 수집했습니다! E로 향하여 복귀하세요", ConsoleColor.Green);
                Console.ResetColor();
            }
        }

        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }
        public override void Update()
        {
            drone.Move(input);
        }

        public override void Result()
        {
            var dronePos = (drone.DronePosition.x, drone.DronePosition.y);

            if (map.FuelPosition.Contains(dronePos))
            {
                ResourceManager.ChargeFuel(1);
                //else if (addon.Grade == AddonGrade.AlienTech && addon.Type == AddonType.Fuel)
                //{
                //    int collect = 3;
                //    ResourceManager.ChargeFuel(collect);
                //}
                map.MapData[drone.DronePosition.y, drone.DronePosition.x] = ' ';
                map.FuelPosition.Remove(dronePos);
            }

            if (map.FuelPosition.Count == 0 && dronePos == (1, 3))
            {
                nodeInfo.IsFarmed = true;
                Game.PopScene();
            }
        }
    }
}
