using System;

namespace MyFirstProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 0;
            int num2 = 0;
            int op = 0;

            Console.WriteLine("Enter a number: ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a second number: ");
            num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Select an operator.\n 1: + | 2: - | 3: * | 4: / ");
            op = Convert.ToInt32(Console.ReadLine());
            if(op == 1)
            {
                Console.WriteLine("Your numbers added together is " + (num1 + num2));
            } else if (op == 2)
            {
                Console.WriteLine("Your numbers minused is " + (num1 - num2));
            } else if (op == 3)
            {
                Console.WriteLine("Your numbers multiplied is " + (num1 * num2));
            } else if (op == 4)
            {
                Console.WriteLine("Your numbers divided is " + (num1 - num2));
            } else
            {
                Console.WriteLine("INVALID");
            }
        }
    }
}
