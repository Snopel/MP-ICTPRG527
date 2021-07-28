using System;

/* Nicholas Balliro
 * S1509092
 * Topic 11 Q6
 * Create a phonebook application that uses arrays to 
 * display names and phone numbers.
 */
namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare Variables: Arrays of up to 10 items
            String[] name = new String[10]; //names
            int[] phone = new int[10]; //phones
            String input = ""; //string input var

            int i = 0; //Loop variable declared outside a loop for use later
  
            while (i <= 9)
            {
                Console.WriteLine("Please enter a Name and Phone Number (or 'ZZZ' to exit), up to 10.");
                Console.Write("NAME: ");
                input = Console.ReadLine();
                //Sentinel Value to exit the loop
                if (input.ToUpper() == "ZZZ")
                {
                    break;
                }
                //Poopulating the name array with the chosen name
                name[i] = input;

                //Populating the phone array with an input, destroying program if a letter is entered.
                try
                {
                    Console.Write("PHONE: ");
                    phone[i] = Convert.ToInt32(Console.ReadLine());
                } catch (Exception)
                {
                    Console.WriteLine("INCORRECT INPUT\nApplication Closing.");
                    Console.ReadLine();
                    System.Environment.Exit(0);
                }

                //Output some text to show it worked and ease into the next loop
                Console.WriteLine("Entry " + (i + 1) + " processed successfully.\n");

                //Increment i
                i++;
            }
            //Output how many names were entered
            Console.WriteLine("\nFINISHED.\n" + (i) + " entries made.");

            //Rollout all names 
            for(int j = 0; name[j] != null; j++)
            {
                Console.WriteLine((j + 1) + ": " + name[j]);
            }

            bool loop = true;
            while (loop == true)
            {
                //Prompt user to enter a name and display its number
                Console.Write("\nEnter an above name to display their number (or 'ZZZ' to exit):  ");
                input = Console.ReadLine();
                //EXIT CONDITION
                if(input.ToUpper() == "ZZZ")
                {
                    loop = false;
                    break;
                }
                //Search the array for the name and output if found
                int k = 0;
                bool found = false;
                while (k <= 9)
                {
                    if (name[k] == input)
                    {
                        found = true;
                        Console.WriteLine("Phone: " + phone[k]);
                        break;
                    }
                    k++;
                }
                //Show error if no matches
                if (found == false)
                {
                    Console.WriteLine("Name not found.");
                }
            }

            //Closing Application
            Console.Write("\nCLOSED.\nPress any key to exit.");
            Console.ReadLine();
        }
    }
}
