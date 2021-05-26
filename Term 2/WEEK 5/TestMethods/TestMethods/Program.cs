using System;

namespace TestMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int input = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nInput: " + displayIt(input));
            Console.WriteLine(input + " x 2 = " + displayItTimesTwo(input));
            Console.WriteLine(input + " + 100 = " + displayItPlusOneHundred(input));

            Console.ReadLine();
        }

        static int displayIt(int num)
        {
            return num;
        }

        static int displayItTimesTwo(int num)
        {
            return num * 2;
        }

        static int displayItPlusOneHundred(int num)
        {
            return num + 100;
        }
    }
}
