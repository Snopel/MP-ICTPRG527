using System;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            //Wood prices
            int pine = 100;
            int oak = 225;
            int mahogany = 310;
            //Final table value
            int table = 0;
            //Check if the input is valid for second switch statement
            bool valid = true;

            Console.WriteLine("Welcome to Snopel Furniture!");
            Console.Write("Please enter your table of choice!\n1: Pine | 2: Oak | 3: Mahogany\n\nChoice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            //Switch statement for each choice value
            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nYou've selected Pine wood!\nCost: $" + pine);
                    table = pine;
                    break;
                case 2:
                    Console.WriteLine("\nYou've selected Oak wood!\nCost: $" + oak);
                    table = oak;
                    break;
                case 3:
                    Console.WriteLine("\nYou've selected Mahogany wood!\nCost: $" + mahogany);
                    table = mahogany;
                    break;
                default:
                    Console.WriteLine("\nYou've made an incorrect selection.");
                    valid = false;
                    break;
            }
            //If the default case was not triggered
            if (valid == true)
            {
                Console.Write("\nPlease choose a table size!\n1: Small | 2: Large\n\nChoice: ");
                int size = Convert.ToInt32(Console.ReadLine());

                switch (size)
                {
                    case 1:
                        Console.WriteLine("\nYou've selected Small! No extra charge.\nCost: $" + table);
                        break;
                    case 2:
                        Console.WriteLine("\nYou've selected Large! $35 extra charge.\nCost: $" + (table + 35));
                        break;
                    default:
                        Console.WriteLine("\nYou've made an incorrect selection.");
                        break;
                }
            }

            Console.WriteLine("\nThank you for shopping with us!");
            Console.ReadLine();
        }
    }
}
