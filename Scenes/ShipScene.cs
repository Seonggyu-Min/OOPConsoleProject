﻿using OOPConsoleProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Scenes
{
    public class ShipScene : BaseScene
    {
        private ConsoleKey input;
        Addon addon; // 미사용
        GalaxyNodeInfo nodeInfo; // 미사용

        public ShipScene()
        {
            name = "Ship";

            Game.player.position = new Vector2(3, 3);
            Game.player.IsMovableMap = Game.ship.Map;
        }

        public override void Render()
        {
            Console.Clear();
            Game.ship.PrintMap();
            Game.player.Print();

            Console.SetCursorPosition(0, 9);
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
            Game.player.Move(input);
        }

        public override void Result()
        {
            var playerPos = (Game.player.position.x, Game.player.position.y);
            if (Game.ship.Room.TryGetValue(playerPos, out ShipRoomLocation room))
            {
                EnterRoom(room);
            }
            if (Game.ship.AddonLocation.TryGetValue(playerPos, out AddonType addonType))
            {
                EnterAddon(addonType);
            }
        }

        public void EnterRoom(ShipRoomLocation room)
        {
            switch (room)
            {
                case ShipRoomLocation.Cockpit:
                    Game.PushScene(new CockpitScene());
                    break;
                //case ShipRoomLocation.AddonBay:
                //    Game.ChangeScene("AddonBay");
                //    break;
            }
        }

        public void EnterAddon(AddonType addonType)
        {
            Addon selectedAddon = Game.ship.InstalledAddons[addonType];
            GalaxyNodeInfo currentNode = TravelState.GetCurrentNodeInfo();

            if (currentNode.IsFarmed)
            {
                Console.SetCursorPosition(0, 12);
                Util.PrintText("이미 행동을 마친 은하입니다.", ConsoleColor.Red);
                Console.WriteLine("조타실에서 다음 은하를 선택하세요.", ConsoleColor.Red);
                Util.ReadKey();
                return;
            }
            if ((selectedAddon.Type == AddonType.Fuel && currentNode.LocationType == "Fuel") ||
                (selectedAddon.Type == AddonType.Oxygen && currentNode.LocationType == "Oxygen"))
                //  || (selectedAddon.Type == AddonType.Interaction && currentNode.LocationType == "Encounter")
            {
                switch (selectedAddon.Type)
                {
                    case AddonType.Fuel:
                        Game.PushScene(new FuelCollectionScene(selectedAddon, currentNode));
                        break;
                    case AddonType.Oxygen:
                        Game.PushScene(new OxygenCollectionScene(selectedAddon, currentNode));
                        break;
                    //case AddonType.Interaction:
                    //    Game.PushScene(new EncounterScene(selectedAddon, currentNode));
                    //    break;
                }
            }
            else
            {
                Console.SetCursorPosition(0, 12);
                Console.WriteLine("현재 은하에서는 이 드론을 사용할 수 없습니다.");

                // 디버그용
                Console.SetCursorPosition(0, 13);
                Console.WriteLine($"사용하고자 하는 드론의 타입: {selectedAddon.Type}");
                Console.WriteLine($"현재 은하계의 타입: {currentNode.LocationType}");

                Console.ReadKey(true);
            }
        }
    }
}
