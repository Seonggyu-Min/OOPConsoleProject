using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject
{
    public static class TravelState
    {
        public static int CurrentNodeId { get; private set; }

        public static List<int>[] ConnectedNodes { get; private set; }

        public static Dictionary<int, GalaxyNodeInfo> GalaxyNodes { get; private set; }

        public static Dictionary<(int x, int y), int> GalaxyNodePositionMap { get; private set; } // 자료구조 통합 혹은 좌표추가를 통한 통합 가능성


        static TravelState()
        {
            CurrentNodeId = 0;

            ConnectedNodes = new List<int>[12];

            ConnectedNodes[0] = new List<int> { 1, 2 };
            ConnectedNodes[1] = new List<int> { 3, 4 };
            ConnectedNodes[2] = new List<int> { 5 };
            ConnectedNodes[3] = new List<int> { 6 };
            ConnectedNodes[4] = new List<int> { 7, 8 };
            ConnectedNodes[5] = new List<int> { 8 };
            ConnectedNodes[6] = new List<int> { 9 };
            ConnectedNodes[7] = new List<int> { 9 };
            ConnectedNodes[8] = new List<int> { 10 };
            ConnectedNodes[9] = new List<int> { 11 };
            ConnectedNodes[10] = new List<int> { 11 };

            GalaxyNodes = new Dictionary<int, GalaxyNodeInfo>
            {
                { 0, new GalaxyNodeInfo(0, "Start", "시작 지점", "무사히 살아남아 지구로 귀환하세요.", true) },
                { 1, new GalaxyNodeInfo(1, "Fuel", "연료 충전 지점", "이 은하는 연료가 풍부해보입니다. 근처에 들러 연료를 충전할 수 있을 것 같습니다.", false) },
                { 2, new GalaxyNodeInfo(2, "FuelEncounter", "외계 문명 조우 지점", "이 은하에는 발전된 문명이 살고 있습니다. 근처에 들러 대화를 나눠볼 수 있을 것 같습니다.", false) }, // 연료
                { 3, new GalaxyNodeInfo(3, "Oxygen", "산소 충전 지점", "이 은하에는 산소가 풍부해보입니다. 근처에 들러 산소를 충전할 수 있을 것 같습니다.", false) },
                { 4, new GalaxyNodeInfo(4, "OxygenEncounter", "외계 문명 조우 지점", "이 은하에는 발전된 문명이 살고 있습니다. 근처에 들러 대화를 나눠볼 수 있을 것 같습니다.", false) }, // 산소
                { 5, new GalaxyNodeInfo(5, "Oxygen", "산소 충전 지점", "이 은하에는 산소가 풍부해보입니다. 근처에 들러 산소를 충전할 수 있을 것 같습니다.", false) },
                { 6, new GalaxyNodeInfo(6, "Fuel", "연료 충전 지점", "이 은하는 연료가 풍부해보입니다. 근처에 들러 연료를 충전할 수 있을 것 같습니다.", false) },
                { 7, new GalaxyNodeInfo(7, "Fuel", "연료 충전 지점", "이 은하는 연료가 풍부해보입니다. 근처에 들러 연료를 충전할 수 있을 것 같습니다.", false) },
                { 8, new GalaxyNodeInfo(8, "FuelEncounter", "외계 문명 조우 지점", "이 은하에는 발전된 문명이 살고 있습니다. 근처에 들러 대화를 나눠볼 수 있을 것 같습니다.", false) }, // 연료
                { 9, new GalaxyNodeInfo(9, "OxygenEncounter", "외계 문명 조우 지점", "이 은하에는 발전된 문명이 살고 있습니다. 근처에 들러 대화를 나눠볼 수 있을 것 같습니다.", false) }, // 산소
                { 10, new GalaxyNodeInfo(10, "FuelEncounter", "외계 문명 조우 지점", "이 은하에는 발전된 문명이 살고 있습니다. 근처에 들러 대화를 나눠볼 수 있을 것 같습니다.", false) }, // 연료
                { 11, new GalaxyNodeInfo(11, "End", "도착 지점", "지구가 눈 앞에 보이기 시작합니다.", true) },
            };

            GalaxyNodePositionMap = new Dictionary<(int, int), int>
            {
                { (5, 1), 0 },
                { (3, 3), 1 },
                { (7, 3), 2 },
                { (3, 5), 3 },
                { (5, 5), 4 },
                { (7, 5), 5 },
                { (3, 7), 6 },
                { (5, 7), 7 },
                { (7, 7), 8 },
                { (4, 9), 9 },
                { (7, 9), 10 },
                { (6, 11), 11 }
            };
        }

        public static bool IsConnected(int id)
        {
            return ConnectedNodes[CurrentNodeId].Contains(id);
        }

        public static void Warp(int id)
        {
            if (IsConnected(id))
                CurrentNodeId = id;
        }

        public static GalaxyNodeInfo GetCurrentNodeInfo()
        {
            return GalaxyNodes[CurrentNodeId];
        }

        public static GalaxyNodeInfo GetNodeInfo(int id)
        {
            return GalaxyNodes.TryGetValue(id, out GalaxyNodeInfo node) ? node : null;
        }
    }
}
