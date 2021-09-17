using System;
using System.Collections.Generic;
using System.Text;

namespace BankConsoleSimulator
{
    //Child account of Account which gives interest per deposit
    class SavingsAccount : Account
    {
        private const double INTEREST = 0.005; //Interest value for each deposit
        private double savedTotal = 0; //New total of amount of interest stacked up

        public SavingsAccount(String a, int b, double c) : base(a,b,c)
        {

        }

        //OVERRIDDEN METHODS
        //Deposit - Add interest to each deposit
        public override void deposit()
        {
            Console.WriteLine("\n--- DEPOSIT ---");
            Console.Write("\nAmount: $");
            double amount = Convert.ToDouble(Console.ReadLine());
            //New balance computation with an extra 0.5% interest on top
            double newBalance = base.getBalance() + (amount * INTEREST);
            base.setBalance(newBalance);
            Console.WriteLine(String.Format("SUCCESS.\nCurrent Balance: {0:C}\nExtra Interest: {1:C}", base.getBalance(), (amount * INTEREST)));
        }
        //getDetails - Change type to Savings
        public override String getDetails()
        {
            return " ---------------------\n"
                + "| Surname: " + base.getName()
            +"\n| Card: " + base.getCardNum()
                + "\n| Type: Savings"
                + "\n ---------------------";
        }
        //Display a statement of the account
        public override String getStatement()
        {
            return " ---------------------\n"
                + "| Surname: " + base.getName()
                + "\n| Card: " + base.getCardNum()
                + "\n| Type: Savings"
                + String.Format("\n| Balance: {0:C}", base.getBalance())
                + String.Format("\n| Amount Saved: {0:C}", savedTotal)
                + "\n ---------------------";
        }
    }
}
