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
                switch (room)
                {
                    case ShipRoomLocation.Cockpit:
                        Game.ChangeScene("Cockpit");
                        break;
                    case ShipRoomLocation.AddonBay:
                        Game.ChangeScene("AddonBay");
                        break;
                }
            }
        }
    }
}
