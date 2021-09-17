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
        private double lastDeposit = 0;
        private double lastWithdraw = 0; //Statement: Previous amount withdrawn
        private double totalWithdrawn = 0; //Statement: Total amount withdrawn

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
            cardNum = cardRand.Next(10000000, 99999998); //Randomize a card number (99999998 to never reach Admin number)
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
        public double getLastDeposit()
        {
            return lastDeposit;
        }
        public double getLastWithdraw()
        {
            return lastWithdraw;
        }
        public double getTotalWithdrawn()
        {
            return totalWithdrawn;
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
            balance = x;
        }
        public void setLastDeposit(double x)
        {
            lastDeposit = x;
        }
        public void setLastWithdraw(double x)
        {
            lastWithdraw = x;
        }
        public void setTotalWithdrawn(double x)
        {
            totalWithdrawn = x;
        }
        //METHODS (Virtual Methods will be overidden in its child Savings Account class)
        //Withdraw from account
        public virtual void withdraw()
        {
            Console.WriteLine("\n--- WITHDRAW ---");
            Console.Write("\nAmount: $");
            double amount = Convert.ToDouble(Console.ReadLine());
            if(amount <= balance)
            {
                balance -= amount;
                lastWithdraw = amount;
                totalWithdrawn += amount;
                Console.WriteLine(String.Format("SUCCESS.\nRemaining Balance: {0:C}", balance) + "\n");
            }
            else if(amount > balance)
            {
                Console.WriteLine("ERROR: Overdraw.\nNo changes made.\n");
            }
        }
        //Deposit into account
        public virtual void deposit()
        {
            Console.WriteLine("\n--- DEPOSIT ---");
            Console.Write("\nAmount: $");
            double amount = Convert.ToDouble(Console.ReadLine());
            balance += amount; //Add the amount to the balance
            lastDeposit = amount; //Set the last deposit to the current amount
            Console.WriteLine(String.Format("SUCCESS.\nCurrent Balance: {0:C}", balance) + "\n");
        }

        //Display same statement, but without Balance
        public virtual String getDetails()
        {
            return " ---------------------\n"
                + "| Surname: " + name
                + "\n| Card: " + cardNum
                + "\n| Type: Standard"
                + "\n ---------------------\n";
        }
        //Display a statement of the account
        public virtual String getStatement()
        {
            return " -------------------------------------\n"
                + "| Surname: " + name
                + "\n| Card: " + cardNum
                + "\n| Type: Standard"
                + String.Format("\n| Balance: {0:C}", balance)
                + String.Format("\n| Last Deposit: {0:C}", lastDeposit)
                + String.Format("\n| Last Withdraw: {0:C}", lastWithdraw)
                + String.Format("\n| Total Withdrawn: {0:C}", totalWithdrawn)
                + "\n -------------------------------------\n";
        }
    }
}
