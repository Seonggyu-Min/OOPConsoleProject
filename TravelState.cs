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
        }

        public static bool IsConnected(int id)
        {
            return ConnectedNodes[CurrentNodeId].Contains(id);
        }

        public static void Warp(int id)
        {
            if (ConnectedNodes[CurrentNodeId].Contains(id))
                CurrentNodeId = id;
        }
    }
}
