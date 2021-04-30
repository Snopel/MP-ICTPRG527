using System;
using System.Linq;
namespace AverageWeight
{
    class Program
    {
        static void Main(string[] args)
        {
            //Weight array to store the entered values
            double[] weight = new double[5];
            
            //For loop to enter and store values in the array
            for(int i = 0; i < 5; i++)
            {
                Console.Write("Enter weight " + (i + 1) + " in kg: ");
                weight[i] = Convert.ToDouble(Console.ReadLine());
            }

            //Calling the CalcAve function to return the average of the entered numbers
            double average = CalcAve(weight);
            //Output the average
            Console.WriteLine("The average weight of the selection is "+ Math.Round(average, 2) + " kg.");
            //Output the average converted to pounds by calling the KgToPound function
            double pounds = KgToPound(average);
            Console.WriteLine("The average weight in pounds is " + Math.Round(pounds, 2) + " p");

            Console.ReadLine();
        }

        //Function to convert kg to pounds and return the pounds value
        static double KgToPound(double kg)
        {
            double pound;
            //Constant conversion rate
            const double conv = 2.2;
            //Converting Kg to Pound
            pound = kg * conv;
            //Return final value
            return pound;
        }

        //Function to calculate the average of all entered values
        static double CalcAve(double[] num)
        {
            double sum = 0;
            double average = 0;
            //For loop to add the array numbers together and store into a sum variable
            for(int count = 0; count < num.Length; count++)
            {
                sum += num[count];
            }
            //Calculate the average based on Sum and the length of the array
            average = sum / num.Length;
            //Return final value
            return average;
        }
    }
}
