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
            Console.WriteLine("계속하려면 아무 키나 누르세요: ");
        }

        public override void Input()
        {
            Console.ReadKey(true);
        }
        public override void Update()
        {

        }

        public override void Result()
        {
            Game.ChangeScene("ShipScene");
        }
    }
}
