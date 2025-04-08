using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject
{
    public class GalaxyMap
    {
        List<int>[] galaxyMap;

        public GalaxyMap()
        {
            galaxyMap = new List<int>[12];

            galaxyMap[0] = new List<int> { 1, 2 };
            galaxyMap[1] = new List<int> { 3, 4 };
            galaxyMap[2] = new List<int> { 5 };
            galaxyMap[3] = new List<int> { 6 };
            galaxyMap[4] = new List<int> { 7, 8 };
            galaxyMap[5] = new List<int> { 8 };
            galaxyMap[6] = new List<int> { 9 };
            galaxyMap[7] = new List<int> { 9 };
            galaxyMap[8] = new List<int> { 10 };
            galaxyMap[9] = new List<int> { 11 };
            galaxyMap[10] = new List<int> { 11 };
        }

        
    }
}
