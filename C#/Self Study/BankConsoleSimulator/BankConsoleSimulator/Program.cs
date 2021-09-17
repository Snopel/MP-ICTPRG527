using System;
using System.Text.RegularExpressions;

namespace BankConsoleSimulator
{
    //MAIN PROGRAM

    //Console Application to simulate Bank Account functionalities
    class Program
    {
        //Array to hold all accounts in the system
        static Account[] accounts = new Account[10];
        //Regex to ensure the name is not made up of anything but letters
        static Regex nameReg = new Regex("[A-Za-z]+");

        //MAIN FUNCTION
        static void Main(string[] args)
        {
            Console.WriteLine("##### Welcome to Snopel Banks! #####");
            //Execute the Menu function
            menu();

            //END PROGRAM
            Console.WriteLine("\n\nPress any key to exit.");
            //Press a key to close the window
            Console.ReadLine();
            //Safely close the application
            Environment.Exit(0);
        }

        //Front menu regarding access to accounts 
        static void menu()
        {
            int input;
            bool loop = false;
            Console.WriteLine("\n--- MAIN MENU ---");
            do
            {
                //Prompt user for either a login, or an account creation
                Console.WriteLine("\nPlease select from one of the following options: ");
                Console.WriteLine("1: Create Account\n2: Login\n3: Display All Accounts\n4: Load Preset Accounts\n5: Clear Accounts\n6: Exit");
                Console.Write("\nSelection: ");
                //Gather a choice and loop if input is not correct
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());

                    //Switch statement to direct to the correct screen
                    switch (input)
                    {
                        //Redirect to Create Account function
                        case 1:
                            loop = false;
                            createAccount();
                            break;
                        //Redirect to Login function
                        case 2:
                            loop = false;
                            login();
                            break;
                        //Redirect to Display Accounts function
                        case 3:
                            loop = false;
                            displayAccounts();
                            break;
                        case 4:
                            loop = false;
                            loadPresets();
                            break;
                        case 5:
                            loop = false;
                            clearAccounts();
                            menu();
                            break;
                        case 6:
                            loop = false;
                            Console.WriteLine("\nProgram Exited.\nThank you for using Snopel Banks!");
                            break;
                        //If anything else is pressed, throw an exception to repeat the loop
                        default:
                            throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\n!!! FATAL ERROR !!!\nRETURNING TO MENU...");
                    loop = true;
                }

            } while (loop == true);
        }

        //Function to create bank accounts
        static void createAccount()
        {
            String input; //Assigns input to a variable for error checking before inserting into the correct place
            //Defining relevant variables
            String surname = "";
            int pin = 0;
            double balance = 0;
            int type = 0;

            //Start of Function
            Console.WriteLine("\n--- CREATE ACCOUNT ---\n");
            Console.Write("Surname: ");
            input = Console.ReadLine();
            //Checking if the surname is feasible, else exit the function
            if (nameReg.IsMatch(input) == true)
            {
                surname = input;
            }
            else
            {
                Console.WriteLine("\n!!! INVALID INPUT !!!\nRETURNING TO MENU...");
                menu();
            }
            try
            {
                Console.Write("PIN: ");
                input = Console.ReadLine();
                //<ERROR CHECKING TO BE ADDED>
                pin = Convert.ToInt32(input);
                Console.Write("Starting Balance: $");
                balance = Convert.ToDouble(Console.ReadLine()); //No error checking needed
                //Type of account
                Console.Write("Type (1: Standard | 2: Savings): ");
                type = Convert.ToInt32(Console.ReadLine());
                //Creating an account with this data
                if (type == 1) //If Standard
                {
                    Console.WriteLine("Creating Standard account...");
                    Account account = new Account(surname, pin, balance);
                    assignAccount(account);
                    Console.WriteLine("Account created!\n");
                    //Display the account's information 
                    Console.WriteLine(account.getStatement());
                }
                else if (type == 2) //If Savings
                {
                    Console.WriteLine("Creating Savings account...");
                    Account account = new SavingsAccount(surname, pin, balance);
                    assignAccount(account);
                    Console.WriteLine("Account created!\n");
                    //Display the account's information 
                    Console.WriteLine(account.getStatement());
                }
                else
                {
                    Console.WriteLine("Invalid Input.");
                }
                //Proceed to main function screen
                menu();
            } catch (Exception)
            {
                Console.WriteLine("\n!!! INVALID INPUT !!!\nRETURNING TO MENU...");
                menu();
            }


        }

        //Function to allow user to login with a pre-existing account
        static void login()
        {
            Account searchAcc = new Account(); ; //Account that will be assigned to a found account in the array
            int searchCard; //Card number input by user
            bool found = false; //Variable to state whether the account is found or not

            //Prompt user for card number
            Console.WriteLine("\n--- LOGIN ---");
            Console.Write("\nCard Number: ");
            searchCard = Convert.ToInt32(Console.ReadLine());

            //Search the array for a matching card number and return an error if not found, else assign to a variable.
            for (int i = 0; i < accounts.Length; i++)
            {
                //If a card match is found, show a success message, display the account and verify it
                if (accounts[i] != null && searchCard == accounts[i].getCardNum())
                {
                    found = true;
                    searchAcc = accounts[i]; //Assign the found account to the account variable
                    break;
                }
            }
            if (found == true)
            {
                verifyAccount(searchAcc); //Execute verify function
            }
            else
            {
                Console.WriteLine("NO MATCHES FOUND.\nReturning to menu...");
                menu();
            }

        }

        //The main function which carries out all banking functions
        static void mainFunction(Account acc)
        {
            int input;
            Console.WriteLine("\n--- BANK MENU ---");
            Console.WriteLine("\nPlease select from one of the following options: ");
            Console.WriteLine("1: Deposit\n2: Withdraw\n3: Bank Statement\n4: Logout");
            Console.Write("\nSelection: ");
            input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    acc.deposit();
                    mainFunction(acc);
                    break;
                case 2:
                    acc.withdraw();
                    mainFunction(acc);
                    break;
                case 3:
                    Console.WriteLine(acc.getStatement());
                    mainFunction(acc);
                    break;
                case 4:
                    Console.WriteLine("Logout successful.");
                    menu();
                    break;
                default:
                    Console.WriteLine("INVALID INPUT");
                    mainFunction(acc);
                    break;
            }
        }

        //Display all accounts in the system
        static void displayAccounts()
        {
            for (int i = 0; i < accounts.Length; i++)
            {
                if(accounts[i] != null)
                {
                    Console.WriteLine(accounts[i].getDetails());
                }
            }
            //Return to menu
            menu();
        }

        //Load preset accounts for debugging or practical use
        static void loadPresets()
        {
            Account sample1 = new Account("Balliro", 4507, 8500);
            Account sample2 = new Account("Curran", 1995, 500690);
            Account sample3 = new Account("Smith", 0123, 22550);
            SavingsAccount sample4 = new SavingsAccount("Kiryu", 1988, 10508296);
            SavingsAccount sample5 = new SavingsAccount("Majima", 6666, 999999999);
            Console.WriteLine("Loading preset sample accounts...");
            if (accounts[0] != null)
            {
                Console.WriteLine("ERROR: Accounts already created.\nRedirecting...");
                menu();
            }
            else
            {
                accounts[0] = sample1;
                accounts[1] = sample2;
                accounts[2] = sample3;
                accounts[3] = sample4;
                accounts[4] = sample5;
                Console.WriteLine("Loading successful!");
                menu();
            }

        }

        //Delete all accounts currently in the system
        static void clearAccounts()
        {
            Console.Write("Are you sure? [Y/N]: ");
            String input = Console.ReadLine();
            switch (input.ToUpper())
            {
                case "Y":
                    for (int i = 0; i < accounts.Length; i++)
                    {
                        accounts[i] = null;
                    }
                    Console.WriteLine("Accounts cleared successfully.");
                    break;
                case "N":
                    Console.WriteLine("Aborted.");
                    break;
                default:
                    Console.WriteLine("ERROR: Invalid input.");
                    break;
            }
        }

        //Assign created account to the Accounts array
        static void assignAccount(Account acc)
        {
            //Add if there is an available space
            for (int i = 0; i < accounts.Length; i++)
            {
                if(accounts[i] == null)
                {
                    accounts[i] = acc;
                    break;
                }
            }
        }

        //Verify the entered PIN with the account's PIN
        static void verifyAccount(Account acc)
        {
            int error = 2; //Amount of tries before lockout
            int pin;
            bool loop = false; //Sentinel loop value
            bool match = false; //To check if the verification is sucessful
            do
            {
                Console.Write("PIN: "); //Prompt for PIN
                pin = Convert.ToInt32(Console.ReadLine());
                //If the PIN number is a match
                if (pin == acc.getPinNum())
                {
                    loop = false;
                    match = true;
                    Console.WriteLine("VERIFICATION SUCCESSFUL!\n");
                }
                //If the PIN doesn't match and the Error limit has been reached
                else if (error == 0)
                {
                    loop = false;
                    Console.WriteLine("ERROR: Too many invalid PINs.\nRedirecting to Main Menu...\n");

                }
                //If the wrong PIN is entered
                else
                {
                    loop = true;
                    Console.WriteLine("ERROR: Invalid PIN.");
                    error--;
                }
            } while (loop == true);
            //Redirect to the relevant function based on the match value
            if (match == true)
            {
                mainFunction(acc);
            }
            else
            {
                menu();
            }
        }
      
    }
}
