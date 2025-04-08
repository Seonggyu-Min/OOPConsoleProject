using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject
{
    class ResourceManager
    {
        public static int Fuel { get; set; }
        public static int Oxygen { get; set; }

        public void ConsumeFuel (int amount)
        {
            Fuel -= amount;
            if (Fuel <= 0)
            {

            }
        }


        public void ConsumeOxygen(int amount)
        {
            Oxygen -= amount;
            if (Oxygen <= 0)
            {

            }
        }

    }
}
