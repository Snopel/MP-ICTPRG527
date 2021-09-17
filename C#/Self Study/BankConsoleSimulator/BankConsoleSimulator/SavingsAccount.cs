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

        public SavingsAccount(String a, int b, double c) : base(a, b, c) { }

        //OVERRIDDEN METHODS
        //Deposit - Add interest to each deposit
        public override void deposit()
        {
            Console.WriteLine("\n--- DEPOSIT ---");
            Console.Write("\nAmount: $");
            double amount = Convert.ToDouble(Console.ReadLine());
            //New balance computation with an extra 0.5% interest on top
            base.setBalance(base.getBalance() + (amount + (amount * INTEREST)));
            base.setLastDeposit(amount);
            savedTotal += amount * INTEREST;
            Console.WriteLine(String.Format("SUCCESS.\nCurrent Balance: {0:C}\nExtra Interest: {1:C}\n", base.getBalance(), (amount * INTEREST)));
        }
        //Withdraw - Withdraw the entire amount
        public override void withdraw()
        {
            Console.WriteLine("\n--- WITHDRAW ---");
            Console.Write("NOTE: In a Savings Account, the entire balance is withdrawn.\nProceed? [Y|N]: ");
            String input = Console.ReadLine();
            if (input.ToUpper() == "Y")
            {
                if (base.getBalance() <= 0)
                {
                    Console.WriteLine("ERROR: No money in account to withdraw.\n");
                }
                else
                {
                    base.setLastWithdraw(base.getBalance());
                    base.setTotalWithdrawn(base.getTotalWithdrawn() + base.getBalance());
                    base.setBalance(0);
                    Console.WriteLine(String.Format("Money successfully withdrawn.\nAmount Withdrawn: {0:C}\n", base.getLastWithdraw()));
                }
            }
            else if (input.ToUpper() == "N")
            {
                Console.WriteLine("Aborted.\n");
            }
            else
            {
                Console.WriteLine("Invalid input.\n");
            }
        }
        //getDetails - Change type to Savings
        public override String getDetails()
        {
            return " ---------------------\n"
                + "| Surname: " + base.getName()
            +"\n| Card: " + base.getCardNum()
                + "\n| Type: Savings"
                + "\n ---------------------\n";
        }
        //Display a statement of the account
        public override String getStatement()
        {
            return " --------------------------------------\n"
                + "| Surname: " + base.getName()
                + "\n| Card: " + base.getCardNum()
                + "\n| Type: Savings"
                + String.Format("\n| Balance: {0:C}", base.getBalance())
                + String.Format("\n| Last Deposit: {0:C}", base.getLastDeposit())
                + String.Format("\n| Last Withdraw: {0:C}", base.getLastWithdraw())
                + String.Format("\n| Total Withdrawn: {0:C}", base.getTotalWithdrawn())
                + String.Format("\n| Interest Saved: {0:C}", savedTotal)
                + "\n --------------------------------------\n";
        }
    }
}
