using System;

namespace Initials
{
    class Program
    {
        static void Main(string[] args)
        {
            string ini1;
            string ini2;
            string ini3;

            Console.Write("Enter your first initial: ");
            ini1 = Console.ReadLine();
            Console.Write("Enter your second initial: ");
            ini2 = Console.ReadLine();
            Console.Write("Enter your third initial: ");
            ini3 = Console.ReadLine();

            Console.WriteLine("\nYour initials are " 
                + ini1 + "."
                + ini2 + "."
                + ini3);

            Console.ReadLine();
        }
    }
}
