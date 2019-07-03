using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Accounts
    {
        static int countID = 200;
        //Creates a class for a new customer asing for basic information
        public int userID { get; set; }
        public int accountID = countID++;
        public string accountType { get; set; }
        public double balance { get; set; }
        public double interest { get; set; }
        public List<String> transactions = new List<string>();

        public Accounts()
        {

        }

        public Accounts(int custID, string account, double balance, double interest)
        {
            this.userID = custID;
            this.accountID = countID++;
            this.accountType = account;
            this.balance = balance;
            this.interest = interest;
            this.transactions = new List<String>();
        }
    }
}
