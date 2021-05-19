using System;
/*
 * Program by Nicholas Balliro
 * ID: S1509092
 * Date: 19/05/2021
 * Purpose: To create two separate methods for squaring and cubing respectively and
 *          call these methods in the Main method.
 */
namespace Exponent
{
    class Program
    {
        //MAIN METHOD
        static void Main(string[] args)
        {
            //Gather user input for a number
            Console.Write("Enter a number: ");

            //Create an integer and assign this value from the user's input
            int input = Convert.ToInt32(Console.ReadLine());

            //Call the methods and display the final value returned as an output.
            Console.WriteLine("\nThe number " + input + " squared is " + squareNum(input)); //Calling the 'squareNum' method
                                                                            
            Console.WriteLine("The number " + input + " cubed is " + cubeNum(input)); //Calling the 'cubeNum' method

            //End Program
            Console.ReadLine();
        }

        //SQUARE METHOD
        static int squareNum (int num) //Declaring the num variable to be passed in
        {
            //Square the passed in value
            int square = num * num;
            //Return the value as an output
            return square;
        }
        
        //CUBE METHOD
        static int cubeNum (int num)
        {
            //Same as 'squareNum', except cubed
            int cube = num * num * num;
            return cube;
        }
    }
}
