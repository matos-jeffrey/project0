using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Entities;

namespace BusinessLayer
{
    public class Transactions
    {
        public static Accounts ViewTransactions(int userID)
        {
            Console.Write("Which List of Transactions Would You Like to See? \n");
            var acc = GetAccounts.GetAccount(userID);
            Console.Clear();

            Console.Write("All Transactions for {0} - {1} \n\n", acc.accountID, acc.accountType);
            int count = 1;

            try
            {
                foreach (var i in acc.transactions)
                {
                    Console.WriteLine(count + ". " + i);
                    count++;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\nThere have not been any transactions on this account \n");
            }
            Console.WriteLine("");
            
            Console.WriteLine("\nPress <ENTER> to return to Main Menu...");
            Console.ReadLine();
            Console.Clear();

            return null;
        }
    }
}
