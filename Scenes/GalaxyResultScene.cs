using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Scenes
{
    public class GalaxyResultScene : BaseScene
    {
        GalaxyNodeInfo nodeInfo;
        public GalaxyResultScene(GalaxyNodeInfo nodeInfo)
        {
            name = "GalaxyResult";
            this.nodeInfo = nodeInfo;
        }

        public override void Render()
        {
            // TODO 출력 안됨
            Console.WriteLine($"{nodeInfo.Name} 은하계로 이동합니다.");
            Console.WriteLine("연료가 3만큼 소모되었습니다.");
            Console.WriteLine("산소가 3만큼 소모되었습니다.");
            Console.WriteLine();
            Console.WriteLine($"현재 남은 연료: {ResourceManager.Fuel - 3} / 현재 남은 산소: {ResourceManager.Oxygen - 3}");
            Util.ReadKey();
        }
        public override void Input()
        {

        }
        public override void Update()
        {
            ResourceManager.ConsumeFuel(3);
            ResourceManager.ConsumeOxygen(3);
            TravelState.Warp(nodeInfo.Id);
        }
        public override void Result()
        {
            if (nodeInfo.LocationType == "OxygenEncounter" || nodeInfo.LocationType == "FuelEncounter")
            {
                Game.ChangeScene(new EncounterScene(nodeInfo));
                Game.SceneStackClear();
                return;
            }

            if (nodeInfo.LocationType == "End")
            {
                Game.ChangeScene("Ending");
                return;
            }

            Game.ChangeScene("Ship");
            Game.SceneStackClear();
        }
    }
}
