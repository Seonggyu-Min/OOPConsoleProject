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

        public FuelCollectionScene(Addon addon)
        {
            name = "FuelCollection";

            this.addon = addon;

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
                if (addon.Grade == AddonGrade.Basic)
                {
                    int collect = 1;
                    ResourceManager.ChargeFuel(collect);
                }
                else if (addon.Grade == AddonGrade.AlienTech)
                {
                    int collect = 3;
                    ResourceManager.ChargeFuel(collect);
                }

                map.MapData[drone.DronePosition.y, drone.DronePosition.x] = ' ';
                map.FuelPosition.Remove(dronePos);
            }

            if (map.FuelPosition.Count == 0)
            {
                Console.SetCursorPosition(0, 15);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("모든 연료를 수집했습니다! E로 향하여 복귀하세요");
                Console.ResetColor();

                if (dronePos == (1, 3))
                {
                    Game.PopScene();
                }

            }


        }

    }
}
