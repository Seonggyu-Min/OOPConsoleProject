using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject
{
    public static class ResourceManager
    {
        public static int Fuel { get; set; }
        public static int Oxygen { get; set; }

        public static int MaxFuel { get; set; }
        private static int MaxOxygen { get; set; }

        static ResourceManager()
        {
            Fuel = 6;
            Oxygen = 6;

            MaxFuel = 15;
            MaxOxygen = 15;
        }

        public static void ChargeFuel (int amount)
        {
            Fuel += amount;
            if (Fuel > MaxFuel)
                Fuel = 15;
        }


        public static void ChargeOxygen(int amount)
        {
            Oxygen += amount;
            if (Oxygen > MaxOxygen)
                Oxygen = 15;
        }

    }
}
