using System;
using System.Collections.Generic;
using System.Text;


namespace BusinessLayer
{
    public class HomePage
    {
        public static void LoginMenu()
        {
            Console.WriteLine("Welcome to Net Bank!! \n\n1 - Login \n2 - Open An Account\n");
            Console.Write("What Would you like to do: ");
            string userInput;

            bool cond = true;
            do
            {
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //Directs user to page to log into their user profile
                        Console.Clear();
                        LoginPage.LoginInfo();
                        break;
                    case "2":
                        //Directs user to page for creating a profile
                        Console.Clear();
                        cond = false;
                        NewUser.CreateUser();
                        break;
                    default:
                        Console.Write("Please Enter a valid option: ");
                        break;
                }
            } while (cond);
        }
    }
}
