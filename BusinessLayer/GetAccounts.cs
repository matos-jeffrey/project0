using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using DAL;

namespace BusinessLayer
{
    public class GetAccounts
    {
        public static Accounts GetAccount(int userID)
        {
            var allAccounts = AccountsBL.GetAll(userID);
            
            foreach (var i in allAccounts)
            {
                if ((i.accountType == "Loan Account") || (i.accountType == "Business Account" && i.balance < 0))
                {
                    Console.WriteLine("{0} - {1} currently owe ${2}", i.accountID, i.accountType, -1*i.balance);
                }
                else
                {
                    Console.WriteLine("{0} - {1} with a balance of ${2}", i.accountID, i.accountType, i.balance);
                }  
            }

            Console.WriteLine("0 - Go Back to Main Menu");

            Console.Write("Please Choose an Account: ");
            int userInput = -1; 

            bool cond = true;
            do
            {
                try
                {
                    userInput = Convert.ToInt32(Console.ReadLine());
                    if (userInput == 0) { BankingOptions.MainMenu(userID); cond = true; }
                    if (AccountsBL.Get(userID, userInput) == null) { Console.WriteLine("****Please Choose a Valid Account****"); }
                    else { cond = false; }
                }
                catch (FormatException)
                {
                    Console.WriteLine("****Please Choose a Valid Account****");
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("****Please Choose a Valid Account****");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("A fatal error has been logged. Please try again ");
                }
               
            } while (cond);
                        
            return AccountsBL.Get(userID, userInput);
        }           
    }
}
