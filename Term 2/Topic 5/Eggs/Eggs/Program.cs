using System;

namespace Eggs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How many eggs? ");
            int numberOfEggs = Convert.ToInt32(Console.ReadLine());

            showEggCount(numberOfEggs);

            Console.ReadLine();
        }

        static void showEggCount(int egg)
        {
            if ((egg % 12) == 0)
            {
                Console.WriteLine("\nYou have " + (egg / 12) + " dozen eggs.");
            }else if (egg < 12)
            {
                Console.WriteLine("\nYou have " + egg + " eggs.");
            }
            else if (egg > 12)
            {
                Console.WriteLine("\nYou have " + (egg / 12) + " dozen and " + (egg % 12) + " eggs.");
            }
            
        }
    }
}
