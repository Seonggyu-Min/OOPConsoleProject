using OOPConsoleProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Scenes
{
    public class OxygenCollectionScene : BaseScene
    {
        private ConsoleKey input;

        OxygenCollectMap map;
        CollectMapDrone drone;
        Addon addon;
        GalaxyNodeInfo nodeInfo;


        public OxygenCollectionScene(Addon addon, GalaxyNodeInfo nodeInfo)
        {
            name = "OxygenCollection";

            this.addon = addon;
            this.nodeInfo = nodeInfo;

            map = new OxygenCollectMap();
            drone = new CollectMapDrone(1, 3);
            drone.DronePosition = new Vector2(1, 3);
            drone.IsMovableMap = map.Map;
        }

        public override void Render()
        {
            Console.Clear();
            map.PrintOxygenMap();
            drone.Print();

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
            drone.Move(input);
        }

        public override void Result()
        {
            var dronePos = (drone.DronePosition.x, drone.DronePosition.y);

            if (map.OxygenPosition.Contains(dronePos))
            {
                if (addon.Grade == AddonGrade.Basic && addon.Type == AddonType.Oxygen)
                {
                    int collect = 1;
                    ResourceManager.ChargeOxygen(collect);
                }
                else if (addon.Grade == AddonGrade.AlienTech && addon.Type == AddonType.Oxygen)
                {
                    int collect = 3;
                    ResourceManager.ChargeOxygen(collect);
                }
                map.MapData[drone.DronePosition.y, drone.DronePosition.x] = ' ';
                map.OxygenPosition.Remove(dronePos);
            }
            if (map.OxygenPosition.Count == 0)
            {
                Console.SetCursorPosition(0, 15);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("모든 산소를 수집했습니다! E로 향하여 복귀하세요");
                Console.ResetColor();

                if (dronePos == (1, 3))
                {
                    nodeInfo.IsFarmed = true;
                    Game.PopScene();
                }
            }
        }

    }
}
