using System;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int A = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter another: ");
            int B = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine(A + " + " + B + " = " + sum(A, B));
            Console.WriteLine(A + " - " + B + " = " + difference(A, B));
            Console.WriteLine(A + " x " + B + " = " + product(A, B));

            Console.ReadLine();
        }

        static int sum(int num1, int num2)
        {
            return num1 + num2;
        }

        static int difference(int num1, int num2)
        {
            return num1 - num2;
        }

        static int product(int num1, int num2)
        {
            return num1 * num2;
        }
    }
}
