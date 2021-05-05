using System;

namespace Scores
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Time to see how you did this year!");
            Console.Write("\nPlease enter your score for Test 1 (/10): ");
            int test1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter your score for Test 2 (/10): ");
            int test2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter your score for Test 3 (/10): ");
            int test3 = Convert.ToInt32(Console.ReadLine());

            int avg = (test1 + test2 + test3) / 3;

            if (avg >= 5)
            {
                Console.WriteLine("\nCongratulations! You passed!!\nFinal Score: " + avg);
            } else
            {
                Console.WriteLine("\nYOU FAIL!!\nFinal Score: " + avg);
            }


            Console.ReadLine();
        }
    }
}
