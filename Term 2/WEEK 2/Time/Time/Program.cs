using System;
/* Assessment Task 2 (Topic 2)
 * Program by: Nicholas Balliro
 * Written: 28/04/2021
 * Purpose: To calculate totalMinutes into hours and minutes and display
 */
namespace Time
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaring variables for hours, minutes and totalMinutes as integers
             int hours = 0;
             int minutes = 0;
             int totalMinutes = 0;

             //Gathering input from the user
             Console.Write("Please enter how many minutes were worked: ");
             //Parsing string input into an integer for calculation
             totalMinutes = Convert.ToInt32(Console.ReadLine());

             //Breaking totalMinutes into hours and minutes individually
             hours = totalMinutes / 60;
             minutes = totalMinutes - (60 * hours);

             //IF statement to decide whether to display hours AND minutes or just one
             if (hours <= 0) //If totalMinutes equates to less than one hour (eg. 45 minutes = 0 hours and 45 minutes)
             {
                 Console.WriteLine(minutes + " minutes were worked today.");
             } else if (minutes <= 0) //If totalMinutes equates to exact hours (eg. 120 minutes = 2 hours and 0 minutes)
             {
                 Console.WriteLine(hours + " hours were worked today.");
             } else //If both hours and minutes are above 0
             {
                Console.WriteLine(hours + " hours and " + minutes + " minutes were worked today.");
             }
            //Prompting a key before closing the window
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadLine();
            //End Program
        }
    }
}
