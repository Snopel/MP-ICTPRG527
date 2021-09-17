using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulator
{
    //Class to keep a system of all accounts
    class AccountList
    {
        //Array to hold all accounts
        Account[] accounts = new Account[10];

        //Add an account to the array
        public void addAccount(Account acc)
        {
            for(int i = 0; i < accounts.Length; i++)
            {
                if(accounts[i] == null)
                {
                    accounts[i] = acc;
                    break;
                }
            }
        }

    }
}
