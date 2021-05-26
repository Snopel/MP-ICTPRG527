using System;
using System.Text;

namespace NumberConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int dec = Convert.ToInt32(Console.ReadLine());

            //Console.Write("Select a conversion method." +
            //    "\n1: Binary | 2: Hex: ");
            //int input = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(dec + " to Binary is " + reverse(toBinary(dec)));

            Console.ReadLine();
        }

        static string toBinary(int num)
        {
            StringBuilder binBuild = new StringBuilder();

            while (num > 0)
            {
                binBuild.Append(num % 2);
                num /= 2;
            }
            String bin = binBuild.ToString();
            return bin;
        }

        static string reverse(string str)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = str.Length - 1; i >= 0; i--)
            {
                sb.Append(str[i]);
            }

            return sb.ToString();
        }
    }
}
