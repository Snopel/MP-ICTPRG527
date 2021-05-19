using System;

namespace TableOfSquares
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 1;

            while (num <= 20)
            {
                Console.WriteLine("Number: " + num);
                Console.WriteLine("Square: " + (num * num));
                Console.WriteLine();
                num++;
            }

            Console.ReadLine();
        }
    }
}
