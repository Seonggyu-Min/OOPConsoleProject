using OOPConsoleProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Scenes
{
    public class EncounterScene : BaseScene
    {
        private ConsoleKey input;
        private GalaxyNodeInfo nodeInfo;
        private bool isAnswered = false;
        private bool isCorrect = false;
        public EncounterScene(GalaxyNodeInfo nodeInfo)
        {
            name = "Encounter";

            this.nodeInfo = nodeInfo;
        }

        public override void Render()
        {
            Console.Clear();
            Util.PrintText($"[외계 문명 조우] 은하 {nodeInfo.Id}에서 외계인을 만났습니다!", 200);
            Util.PrintText("외계인이 당신에게 보상을 주려고 합니다...", 200);
            Util.PrintText("그러나 퀴즈를 맞춰야 보상을 준다고 합니다...", 200);
            Util.PrintText("외계인은 문제를 말하기 시작합니다...", 200, ConsoleColor.Green);
            Util.DelayedText(" 1 + 1 = ? ");
            Util.PrintText("1은 1번을, 2는 2번을 누르세요", 200, ConsoleColor.Green);
        }

        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }


        public override void Update()
        {
            if (isAnswered)
                return;

            switch (input)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    isCorrect = true;
                    Console.WriteLine("입력: 1");
                    Console.WriteLine();
                    Util.DelayedText("어떻게 알았지...?");
                    Util.PrintText("네게 보상을 주겠다...", 200, ConsoleColor.Green);
                    Util.ReadKey();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    isCorrect = false;
                    Console.WriteLine("입력: 2");
                    Console.WriteLine();
                    Util.DelayedText("틀렸다!!!");
                    Util.PrintText("보상을 줄 수 없을 것 같네...", 200, ConsoleColor.Red);
                    Util.ReadKey();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    return;
            }
            isAnswered = true;
        }

        public override void Result()
        {

            if (!isAnswered)
                return;

            if (isCorrect)
            {
                if (nodeInfo.LocationType == "FuelEncounter")
                {
                    ResourceManager.ChargeFuel(5);
                    Util.PrintText("[보상] 연료 5을 받았습니다!", 300, ConsoleColor.Cyan);
                    Util.ReadKey();
                }
                else if (nodeInfo.LocationType == "OxygenEncounter")
                {
                    ResourceManager.ChargeOxygen(5);
                    Util.PrintText("[보상] 산소 5을 받았습니다!", 300, ConsoleColor.Cyan);
                    Util.ReadKey();
                }
            }

            nodeInfo.IsFarmed = true;
            Game.ChangeScene("Ship");
        }
    }
}

