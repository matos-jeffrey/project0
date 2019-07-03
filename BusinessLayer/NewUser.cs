using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace BusinessLayer
{
    public class NewUser
    {
        public static void CreateUser()
        {
            Console.WriteLine("Thank you for choosing our service. \nOur goal is to fulfill all of your banking needs! \n\nIn order to begin we are going to need some basic information:");

            Customers customer = new Customers();
            // Asks the customer for basic information to create an account

            
            bool response = true;
            do
            {
                Console.WriteLine("\nPlease enter your first name");
                customer.fname = Console.ReadLine();
                if (customer.fname != "") { response = false; }
            } while (response);

            response = true;
            do
            {
                Console.WriteLine("Please enter your last name");
                customer.lname = Console.ReadLine();
                if (customer.lname != "") { response = false; }
            } while (response);

            response = true;
            do
            {
                try
                {
                    Console.WriteLine("Please enter your date of birth (Use Format YYYYMMDD)");
                    customer.dob = Convert.ToInt32(Console.ReadLine());
                    response = false;
                    if (customer.dob.ToString().Length != 8) { Console.WriteLine("****Please enter a valid date of birth****"); response = true; }
                }
                catch (FormatException)
                {
                    Console.WriteLine("****Please enter a valid date of birth****");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("A fatal error has been logged. Please try again ");
                }
            } while (response);

            response = true;
            do
            {
                try
                {
                    Console.WriteLine("Please enter the last four digits of your social security number");
                    customer.ssn = Convert.ToInt32(Console.ReadLine());
                    response = false;
                    if (customer.ssn.ToString().Length != 4) { Console.WriteLine("****Please enter a valid social security number****"); response = true; }
                }
                catch (FormatException)
                {
                    Console.WriteLine("****Please enter a valid social security number****");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("A fatal error has been logged. Please try again ");
                }
            } while (response);

            response = true;
            do
            {
                Console.WriteLine("Please enter your address");
                customer.address = Console.ReadLine();
                if (customer.address != "") { response = false; }
            } while (response);

            //Ask users if info is ok and give option to update
            CustomersBL customerBL = new CustomersBL();
            customerBL.Create(customer);

            Console.WriteLine("\nPress <ENTER> to continue...");
            Console.ReadLine();
            Console.Clear();

            //Allows a User to Create Their First Account
            CreateAccount.FirstAccount(customer.userID);
        }
    }
}
