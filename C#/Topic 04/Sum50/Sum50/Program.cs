using System;
//Commented to help a fellow student.
namespace Sum50
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare variables.
            int sum = 0; // Instantiate a sum variable to add total numbers

            //For loop which is designed to loop 50 times
            for (int i = 1; i <= 50; i++)
            {
                //Display the current total adding the current loop number 
                Console.WriteLine(sum + " + " + i + " = "  + (sum + i));
                Console.WriteLine(); //Just a space inbetwen for neatness
                sum += i; //Same way of writing 'sum = sum + i'
            }

            Console.ReadLine();
        }
    }
}
