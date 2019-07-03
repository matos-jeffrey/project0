using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace BusinessLayer
{
    public class CreateAccount
    {
        public static void FirstAccount(int userID)
        {
            Console.WriteLine("We offer a variety of accounts each with their own unique interest options" +
                "\n\nOur Checking Account has a competitive monthly interest rate of 0.05%" +
                "\n\nOur Business Account allow you to withdrawl money beyond your \ncurrent balance to allow your business to flourish." +
                "\nThe overdraft ammount is treated as a loan where we offer several \ndifferent interest rate options to meet your business needs:" +
                "\n     5% Compounded Annually \n     2.89% Compounded Semi-Annually \n     1.5% Compounded Quarterly" +
                "\n\nSpeaking about loans we also offer Loan account options which \nallows you to take out even more money than a Business Account does." +
                "\nWe offer competitive interest rates on loans as well!" +
                "\n     $20000 with a 2.5% Annual Rate \n     $50000 with a 5.5% Annual Rate \n     $100000 with a 11% Annual Rate" +
                "\n\nLastly, we offer a Term Deposit Account which allows you to put some cash away and watch it grow:" +
                "\n     4.5% For 1 Year \n     17.5% For 5 Year \n     25% For 10 Year \n");

            Console.WriteLine("------------------------------------------------");
            NewAccount(userID);

            BankingOptions.MainMenu(userID);
        }

        public static void NewAccount(int userID)
        {
            bool cond = true;
            Accounts accountInfo = new Accounts{userID = userID};
            Console.WriteLine("1 - Checking Account \n2 - Business Account \n3 - Loan Account \n4 - Term Deposit Account \n0 - Main Menu");
            Console.Write("Which type of account would you like to open: ");
            do
            {
                string userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    accountInfo.accountType = "Checking Account";
                    accountInfo.interest = 1.0005;
                    cond = false;
                }
                else if (userInput == "2")
                {
                    Console.Clear();
                    accountInfo.accountType = "Business Account";
                    do
                    {
                        Console.WriteLine("\nOpening your Business Account...\nPlease choose an interest rate: \n1 - 5% Compounded Annually \n2 - 2.89% Compounded Semi-Annually \n3 - 1.5% Compounded Quarterly");
                        userInput = Console.ReadLine();
                        if (userInput == "1") { accountInfo.interest = 1.025; cond = false; }
                        else if (userInput == "2") { accountInfo.interest = 1.055; cond = false; }
                        else if (userInput == "3") { accountInfo.interest = 1.11; cond = false; }
                        else { Console.Clear(); Console.WriteLine("****Please Make a Valid Choice From the Options Above****\n"); }
                    } while (cond);
                }
                else if (userInput == "3")
                {
                    Console.Clear();
                    accountInfo.accountType = "Loan Account";
                    do
                    {
                        Console.WriteLine("Opening your Loan Account...\n1 - $20000 with a 2.5% Annual Rate \n2 - $50000 with a 5.5% Annual Rate \n3 - $100000 with a 11% Annual Rate");
                        Console.Write("\nPlease choose a loan offer: ");
                        userInput = Console.ReadLine();
                        if (userInput == "1")
                        {
                            accountInfo.interest = 1.05;
                            accountInfo.balance = -20000;
                            cond = false;
                        }
                        else if (userInput == "2")
                        {
                            accountInfo.interest = 1.0289;
                            accountInfo.balance = -50000;
                            cond = false;
                        }
                        else if (userInput == "3")
                        {
                            accountInfo.interest = 1.015;
                            accountInfo.balance = -100000;
                            cond = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("PLEASE MAKE A VALID CHOICE");
                        }
                    } while (cond);
                }
                else if (userInput == "4")
                {
                    Console.Clear();
                    accountInfo.accountType = "Term Deposit Account";
                    do
                    {
                        Console.WriteLine("Opening your Term Deposit Account...\nPlease choose an interest rate: \n1 - 4.5% For 1 Year \n2 - 17.5% For 5 Year \n3 - 25% For 10 Year");
                        userInput = Console.ReadLine();
                        if (userInput == "1") { accountInfo.interest = 1.045; cond = false; }
                        else if (userInput == "2") { accountInfo.interest = 1.175; cond = false; }
                        else if (userInput == "3") { accountInfo.interest = 1.25; cond = false; }
                        else { Console.Clear();  Console.WriteLine("****Please Make a Valid Choice From the Options Above****\n"); }

                        Console.Write("\nHow much would you like to deposit into your Term Deposit Account: $");
                        
                        bool cond2 = true;
                        double deposit = 0;
                        do
                        {
                            try
                            {
                                deposit = Convert.ToDouble(Console.ReadLine());
                                cond2 = false;
                            }
                            catch (FormatException)
                            {
                                Console.Write("\nPlease enter a valid ammount: $");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("A fatal error has been logged. Please try again ");
                            }
                        } while (cond2);
                        accountInfo.balance = deposit;

                    } while (cond);
                }
                else if (userInput == "0")
                {
                    BankingOptions.MainMenu(userID);
                }
                else
                {
                    Console.WriteLine("\n****Please Make a Valid Choice From the Options Above ****\n");
                }
            } while (cond);
            Console.WriteLine("\nRegistration Complete! Your {0} is now open and active!", accountInfo.accountType);

            AccountsBL accountBL = new AccountsBL();
            accountBL.CreateABL(accountInfo);

            Console.WriteLine("\nPress <ENTER> to continue...");
            Console.ReadLine();
            Console.Clear();

        }
    }
}
