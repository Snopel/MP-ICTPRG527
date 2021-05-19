using System;

namespace Input123
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = 0;

            while (input != 4)
            {
                Console.Write("Please input 1, 2 or 3 to continue." +
                    "\nAlternatively, press 4 to exit: ");
                input = Convert.ToInt32(Console.ReadLine());

                switch (input) {
                    case 1:
                        Console.WriteLine("Good job!\n");
                        continue;
                    case 2:
                        Console.WriteLine("Good job!\n");
                        continue;
                    case 3:
                        Console.WriteLine("Good job!\n");
                        continue;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Invalid Input.\n");
                        continue;
                }
            }

            Console.WriteLine("\nProgram exiting.");
            Console.ReadLine();
        }
    }
}
