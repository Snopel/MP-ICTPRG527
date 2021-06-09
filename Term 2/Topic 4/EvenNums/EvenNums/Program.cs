using System;

namespace EvenNums
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 1;
            int evenChk = 0;
            int twentyChk = 0;

            Console.WriteLine("This program will now print only EVEN numbers.\n");

            for (int i = 0; i <= 100; i++)
            {
                evenChk = num % 2;
                twentyChk = num % 20;
                if(evenChk == 0)
                { 
                    Console.WriteLine(num);
                    if(twentyChk == 0)
                    {
                        Console.WriteLine();
                    }
                }
                num++;
            }

            Console.ReadLine();
        }
    }
}
