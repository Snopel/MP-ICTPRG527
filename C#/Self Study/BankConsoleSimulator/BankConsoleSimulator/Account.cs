using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BankConsoleSimulator
{
    //Regular bank account class
    class Account
    {
        //ACCOUNT CONTENTS
        private String name; //Name of account holder
        private int cardNum; //Number on the card
        private int pinNum; //PIN Password
        private double balance; //Current balance of the account

        //ACCOUNT UTILITIES
        private Random cardRand = new Random(); //Used to randomize an 8 digit bank number
        private Regex strReg = new Regex("[A-Za-z]+"); //Used to ensure names are not used with numbers or other characters

        //Constructor with passed parameters
        public Account(String a, int b, double c)
        {
            //Using Regular Expressions to ensure the strings are in the correct format
            if (strReg.IsMatch(a) == true)
            {
                name = a;
            }
            cardNum = cardRand.Next(10000000, 99999999); //Randomize a card number
            pinNum = b;
            balance = c;
        }

        //Default Constructor
        public Account()
        {
            name = "";
            cardNum = 0;
            pinNum = 0;
            balance = 0;
        }

        //GETTERS
        public String getName()
        {
            return name;
        }
        public int getCardNum()
        {
            return cardNum;
        }
        public int getPinNum()
        {
            return pinNum;
        }
        public double getBalance()
        {
            return balance;
        }
        //SETTERS
        public void setName(String x)
        {
            name = x;
        }
        public void setCardNum(int x) //Will most likely never be used except debugging
        {
            cardNum = x;
        }
        public void setPinNum(int x)
        {
            pinNum = x;
        }
        public void setBalance(double x)
        {
            balance = 0;
        }

        //METHODS
        //Withdraw from account
        public void withdraw()
        {
            Console.WriteLine("\n--- WITHDRAW ---");
            Console.Write("\nAmount: $");
            double amount = Convert.ToDouble(Console.ReadLine());
            if(amount <= balance)
            {
                balance -= amount;
                Console.WriteLine(String.Format("SUCCESS.\nRemaining Balance: {0:C}", balance));
            }
            else if(amount > balance)
            {
                Console.WriteLine("ERROR: Overdraw.\nNo changes made.");
            }
        }
        //Deposit into account
        public virtual void deposit()
        {
            Console.WriteLine("\n--- DEPOSIT ---");
            Console.Write("\nAmount: $");
            double amount = Convert.ToDouble(Console.ReadLine());
            balance += amount;
            Console.WriteLine(String.Format("SUCCESS.\nCurrent Balance: {0:C}", balance));
        }

        //Display same statement, but without Balance
        public virtual String getDetails()
        {
            return " ---------------------\n"
                + "| Surname: " + name
                + "\n| Card: " + cardNum
                + "\n| Type: Standard"
                + "\n ---------------------";
        }
        //Display a statement of the account
        public virtual String getStatement()
        {
            return " ---------------------\n"
                + "| Surname: " + name
                + "\n| Card: " + cardNum
                + "\n| Type: Standard"
                + String.Format("\n| Balance: {0:C}", balance)
                + "\n ---------------------";
        }
    }
}
