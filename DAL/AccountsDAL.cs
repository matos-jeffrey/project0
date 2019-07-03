using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace DAL
{
    public class AccountsDAL
    {
        //Creates an account for a user
        static List<Accounts> accountsList = new List<Accounts>();
        public void CreateADAL(Accounts newAccount)
        {
            accountsList.Add(new Accounts() { userID = newAccount.userID, accountID = newAccount.accountID, accountType = newAccount.accountType, balance = newAccount.balance, interest = newAccount.interest });
        }

        // Connect to DB, search for a specific account for a user
        public Accounts Get(int userID, int accID)
        {
            Accounts acc = null;
            foreach (var i in accountsList)
            {
                if (i.accountID == accID && i.userID == userID)
                {
                    acc = i;
                    break;
                }
            }
            return acc;
        }

        // Connect to the DB and fetch all account records for a user
        public List<Accounts> GetAll(int userID)
        {
            List<Accounts> accs = accountsList.FindAll(acct => acct.userID == userID);
            return accs;
        }

        public Accounts UpdateBalance(int userID, int accID, double balance)
        {
            var itemIndex = accountsList.FindIndex(acct => acct.userID == userID && acct.accountID == accID );
            accountsList[itemIndex].balance = balance;
            Accounts acc = accountsList[itemIndex];

            return acc;
        }

        //Adds transaction log to the account object
        public Accounts AddTransaction(int userID, int accID, string transaction)
        {
            Accounts acc = accountsList.Find(acct => acct.userID == userID && acct.accountID == accID);
            acc.transactions.Add(transaction);

            return acc;
        }

        //Closes an account
        public Accounts CloseAccount(int userID, int accID)
        {
            var itemIndex = accountsList.FindIndex(acct => acct.userID == userID && acct.accountID == accID);
            accountsList.RemoveAt(itemIndex);

            return null;
        }
    }
}
