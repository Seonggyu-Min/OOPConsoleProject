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
            Fuel = 9;
            Oxygen = 9;

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
        public static void ConsumeFuel(int amount)
        {
            Fuel -= amount;
        }

        public static void ConsumeOxygen(int amount)
        {
            Oxygen -= amount;
        }

        public static void PrintOxygen()
        {
            Console.Write("산소: ");
            if (Oxygen < 6)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                for (int i = 0; i < MaxOxygen; i++)
                {
                    if (i < Oxygen)
                        Console.Write('■');
                    else
                        Console.Write('□');
                }
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;

                for (int i = 0; i < MaxOxygen; i++)
                {
                    if (i < Oxygen)
                        Console.Write('■');
                    else
                        Console.Write('□');
                }
                Console.ResetColor();
            }
        }


        public static void PrintFuel()
        {
            Console.Write("연료: ");
            if (Fuel < 6)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                for (int i = 0; i < MaxFuel; i++)
                {
                    if (i < Fuel)
                        Console.Write('■');
                    else
                        Console.Write('□');
                }
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;

                for (int i = 0; i < MaxFuel; i++)
                {
                    if (i < Fuel)
                        Console.Write('■');
                    else
                        Console.Write('□');
                }
                Console.ResetColor();
            }
        }

    }
}
