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
            
        }
        public override void Result()
        {
            switch (input)
            {
                case ConsoleKey.Y:
                    if (TravelState.IsConnected(nodeInfo.Id))
                    {
                        Console.Clear();
                        Console.WriteLine("이동합니다.");
                        Util.ReadKey();
                        Game.ChangeScene(new GalaxyResultScene(nodeInfo));
                    }
                    else if (!TravelState.IsConnected(nodeInfo.Id) && nodeInfo.Id != TravelState.CurrentNodeId)
                    {
                        Console.Clear();
                        Console.WriteLine("해당 은하계는 너무 멀리 있어 이동할 수 없습니다.");
                        Console.WriteLine("성간 지도로 돌아갑니다.");
                        Util.ReadKey();
                        Util.EscapeSceneWOKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("현재 위치와 동일한 은하계로는 이동할 수 없습니다.");
                        Console.WriteLine("성간 지도로 돌아갑니다.");
                        Util.ReadKey();
                        Util.EscapeSceneWOKey();
                    }
                        break;
                case ConsoleKey.N:
                    Util.EscapeSceneWOKey();
                    break;
            }
        }
    }
}
