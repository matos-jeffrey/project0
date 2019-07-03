using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace BusinessLayer
{
    public class LoginPage
    {
        public static void LoginInfo()
        {
            Console.WriteLine("Welcome back to Net Bank!\n");

            Customers user;
            bool cond2 = true;
            do
            {
                Console.Write("First Name: ");
                string fname = Console.ReadLine();

                Console.Write("Last Name: ");
                string lname = Console.ReadLine();

                bool cond = true;
                int ssn = 0;
                do
                {
                    try
                    {
                        Console.Write("Last 4 Digits of SSN: ");
                        ssn = Convert.ToInt32(Console.ReadLine());
                        cond = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("***Please Enter a Valid SSN***\n");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("A fatal error has been logged. Please try again\n");
                    }
                } while (cond);

                user = CustomersBL.Get(ssn, fname, lname);
                if (user == null)
                {
                    Console.WriteLine("\nLogin Failed, Profile Was Not Found \nReturning to Home Menu ");
                    Console.WriteLine("\nPress <ENTER> to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    HomePage.LoginMenu();
                }
                else { cond2 = false; }
            } while (cond2);

            BankingOptions.MainMenu(user.userID);
        }
    }
}
