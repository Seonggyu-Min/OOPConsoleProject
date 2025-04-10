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
            switch (nodeInfo.Id)
            {
                case 2:
                    Util.DelayedText(" 1 + 1 = ? ");
                    Util.PrintText("1은 1번을, 2는 2번을 누르세요", 200, ConsoleColor.Green);
                    break;
                case 4:
                    Util.DelayedText(" 내가 가위를 냈을 때 네가 이기기 위해 내야되는 것은? ");
                    Util.PrintText("주먹은 1번을, 보는 2번을 누르세요", 200, ConsoleColor.Green);
                    break;
                case 8:
                    Util.DelayedText(" 지금은 몇 년도일까? ");
                    Util.PrintText("2025년은 1번을, 12874년은 2번을 누르세요", 200, ConsoleColor.Green);
                    break;
                case 9:
                    Util.DelayedText(" 닭이 먼저일까, 달걀이 먼저일까? ");
                    Util.PrintText("닭은 1번을, 달걀은 2번을 누르세요", 200, ConsoleColor.Green);
                    break;
                case 10:
                    Util.DelayedText(" 우리 은하에서 가장 잘나가는 지구 특산품은? ");
                    Util.PrintText("초코파이는 1번을, 불닭볶음면은 2번을 누르세요", 200, ConsoleColor.Green);
                    break;
            }
        }

        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }


        public override void Update()
        {
            if (isAnswered)
                return;

            if (nodeInfo.Id == 2)
            {
                if ((input == ConsoleKey.D1) || (input == ConsoleKey.NumPad1))
                {
                    Incorrect(input);
                }
                else if ((input == ConsoleKey.D2) || (input == ConsoleKey.NumPad2))
                {
                    Correct(input);
                }
                else
                {
                    Else(input);
                }
            }

            else if (nodeInfo.Id == 4)
            {
                if ((input == ConsoleKey.D1) || (input == ConsoleKey.NumPad1))
                {
                    Correct(input);
                }
                else if ((input == ConsoleKey.D2) || (input == ConsoleKey.NumPad2))
                {
                    Incorrect(input);
                }
                else
                {
                    Else(input);
                }
            }

            else if (nodeInfo.Id == 8)
            {
                if ((input == ConsoleKey.D1) || (input == ConsoleKey.NumPad1))
                {
                    Incorrect(input);
                }
                else if ((input == ConsoleKey.D2) || (input == ConsoleKey.NumPad2))
                {
                    Correct(input);
                }
                else
                {
                    Else(input);
                }
            }

            else if (nodeInfo.Id == 9)
            {
                if ((input == ConsoleKey.D1) || (input == ConsoleKey.NumPad1))
                {
                    Incorrect(input);
                }
                else if ((input == ConsoleKey.D2) || (input == ConsoleKey.NumPad2))
                {
                    Correct(input);
                }
                else
                {
                    Else(input);
                }
            }

            else if (nodeInfo.Id == 10)
            {
                if ((input == ConsoleKey.D1) || (input == ConsoleKey.NumPad1))
                {
                    Incorrect(input);
                }
                else if ((input == ConsoleKey.D2) || (input == ConsoleKey.NumPad2))
                {
                    Correct(input);
                }
                else
                {
                    Else(input);
                }
            }
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
            Game.SceneStackClear();
            Game.ChangeScene("Ship");
        }

        public void Correct(ConsoleKey input)
        {
            isCorrect = true;
            isAnswered = true;
            Console.WriteLine($"입력: {input}");
            Console.WriteLine();
            Util.DelayedText("어떻게 알았지...?");
            Console.WriteLine();
            Util.PrintText("네게 보상을 주겠다...", 200, ConsoleColor.Green);
            Util.ReadKey();
        }

        public void Incorrect(ConsoleKey input)
        {
            isCorrect = false;
            isAnswered = true;
            Console.WriteLine($"입력: {input}");
            Console.WriteLine();
            Util.DelayedText("틀렸다!!!");
            Console.WriteLine();
            Util.PrintText("보상을 줄 수 없을 것 같네...", 200, ConsoleColor.Red);
            Util.ReadKey();
        }

        public void Else(ConsoleKey input)
        {
            Console.WriteLine($"입력: {input}");
            Console.WriteLine("잘못된 입력입니다.");
            Util.ReadKey();
        }
    }
}

