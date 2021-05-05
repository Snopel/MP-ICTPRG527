using System;
/* 
 * Program by Nicholas Balliro
 * Written 5/5/2021
 * Purpose of Program: To calculate pay and tax and output said values
 */
namespace CalculatePay
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

            Console.WriteLine("Welcome to the Payroll Calculator!\n");
            Console.Write("Please enter your rate of pay: ");
            rate = Convert.ToDouble(Console.ReadLine());

            Console.Write("Please enter your hours worked: ");
            hours = Convert.ToInt32(Console.ReadLine());

            //Calculating gross pay
            gross = hours * rate;

            //Calculating tax witheld by callings the CalcTaxRate method
            taxWH = gross * CalcTaxRate(gross);
            //Calculating the final net pay
            net = gross - taxWH;

            //Output the values rounded to 2 decimal points for exact dollar amounts
            Console.WriteLine("\nYour GROSS earnings: $" + Math.Round(gross, 2));
            Console.WriteLine("Your NET earnings: $" + Math.Round(net, 2));
            Console.WriteLine("You have been taxed: $" + Math.Round(taxWH, 2));
            Console.WriteLine("\nThank you for using the Payroll Calculator.\nGoodbye!");
            //Allow input to close the program
            Console.ReadLine();
        }

        //Creating a separate method for calculating the tax rate for cleaner code implementation
        static double CalcTaxRate(double earnings)
        {
            //Calculating the variable tax rate according to the gross earnings and returns the final value
            if (earnings <= 300)
            {
                return 0.1;
            }
            else if (earnings > 300 && earnings <= 400)
            {
                return 0.12;
            }
            else if (earnings > 400 && earnings <= 500)
            {
                 return 0.15;
            }
            else if (earnings > 500)
            {
                return 0.2;
            }
            //In case for whatever reason none of these conditions are met
            return 0;
        }
    }
}
