using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Entities;

namespace BusinessLayer
{
    class AccountsBL
    {
        public void CreateABL(Accounts newAccount)
        {
            // Call the DAL to create a new record.
            AccountsDAL accountDAL = new AccountsDAL();
            accountDAL.CreateADAL(newAccount);
        }

        public static Accounts Get(int userID, int accID)
        {
            AccountsDAL dal = new AccountsDAL();
            var account = dal.Get(userID, accID);
            return account;
        }

        public static List<Accounts> GetAll(int userID)
        {
            AccountsDAL dal = new AccountsDAL();
            var account = dal.GetAll(userID);

            return account;
        }

        public static Accounts UpdateBalance(int userID, int accID, double balance)
        {
            AccountsDAL dal = new AccountsDAL();
            var account = dal.UpdateBalance(userID, accID, balance);
            return account;
        }
        public static Accounts CloseAccount(int userID, int accID)
        {
            AccountsDAL dal = new AccountsDAL();
            var account = dal.CloseAccount(userID, accID);
            return null;
        }
        public static Accounts AddTransaction(int userID, int accID, string transaction)
        {
            AccountsDAL dal = new AccountsDAL();
            var account = dal.AddTransaction(userID, accID, transaction);
            return account;
        }

    }
}
