using System;

namespace TwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter a number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter another number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            if (num1 == num2)
            {
                Console.WriteLine("Both numbers are the same.");
            }
            else if (num1 > num2)
            {
                Console.WriteLine("The bigger number is the first number, " + num1);
            }
            else if (num1 < num2)
            {
                Console.WriteLine("The bigger number is the second number" + num2);
            }

            Console.ReadLine();
        }
    }
}
