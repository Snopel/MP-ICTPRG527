using System;

namespace RelayRace
{
    class Program
    {
        static void Main(string[] args)
        {
            int time = 0;
            int totalMin = 0;
            int totalSec = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter Runner " + (i + 1) + " time: ");
                time += Convert.ToInt32(Console.ReadLine());
            }

            totalMin = time / 60;
            totalSec = time % 60;

            Console.WriteLine("\nTeam Total Time: " + totalMin + "m and " + totalSec + "s.");
            Console.ReadLine();
        }
    }
}
