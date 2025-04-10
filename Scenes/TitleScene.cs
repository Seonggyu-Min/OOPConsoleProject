using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Scenes
{
    class TitleScene : BaseScene
    {
        public TitleScene() 
        {
            name = "Title";
        }

        public override void Render()
        {
            Console.WriteLine("===========================");
            Console.WriteLine("     Project Homebound     ");
            Console.WriteLine("===========================");
            Console.WriteLine();
            Util.ReadKey();
        }

        public override void Input()
        {
            Console.Clear();
            Console.WriteLine("게임 설명: ");
            Util.PrintText("당신은 소형 탐사선을 타고 지구로 복귀하던 도중 항법 장치의 오류로 인해 조난당하였습니다. ", 500);
            Util.PrintText("산소와 연료가 전부 소진되지 않게 은하계에 방문하여 자원을 얻고 지구로 복귀하세요!", 500);
            Util.PrintText("당신의 함선에는 C, O, F 로 이루어진 방이 있습니다.", 500);
            Console.WriteLine();
            Util.PrintText("C: 조타실 - 다음 은하계로 이동할 수 있습니다.", 500);
            Util.PrintText("O: 산소 포집 드론 파견 - 산소가 풍부한 은하계에서 산소를 수집할 수 있습니다.", 500);
            Util.PrintText("F: 연료 포집 드론 파견 - 연료가 풍부한 은하계에서 연료를 수집할 수 있습니다.", 500);
            Util.ReadKey();
        }
        public override void Update()
        {

        }

        public override void Result()
        {
            Game.ChangeScene("Ship");
        }
    }
}
