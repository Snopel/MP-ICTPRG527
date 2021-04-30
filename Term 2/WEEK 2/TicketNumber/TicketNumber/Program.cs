using System;

namespace TicketNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isValid = false;

            Console.WriteLine("*** TICKET CARD VALIDATOR ***");
            Console.Write("\nPlease enter a 6-Digit Ticket Number: ");
            int ticket = Convert.ToInt32(Console.ReadLine());

            //Dropping the last digit:
            int ticketDiv = ticket / 10;
            //Grab the dropped digit
            int ticketDrop = ticket % 10;
            //Divide the digit-dropped ticket by 7
            int ticketRem = ticketDiv % 7;
            //Check if the condition is true (If the dropped number is the same as the remainder)
            if (ticketDrop == ticketRem)
            {
                isValid = true;
            }

            Console.WriteLine("\nValidation completed.\nResult: " + isValid);

            Console.ReadLine();
        }
    }
}
