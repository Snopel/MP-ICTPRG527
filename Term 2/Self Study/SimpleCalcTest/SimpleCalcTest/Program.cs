using System;

/* A simple calculator project to get started
 * Author: Nicholas Balliro
 * Date: 23/04/2021
*/ 
namespace MyFirstProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 0;
            int num2 = 0;
            int op = 0;
            bool repeat = false;

            do
            {
                try
                {
                    repeat = false;

                    Console.Write("Enter a number: ");
                    num1 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter a second number: ");
                    num2 = Convert.ToInt32(Console.ReadLine());

                    Operation(num1, num2);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Input. Rebooting...\n");
                    repeat = true;
                }
            } while (repeat);

            Console.ReadLine();
        }

        static void Operation(int A, int B)
        {
            Console.WriteLine("Select an operator.\n 1: + | 2: - | 3: * | 4: / ");
            Console.Write("Choice: ");
            int op = Convert.ToInt32(Console.ReadLine());
            if (op == 1)
            {
                Console.WriteLine("Your numbers added together is " + (A + B));
            }
            else if (op == 2)
            {
                Console.WriteLine("Your numbers minused is " + (A - B));
            }
            else if (op == 3)
            {
                Console.WriteLine("Your numbers multiplied is " + (A * B));
            }
            else if (op == 4)
            {
                Console.WriteLine("Your numbers divided is " + (A / B));
            }
        }
    }
}