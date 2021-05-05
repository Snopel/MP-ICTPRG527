using System;

namespace Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter another number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            int ans = num1 + num2;

            Console.WriteLine("\nIt's test time!");
            Console.Write(num1 + " + " + num2 + " = ");
            int input = Convert.ToInt32(Console.ReadLine());

            if(input == ans)
            {
                Console.WriteLine("\nCongratulations you passed!");
            }
            else
            {
                Console.WriteLine("\nYOU FAIL!");
            }

            Console.ReadLine();
        }
    }
}
