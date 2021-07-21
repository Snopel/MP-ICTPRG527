using System;
/*
 * Program by Nicholas Balliro
 * ID: S1509092
 * Date: 12/05/2021
 * Purpose: To flip an amount of coins and return the percentage of heads and tails
 */
namespace FlipCoin
{
    class Program
    {
        static void Main(string[] args)
        {
            //Gather user input for flip amount
            /* NOTE: I understand the task was to flip 1000 times, but I figured this would be
             * more efficient and can be used to test and debug various circumstances for future
             * uses of the Random class. 
             * Please just input 1000 for the assessment.
             */

            //BEGIN PROGRAM
            Console.WriteLine("Welcome to the Auto Coin Flipper!");
            Console.Write("How many times would you like to flip?: ");
            //Take user's flip amount
            int flips = Convert.ToInt32(Console.ReadLine()); 

            Console.WriteLine("\nNow flipping " + flips + " coins...\n");

            //Call the CoinFlip function and get the amount of heads produced for the amount of flips asked
            int headsCount = CoinFlip(flips);

            //Calculate the percentage of heads by calling CalcPercent
            int headsPercentage = Convert.ToInt32(CalcPercentage(headsCount, flips));
            //Calculating leftover percentage
            int tailsPercentage = 100 - headsPercentage;

            //Output results to the user
            Console.WriteLine("Flipping complete!\n\nResults:");
            Console.WriteLine("\tPercentage of Heads: " + headsPercentage
                               + "%\n\tPercentage of Tails: " + tailsPercentage + "%");

            //User input to close program
            Console.ReadLine();
            //END PROGRAM
        }

        //Separate method to process the coin flip and return the amount of heads
        static int CoinFlip(int flipCount)
        {
            double coin = 0; //The coin being flipped
            int heads = 0; //the amount of heads flipped
            //Calling the Random class to utilise the coin flip.
            Random flip = new Random();
            //For loop for the entered amount of coin flips
            for (int i = 0; i <= flipCount; i++)
            {
                coin = flip.NextDouble(); //Generate a random number and pass into the coin variable
                //If statement to check whether Heads or Tails was flipped
                if (coin <= 0.5)
                {
                    heads++; //increment the amount of heads
                }

            }
            return heads;
        }
        
        //Separate method to calculate the percentage of heads
        static double CalcPercentage(double amount, int count)
        {
            //Turn amount into a floating point so that division does NOT return 0 and then calculate
            double percent = (amount * 1.0f) / count * 100;
            //return the percentage value
            return percent;
        } 
    }
}
