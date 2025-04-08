
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject
{

    public class GalaxyMap
    {
        public char[,] MapData { get; private set; }
        public bool[,] Map { get; private set; }

        public Dictionary<(int x, int y), GalaxyNodeInfo> GalaxyRoom { get; private set; }

        public GalaxyMap()
        {
            MapData = new char[,]
            {
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                { '#', ' ', ' ', ' ', ' ', 'S', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', '/', ' ', '\\', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', '@', ' ', ' ', ' ', '@', ' ', ' ', '#' },
                { '#', ' ', ' ', '/', ' ', '\\', ' ', '|', ' ', ' ', '#' },
                { '#', ' ', ' ', '@', ' ', '@', ' ', '@', ' ', ' ', '#' },
                { '#', ' ', ' ', '|', ' ', '|', '\\', '|', ' ', ' ', '#' },
                { '#', ' ', ' ', '@', ' ', '@', ' ', '@', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', '\\', '/', ' ', '|', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', '@', ' ', ' ', '@', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', '\\', '/', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', 'E', ' ', ' ', ' ', '#' },
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
            };


            Map = new bool[13, 11];

            for (int y = 0; y < MapData.GetLength(0); y++)
            {
                for (int x = 0; x < MapData.GetLength(1); x++)
                {
                    Map[y, x] = MapData[y, x] == '#' ? false : true;
                }
            }

            GalaxyRoom = new Dictionary<(int x, int y), GalaxyNodeInfo>
            {
                { (5, 1), new GalaxyNodeInfo(0, "Start", "시작 지점", "무사히 살아남아 지구로 귀환하세요.") }, // 0번 Start

                { (3, 3), new GalaxyNodeInfo(1, "Fuel", "연료 충전 지점", "이 은하는 연료가 풍부해보입니다. 근처에 들러 연료를 충전할 수 있을 것 같습니다.") },
                { (7, 3), new GalaxyNodeInfo(2, "Encounter", "외계 문명 조우 지점", "이 은하에는 발전된 문명이 살고 있습니다. 근처에 들러 대화를 나눠볼 수 있을 것 같습니다.") },
                { (3, 5), new GalaxyNodeInfo(3, "Oxygen", "산소 충전 지점", "이 은하에는 산소가 풍부해보입니다. 근처에 들러 산소를 충전할 수 있을 것 같습니다.") },
                { (5, 5), new GalaxyNodeInfo(4, "Encounter", "외계 문명 조우 지점", "이 은하에는 발전된 문명이 살고 있습니다. 근처에 들러 대화를 나눠볼 수 있을 것 같습니다.") },
                { (7, 5), new GalaxyNodeInfo(5, "Oxygen", "산소 충전 지점", "이 은하에는 산소가 풍부해보입니다. 근처에 들러 산소를 충전할 수 있을 것 같습니다.") },
                { (3, 7), new GalaxyNodeInfo(6, "Fuel", "연료 충전 지점", "이 은하는 연료가 풍부해보입니다. 근처에 들러 연료를 충전할 수 있을 것 같습니다.") },
                { (5, 7), new GalaxyNodeInfo(7, "Fuel", "연료 충전 지점", "이 은하는 연료가 풍부해보입니다. 근처에 들러 연료를 충전할 수 있을 것 같습니다.") },
                { (7, 7), new GalaxyNodeInfo(8, "Encounter", "외계 문명 조우 지점", "이 은하에는 발전된 문명이 살고 있습니다. 근처에 들러 대화를 나눠볼 수 있을 것 같습니다.") },
                { (4, 9), new GalaxyNodeInfo(9, "Encounter", "외계 문명 조우 지점", "이 은하에는 발전된 문명이 살고 있습니다. 근처에 들러 대화를 나눠볼 수 있을 것 같습니다.") },
                { (7, 9), new GalaxyNodeInfo(10, "Encounter", "외계 문명 조우 지점", "이 은하에는 발전된 문명이 살고 있습니다. 근처에 들러 대화를 나눠볼 수 있을 것 같습니다.") },

                { (6, 11), new GalaxyNodeInfo(11, "End", "도착 지점", "지구가 눈 앞에 보이기 시작합니다.") },
            };
        }

        public void PrintGalaxyMap()
        {
            for (int y = 0; y < MapData.GetLength(0); y++)
            {
                for (int x = 0; x < MapData.GetLength(1); x++)
                {
                    Console.Write(MapData[y, x]);
                }
                Console.WriteLine();
            }
        }
    }
}
