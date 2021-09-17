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
        //Admin login, opening up more options
        static bool admin = false;
        //If too many wrong Admin passwords are entered, security is breached and the program will close.
        static int kill = 3; 

        //MAIN FUNCTION
        static void Main(string[] args)
        {
            Console.WriteLine("##### Welcome to Snopel Banks! #####\n");
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
            if (kill <= 0)
            {
                Console.WriteLine("!!! FATAL: SECURITY BREACH !!!\nToo many invalid Admin attempts.\nSession aborted.");
                Console.ReadLine();
                Environment.Exit(0);
            }
            if (admin == false)
            {
                Console.WriteLine("--- MAIN MENU ---");
                do
                {
                    //Prompt user for either a login, or an account creation
                    Console.WriteLine("\nPlease select from one of the following options: ");
                    Console.WriteLine("1: Create Account\n2: Login\n3: Display All Accounts\n4: Exit");
                    Console.Write("\nSelection: ");
                    //Gather a choice and loop if input is not correct
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());

                        //Switch statement to direct to the correct screen
                        switch (input)
                        {
                            //Redirect to the relative account function
                            case 1:
                                loop = false;
                                createAccount();
                                break;
                            case 2:
                                loop = false;
                                login();
                                break;
                            case 3:
                                loop = false;
                                displayAccounts();
                                break;
                            case 4:
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
                        Console.WriteLine("\nERROR: Invalid Input\nReturning to menu...");
                        loop = true;
                    }

                } while (loop == true);
            }
            //If Admin state is enabled, display a different menu
            else if (admin == true)
            {
                Console.WriteLine("--- ADMIN MENU ---");
                do
                {
                    //Prompt user for either a login, or an account creation
                    Console.WriteLine("\nPlease select from one of the following options: ");
                    Console.WriteLine("1: Create Account\n2: Login\n3: Display All Accounts\n4: Close Account\n5: Close All Accounts\n6: Load Preset Accounts\n7: Fill Preset Accounts\n8: Exit");
                    Console.Write("\nSelection: ");
                    //Gather a choice and loop if input is not correct
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());

                        //Switch statement to direct to the correct screen
                        switch (input)
                        {
                            //Redirect to the relative account function
                            case 1:
                                loop = false;
                                createAccount();
                                break;
                            case 2:
                                loop = false;
                                login();
                                break;
                            case 3:
                                loop = false;
                                displayAccounts();
                                break;
                            case 4:
                                loop = false;
                                deleteAccount();
                                break;
                            case 5:
                                loop = false;
                                clearAccounts();
                                break;
                            case 6:
                                loop = false;
                                loadPresets();
                                break;
                            case 7:
                                loop = false;
                                fillPresets();
                                break;
                            case 8:
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
                        Console.WriteLine("\nERROR: Invalid Input\nReturning to menu...");
                        loop = true;
                    }

                } while (loop == true);
            }
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
            bool okay = false;

            //First check if there's room in the array
            for (int i = 0; i < accounts.Length; i++)
            {
                if(accounts[i] == null)
                {
                    okay = true;
                }
            }
            if (okay == true)
            {
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
                    Console.WriteLine("\nERROR: Invalid Input\nReturning to menu...");
                    menu();
                }
                try
                {
                    Console.Write("PIN: ");
                    pin = Convert.ToInt32(Console.ReadLine());
                    //Making sure PIN is a 4 digit number
                    if (pin > 9999 || pin < 1000)
                    {
                        Console.WriteLine("ERROR: PIN must be a 4 digit number.");
                        menu();
                    }
                    Console.Write("Starting Balance: $");
                    balance = Convert.ToDouble(Console.ReadLine()); //No error checking needed
                    Console.Write("Type (1: Standard | 2: Savings): "); //Type of account
                    type = Convert.ToInt32(Console.ReadLine());
                    //Creating an account with this data
                    if (type == 1) //If Standard
                    {
                        Console.WriteLine("Creating Standard account...");
                        Account account = new Account(surname, pin, balance);
                        assignAccount(account);
                        Console.WriteLine("Account created!\n");
                        //Display the account's information 
                        Console.WriteLine(account.getDetails() + "\n");
                    }
                    else if (type == 2) //If Savings
                    {
                        Console.WriteLine("Creating Savings account...");
                        Account account = new SavingsAccount(surname, pin, balance);
                        assignAccount(account);
                        Console.WriteLine("Account created!\n");
                        //Display the account's information 
                        Console.WriteLine(account.getDetails());
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input.");
                    }
                    //Proceed to main function screen
                    menu();
                }
                catch (Exception)
                {
                    Console.WriteLine("\nERROR: Invalid Input\nReturning to menu...");
                    menu();
                }
            } else if (okay == false)
            {
                Console.WriteLine("ERROR: Accounts full.\nPlease close accounts to create more.");
                menu();
            }
        }

        //Function to allow user to login with a pre-existing account, or enter Admin mode
        static void login()
        {
            Account searchAcc = new Account(); ; //Account that will be assigned to a found account in the array
            int searchCard; //Card number input by user
            bool found = false; //Variable to state whether the account is found or not

            //Prompt user for card number
            Console.WriteLine("\n--- LOGIN ---");
            Console.Write("\nCard Number: ");
            searchCard = Convert.ToInt32(Console.ReadLine());
            //Admin check
            if (searchCard == 99999999)
            {
                Console.WriteLine("\n--- ADMIN LOGIN ---");
                Console.Write("\nEnter the Admin pass to log into Admin menu.\nPASS: ");
                int adminPass = Convert.ToInt32(Console.ReadLine());
                if (adminPass == 1357531)
                {
                    Console.WriteLine("Authentication successful.\n");
                    admin = true;
                    menu();
                }
                else
                {
                    Console.WriteLine("ERROR: Invalid password.\nThis has been reported.\n");
                    kill--; //Decrement kill counter before security is breached
                    menu();
                }
            }
            else //Any other number
            {
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

        }

        //The main function which carries out all banking functions
        static void mainFunction(Account acc)
        {
            int input;
            Console.WriteLine("--- BANK MENU ---");
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
                    Console.WriteLine("Logout successful.\n");
                    menu();
                    break;
                default:
                    Console.WriteLine("INVALID INPUT\n");
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
                    Console.WriteLine("Account #" + (i + 1));
                    Console.WriteLine(accounts[i].getDetails());
                }
            }
            //Return to menu
            Console.WriteLine();
            menu();
        }

        //Load preset accounts for debugging or practical use
        static void loadPresets()
        {
            Account sample1 = new Account("Balliro", 1111, 8500);
            Account sample2 = new Account("Curran", 2222, 500690);
            Account sample3 = new Account("Smith", 3333, 22550.30);
            SavingsAccount sample4 = new SavingsAccount("Kiryu", 4444, 105200.56);
            SavingsAccount sample5 = new SavingsAccount("Majima", 5555, 999999);
            SavingsAccount sample6 = new SavingsAccount("Haruka", 6666, 30.50);
            Console.WriteLine("Loading preset sample accounts...");
            if (accounts[0] != null)
            {
                Console.WriteLine("ERROR: Accounts already created.\nRedirecting...\n");
                menu();
            }
            else
            {
                accounts[0] = sample1;
                accounts[1] = sample2;
                accounts[2] = sample3;
                accounts[3] = sample4;
                accounts[4] = sample5;
                Console.WriteLine("Loading successful!\nNOTE: PINs are their position in array recurring.\nEg. 1111, 2222, etc.\n");
                menu();
            }

        }

        //Fill the accounts aray with preset accounts
        static void fillPresets()
        {
            Account sample1 = new Account("Balliro", 1111, 8500);
            Account sample2 = new Account("Curran", 2222, 500690);
            Account sample3 = new Account("Smith", 3333, 22550.30);
            Account sample4 = new Account("Larosa", 4444, 100350.90);
            Account sample5 = new Account("Field", 5555, 15000);
            SavingsAccount sample6 = new SavingsAccount("Kiryu", 6666, 105200.56);
            SavingsAccount sample7 = new SavingsAccount("Majima", 7777, 999999);
            SavingsAccount sample8 = new SavingsAccount("Haruka", 8888, 30.50);
            SavingsAccount sample9 = new SavingsAccount("Dojima", 9999, 863040);
            SavingsAccount sample10 = new SavingsAccount("Tachibana", 1010, 660402);
            Console.WriteLine("Loading preset sample accounts...");
            if (accounts[0] != null)
            {
                Console.WriteLine("ERROR: Accounts already created.\nRedirecting...\n");
                menu();
            }
            else
            {
                accounts[0] = sample1;
                accounts[1] = sample2;
                accounts[2] = sample3;
                accounts[3] = sample4;
                accounts[4] = sample5;
                accounts[5] = sample6;
                accounts[6] = sample7;
                accounts[7] = sample8;
                accounts[8] = sample9;
                accounts[9] = sample10;
                Console.WriteLine("Loading successful! Accounts full with presets.\nNOTE: PINs are the account's number recurring.\nEg. 1111, 2222, etc.\n");
                menu();
            }
        }

        //Delete an account currently in the system
        static void deleteAccount()
        {
            Console.WriteLine("\n--- CLOSE ACCOUNT ---");
            Console.Write("\nEnter the card of the account being closed.\nCard Number: ");
            int closeCard = Convert.ToInt32(Console.ReadLine());
            bool found = false;

            for (int i = 0; i < accounts.Length; i++)
            {
                //If a card match is found, show a success message, display the account and verify it
                if (accounts[i] != null && closeCard == accounts[i].getCardNum())
                {
                    found = true;
                    Console.WriteLine(accounts[i].getStatement());
                    Console.Write("Close this account? This cannot be undone.\nEnter PIN to confirm\nEnter another number to abort.\nPIN: ");
                    int closePin = Convert.ToInt32(Console.ReadLine());
                    if (closePin == accounts[i].getPinNum())
                    {
                        accounts[i] = null;
                        Console.WriteLine("\nAccount closed.\n");
                    }
                    else
                    {
                        Console.WriteLine("\nAborted.\n");
                    }
                    break;
                }
            }
            if(found == false)
            {
                Console.WriteLine("NO MATCHES FOUND.\nReturning to menu...\n");
            }
            menu();
        }

        //Delete all accounts currently in the system
        static void clearAccounts()
        {
            Console.WriteLine("\n--- CLOSE ALL ACCOUNTS ---");
            Console.Write("\nAre you sure? This cannot be undone.\n[Y/N]: ");
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
            menu();
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
