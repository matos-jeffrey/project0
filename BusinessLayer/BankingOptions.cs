using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class BankingOptions
    {
        public static void MainMenu(int userID)
        {
            Console.Clear();
            bool response = true;
            do
            {
                Console.WriteLine("Hello, \nWelcome to Net Bank! How may we help you today?\n");

                Console.WriteLine("0 - View Transactions \n1 - Deposit/Pay Loan \n2 - Withdraw \n3 - Transfer \n4 - Update Personal Info \n5 - New Account \n6 - Close Account \n7 - Sign Out");

                //In View Balance Add option to see transactions

                Console.Write("\nWhat would you like to do today: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        Console.Clear();
                        Transactions.ViewTransactions(userID);
                        break;
                    case "1":
                        Console.Clear();
                        Deposit(userID);
                        break;
                    case "2":
                        Console.Clear();
                        Withdraw(userID);
                        break;
                    case "3":
                        Console.Clear();
                        Transfer(userID);
                        break;
                    case "4":
                        Console.Clear();
                        UpdateUsers.UpdateUser(userID);
                        break;
                    case "5":
                        Console.Clear();
                        CreateAccount.NewAccount(userID);
                        break;
                    case "6":
                        Console.Clear();
                        CloseAccount(userID);
                        break;
                    case "7":
                        Console.Clear();
                        Console.WriteLine("Thank You For Using Our Service!\nPress <ENTER> to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        HomePage.LoginMenu();
                        break;
                    default:
                        Console.WriteLine("****Please Enter a valid option****");
                        break;
                }
                //if (userInput == "1") { Console.Clear(); Deposit(); }
                //else if (userInput == "2") { Console.Clear(); Withdraw(); }
                //else if (userInput == "3") { Console.Clear(); Transfer(); }
                //else if (userInput == "4") { Console.Clear(); /*InfoUpdate();*/ }
                //else if (userInput == "5") { Console.Clear(); CreateAccount.NewAccount(); }
                //else if (userInput == "6") { Console.Clear(); CloseAccount(); }
                //else { Console.WriteLine("****Please Enter a valid option****"); }
            } while (response);
        }

        public static void Deposit(int userID)
        {
            Console.WriteLine("**You Can Deposit Into a Loan Account to Make a Payment**\n");
            var acc = GetAccounts.GetAccount(userID);
            Console.Clear();

            bool cond = true;
            do
            {
                if ((acc.accountType == "Term Deposit Account"))
                {
                    Console.Write("Cannot Deposit Into a {0}. \nPlease Choose a Valid Account: ", acc.accountType);
                    acc = GetAccounts.GetAccount(userID);
                }
                else { cond = false; }
            } while (cond);

            Console.WriteLine("Depositing to {1} - {0} \nBalance of ${2}\n", acc.accountID, acc.accountType, acc.balance);
            double ammount = 0;

            cond = true;
            bool cond2 = true;
            do
            {
                try
                {
                    do
                    {
                        Console.Write("Deposit Amount: $");
                        ammount = Convert.ToDouble(Console.ReadLine());

                        if (ammount.ToString().Split(".")[1].Length != 2)
                        {
                            Console.WriteLine("****Please Enter a Valid Amount****\n");
                        } 
                        else { cond2 = false; }
                    } while (cond2);
                    cond = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("****Please Enter a Valid Amount****\n");
                }
                catch (IndexOutOfRangeException)
                {
                    cond = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("A fatal error has been logged. Please try again\n");
                }
            } while (cond);

            double newBal = ammount + acc.balance;
            string transaction = "Deposited " + ammount + " into account";
            acc = AccountsBL.UpdateBalance(acc.userID, acc.accountID, newBal);
            acc = AccountsBL.AddTransaction(acc.userID, acc.accountID, transaction);

            Console.WriteLine("\nYour New Balance is $" + newBal);
            Console.WriteLine("\nPress <ENTER> to continue...");
            Console.ReadLine();
            Console.Clear();
        }
        public static void Withdraw(int userID)
        {
            var acc = GetAccounts.GetAccount(userID);
            Console.Clear();

            bool cond = true;
            do
            {
                if ((acc.accountType == "Term Deposit Account") || (acc.accountType == "Loan Account"))
                {
                    Console.Write("Cannot Withdraw From a {0}. \nPlease Choose a Valid Account: ", acc.accountType);
                    acc = GetAccounts.GetAccount(userID);
                }
                else if (acc.accountType == "Business Account" && acc.balance <= -10000)
                {
                    Console.Write("Cannot Withdraw From {0}. Overdraft Limit Reached! \nPlease Choose a Valid Account: ", acc.accountType);
                    acc = GetAccounts.GetAccount(userID);
                }
                else { cond = false; }
            } while (cond);
            Console.WriteLine("Withdrawing from {1} - {0} \nBalance of ${2}", acc.accountID, acc.accountType, acc.balance);
            double ammount = 0;

            cond = true;
            bool cond2 = true;
            do
            {
                try
                {
                    do
                    {
                        Console.Write("\nWithdraw Amount: $");
                        ammount = Convert.ToDouble(Console.ReadLine());

                        if (ammount.ToString().Split(".")[1].Length != 2)
                        {
                            Console.WriteLine("****Please Enter a Valid Amount****\n");
                        }
                        else { cond2 = false; }
                    } while (cond2);
                    cond = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("****Please enter a valid ammount****");
                }
                catch (IndexOutOfRangeException)
                {
                    cond = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("A fatal error has been logged. Please try again ");
                }
            } while (cond);

            cond = true;
            do
            {
                if ((acc.accountType == "Checking Account" && (acc.balance - ammount) < 0) || (acc.accountType == "Business Account" && (acc.balance - ammount) < -10000))
                {
                    try
                    {
                        Console.Write("\nInsufficient Funds. \nPlease Enter a Valid Ammount: $");
                        ammount = Convert.ToDouble(Console.ReadLine());
                        cond = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("****Please enter a valid ammount****\n");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("A fatal error has been logged. Please try again ");
                    }
                }
                else { cond = false; }
            } while (cond);

            double newBal = acc.balance - ammount;
            string transaction = "Withdrew " + ammount + " into account";
            acc = AccountsBL.UpdateBalance(acc.userID, acc.accountID, newBal);
            acc = AccountsBL.AddTransaction(acc.userID, acc.accountID, transaction);

            Console.WriteLine("\nYour New Balance is $" + newBal);
            Console.WriteLine("\nPress <ENTER> to continue...");
            Console.ReadLine();
            Console.Clear();
        }

        public static void Transfer(int userID)
        {
            Console.WriteLine("Which Account Do You Want To Transfer From? \n");
            var accFrom = GetAccounts.GetAccount(userID);
            bool cond = true;
            do
            {
                if (accFrom.accountType == "Term Deposit Account" || accFrom.accountType == "Loan Account")
                {
                    Console.WriteLine("\nCannot Transfer From a {0}. \nPlease choose a Valid Account: ", accFrom.accountType);
                    accFrom = GetAccounts.GetAccount(userID);
                }
                else { cond = false; }
            } while (cond);

            Console.WriteLine("\n**You Can Transfer Into a Loan Account to Make a Payment**");
            
            double ammount = -1;
            cond = true;
            bool cond2 = true;
            do {
                try
                {
                    do
                    {
                        Console.Write("\nAmount You Want to Transfer: $");
                        ammount = Convert.ToDouble(Console.ReadLine());

                        if (ammount.ToString().Split(".")[1].Length != 2)
                        {
                            Console.WriteLine("****Please Enter a Valid Amount****\n");
                        }
                        else { cond2 = false; }
                    } while (cond2);
                    cond = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("****Please enter a valid ammount****\n");
                }
                catch (IndexOutOfRangeException)
                {
                    cond = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("A fatal error has been logged. Please try again ");
                }
            } while (cond);



            cond = true;
            cond2 = true;
            do
            {
                if (accFrom.accountType == "Checking Account" && (accFrom.balance - ammount) < 0)
                {
                    //This Do While Handles Exceptions
                    do
                    {
                        try
                        {
                            //This Do While Loops Handles The Decimal Places of the Entered Ammount
                            do
                            {
                                Console.Write("\nInsufficient Funds. \nPlease Enter a Valid Ammount: $");
                                ammount = Convert.ToDouble(Console.ReadLine());

                                if (ammount.ToString().Split(".")[1].Length != 2)
                                {
                                    Console.WriteLine("****Please Enter a Valid Amount****\n");
                                }
                                else { cond2 = false; }
                            } while (cond2);
                            cond = false;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("****Please enter a valid ammount****\n");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            cond = false;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("A fatal error has been logged. Please try again ");
                        }
                    } while (cond);
                    cond = true;

                }
                else { cond = false; }
            } while (cond);

            Console.WriteLine("\nWhich Account Do You Want To Transfer the Money To?\n");
            var accTo = GetAccounts.GetAccount(userID);

            cond = true;
            do
            {
                if (accTo.accountType == "Term Deposit Account")
                {
                    Console.WriteLine("\nCannot Transfer To a {0}. \nPlease choose a Valid Account: ", accTo.accountType);
                    accTo = GetAccounts.GetAccount(userID);
                }
                else { cond = false; }
            } while (cond);

            Console.WriteLine("\nTransfering {0} From {1}-{2} to {3}-{4}", ammount, accFrom.accountType, accFrom.accountID, accTo.accountType, accTo.accountID);

            //Withdrawing out funds from first account
            double newBal = accFrom.balance - ammount;
            accFrom = AccountsBL.UpdateBalance(accFrom.userID, accFrom.accountID, newBal);
            string transaction = "Transferred " + ammount + " into Account " + accTo.accountID + " from Account " + accFrom.accountID;
            accFrom = AccountsBL.AddTransaction(accFrom.userID, accFrom.accountID, transaction);

            //Depositing funds into second account 
            newBal = ammount + accTo.balance;
            accTo = AccountsBL.UpdateBalance(accTo.userID, accTo.accountID, newBal);
            accTo = AccountsBL.AddTransaction(accTo.userID, accTo.accountID, transaction);

            Console.WriteLine("Transfer Complete!\n");

            Console.WriteLine("Your New Balance for {0}-{1} is ${2}", accFrom.accountType, accFrom.accountID, accFrom.balance);
            Console.WriteLine("Your New Balance for {0}-{1} is ${2}", accTo.accountType, accTo.accountID, accTo.balance);
            Console.WriteLine("\nPress <ENTER> to continue...");
            Console.ReadLine();
            Console.Clear();

        }
        public static void CloseAccount(int userID)
        {
            Console.WriteLine("Select Which Account You Would Like to Close");
            var acc = GetAccounts.GetAccount(userID);
            var accExist = AccountsBL.CloseAccount(acc.userID, acc.accountID);
            if (accExist == null) { Console.WriteLine("Your Account Has Successfully Been Closed"); }
            Console.WriteLine("\nPress <ENTER> to continue...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
