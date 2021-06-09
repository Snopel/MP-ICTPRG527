using System;

namespace Lawn
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = 0;
            int width = 0;
            int lawn = 0;
            int fee = 0;
            const int SEASON = 20;
            int seasonFee = 0;
            int choice = 0;

            Console.WriteLine("Welcome to Jim's Mowing service!");
            Console.WriteLine("We offer a seasonal 20 week mowing fee!");
            //Grabbing length and width of the lawn
            Console.Write("\nPlease enter the LENGTH of the lawn (m): ");
            length = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nPlease enter the WIDTH of the lawn (m): ");
            width = Convert.ToInt32(Console.ReadLine());
            //Calculating the lawn area
            lawn = length * width;
            
            //Checking the lawn's area and assigning the appropriate fee
            if (lawn < 400)
            {
                fee = 25;
            } 
            else if (lawn >= 400 && lawn <= 600)
            {
                fee = 35;
            }
            else if (lawn > 600)
            {
                fee = 50;
            }
            
            //Calculating the seasonal fee
            seasonFee = fee * SEASON;

            //Displaying the appropriate information to the user
            Console.WriteLine(
                "\nYour lawn is " + lawn + " square meters.\n" +
                "\nYour weekly mowing fee is $" + fee +
                "\nThe seasonal fee over 20 weeks is $" + seasonFee);
            //Prompt the user for payment either once, twice or weekly
            Console.WriteLine("\nHow would you like to pay?\n" +
                "(1: Whole Fee || 2: Two Payments || 3: Weekly)");
            choice = Convert.ToInt32(Console.ReadLine());

            //Decide what the payment will be based on the Choice variable
            switch (choice)
            {
                case 1:
                    Console.WriteLine("You have chosen to pay the whole fee at once.");
                    Console.WriteLine("The final fee today will be $" + seasonFee);
                    break;
                case 2:
                    Console.WriteLine("You have chosen to pay in two payments.");
                    Console.WriteLine("There will be 2 payments of $" + ((seasonFee / 2) + 5) + " including a $5 service charge per payment.");
                    break;
                case 3:
                    Console.WriteLine("You have chosen to pay weekly.");
                    Console.WriteLine("There will be a payment of $" + ((seasonFee / 20) + 3) + " including a $3 service charge per payment every week.");
                    break;
                default:
                    Console.WriteLine("You have made an invalid selection.");
                    break;
            }
            Console.WriteLine("\n\nThank you for choosing Jim's Mowing!");

            Console.ReadLine();
        }
    }
}
