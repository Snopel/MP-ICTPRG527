using System;

namespace AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = 0;
            double withdrawal = 0;

            Console.WriteLine("*** Welcome to NAB Bank! ***\n");
            Console.Write("Please enter account balance: $");
            balance = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);
            Console.WriteLine("\nBALANCE: $" + Math.Round(balance, 2));
            Console.Write("Please enter your withdrawal amount: $");
            withdrawal = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);

            balance -= withdrawal;

            if(balance < 0)
            {
                Console.WriteLine("\nINSUFFICIENT FUNDS!");
            } else
            {
                Console.WriteLine("\nProcessing...");
                Console.WriteLine("Success! $" + withdrawal + " was withdrawn.\n" +
                    "Your remaining balance is $" + balance + ".");
            }

            Console.WriteLine("Thank you for using NAB Bank!");

            Console.ReadLine();
        }
    }
}
