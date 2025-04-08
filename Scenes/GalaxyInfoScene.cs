using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Scenes
{
    public class GalaxyInfoScene : BaseScene
    {
        GalaxyNodeInfo nodeInfo;

        private ConsoleKey input;

        public GalaxyInfoScene(GalaxyNodeInfo nodeInfo) 
        {
            name = "GalaxyInfo";
            this.nodeInfo = nodeInfo;
        }

        public override void Render()
        {
            Console.Clear();
            Console.WriteLine($"은하 ID: {nodeInfo.Id}");
            Console.WriteLine($"이름: {nodeInfo.Name}");
            Console.WriteLine($"유형: {nodeInfo.LocationType}");
            Console.WriteLine($"설명: {nodeInfo.Description}");
            Console.WriteLine();
            Console.WriteLine("이동하시겠습니까? (Y/N)");
        }
        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }
        public override void Update()
        {
            switch (input)
            {
                case ConsoleKey.Y:
                    Console.WriteLine("이동합니다.");
                    break;
                case ConsoleKey.N:
                    Console.WriteLine("취소합니다.");
                    break;
            }

            switch (nodeInfo.LocationType)
            {
                case "Fuel":

            }

        }
        public override void Result()
        {

        }
    }
}
