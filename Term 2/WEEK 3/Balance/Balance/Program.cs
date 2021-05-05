using System;

namespace Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Write an application called Balance that prompts the user for a debit account balance and a savings account balance. 
             * Display the message “Debit account balance is low” if this account balance is less than $50. 
             * Display the message “Savings account balance is low” if this account balance is less than $150. 
             */

            double debit = 0;
            double savings = 0;

            Console.WriteLine("*** Welcome to NAB Bank! ***\n");
            Console.Write("Please enter your Debit account balance: $");
            debit = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);
            Console.Write("Please enter your Savings account balance: $");
            savings = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);

            if (debit < 50 && savings >= 150)
            {
                Console.WriteLine("\nWARNING: Debit Account Balance Low!!");
            } 
            else if (savings < 150 && debit >= 50)
            {
                Console.WriteLine("\nWARNING: Savings Account Balance Low!!");
            }
            else if (debit < 50 && savings < 150)
            {
                Console.WriteLine("\nWARNING: Both Debit And Savings Accounts Dangerously Low!!");
            }

            Console.WriteLine("\nThank you for using NAB Bank!");
            Console.ReadLine();
        }
    }
}
