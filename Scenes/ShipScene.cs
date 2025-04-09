using OOPConsoleProject.Enums;
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
        Ship ship;
        Player player;
        Addon addon;
        GalaxyNodeInfo nodeInfo;

        public ShipScene()
        {
            name = "Ship";
            ship = new Ship();

            player = new Player(3, 3);
            player.position = new Vector2(3, 3);
            player.IsMovableMap = ship.Map;
        }

        public override void Render()
        {
            Console.Clear();
            ship.PrintMap();
            player.Print();

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
            player.Move(input);
        }

        public override void Result()
        {
            var playerPos = (player.position.x, player.position.y);
            if (ship.Room.TryGetValue(playerPos, out ShipRoomLocation room))
            {
                EnterRoom(room);
            }
            if (ship.AddonLocation.TryGetValue(playerPos, out AddonType addonType))
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
                case ShipRoomLocation.AddonBay:
                    Game.ChangeScene("AddonBay");
                    break;
            }
        }

        public void EnterAddon(AddonType addonType)
        {
            Addon selectedAddon = ship.InstalledAddons[addonType];
            GalaxyNodeInfo currentNode = TravelState.GetCurrentNodeInfo();

            if (currentNode.IsFarmed)
            {
                Console.SetCursorPosition(0, 12);
                Console.WriteLine("이미 다녀온 은하입니다.");
                Console.ReadKey(true);
                return;
            }
            if ((selectedAddon.Type == AddonType.Fuel && currentNode.LocationType == "Fuel") ||
                (selectedAddon.Type == AddonType.Oxygen && currentNode.LocationType == "Oxygen") ||
                (selectedAddon.Type == AddonType.Interaction && currentNode.LocationType == "Encounter"))
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
                Console.WriteLine(currentNode.LocationType);

                Console.ReadKey(true);
            }
        }
    }
}
