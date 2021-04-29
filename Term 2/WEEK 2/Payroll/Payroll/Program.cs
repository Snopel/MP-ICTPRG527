using System;

namespace Payroll
{
    class Program
    {
        static void Main(string[] args)
        {
            double rate = 0; //Hourly rate
            double gross = 0; //Total pay
            double taxWH = 0; //Tax witheld
            double net = 0; //Final pay
            int hours = 0; //Hours worked
            const double TAX = 0.15; //Constant tax rate

            Console.WriteLine("Welcome to the Payroll System!\n");
            Console.Write("Please enter your rate of pay: ");
            rate = Convert.ToDouble(Console.ReadLine());

            Console.Write("Please enter your hours worked: ");
            hours = Convert.ToInt32(Console.ReadLine());

            //Calculating gross pay
            gross = hours * rate;
            //Calculating tax witheld
            taxWH = gross * TAX;
            //Calculating the final net pay
            net = gross - taxWH;

            Console.WriteLine("\nYour GROSS earnings: $" + Math.Round(gross, 2));
            Console.WriteLine("Your NET earnings: $" + Math.Round(net, 2));
            Console.WriteLine("You have been taxed: $" + Math.Round(taxWH, 2));
            Console.WriteLine("\nThank you for using the Payroll sytem.\nGoodbye!");
            Console.ReadLine();
        }
    }
}
