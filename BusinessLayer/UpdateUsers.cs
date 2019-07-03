using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using DAL;

namespace BusinessLayer
{
    public class UpdateUsers
    {
        public static void UpdateUser(int userID)
        {
            bool cond = true;
            do
            {
                var cust = CustomersBL.Get(userID);
                Console.WriteLine("Hello {0} {1}\n", cust.fname, cust.lname);
                Console.WriteLine("1 - First Name: " + cust.fname);
                Console.WriteLine("2 - Last Name: " + cust.lname);
                Console.WriteLine("3 - Date of Birth: " + cust.dob);
                Console.WriteLine("4 - 4 Digit SSN: " + cust.ssn);
                Console.WriteLine("5 - Address: " + cust.address);
                Console.WriteLine("0 - Go To Main Menu");

                Console.Write("Please Select the Field You Would Like to Update: ");
                string userChoice = Console.ReadLine();

                Console.Write("\n\nUpdated Information: ");
                string userInput = Console.ReadLine();
                int userInputInt = 0;

                switch (userChoice)
                {
                    case "1":
                        CustomersBL.UpdateUser(userID, userInput, cust.lname, cust.dob, cust.ssn, cust.address);
                        break;
                    case "2":
                        CustomersBL.UpdateUser(userID, cust.fname, userInput, cust.dob, cust.ssn, cust.address);
                        break;
                    case "3":
                        do
                        {
                            try
                            {
                                userInputInt = Convert.ToInt32(userInput);
                                cond = false;
                                if (userInputInt.ToString().Length != 8)
                                {
                                    Console.WriteLine("****Please Use Format YYYYMMDD****");
                                    userInputInt = Convert.ToInt32(Console.ReadLine());
                                    cond = true;
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid Value. Please Try Again: ");
                                userInputInt = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("A fatal error has been logged. Please try again\n");
                            }
                        } while (cond);
                        CustomersBL.UpdateUser(userID, cust.fname, cust.lname, userInputInt, cust.ssn, cust.address);
                        break;
                    case "4":
                        do
                        {
                            try
                            {
                                userInputInt = Convert.ToInt32(userInput);
                                cond = false;
                                if (userInputInt.ToString().Length != 4)
                                {
                                    Console.WriteLine("****Please Enter a 4 Digit SSN****");
                                    userInputInt = Convert.ToInt32(Console.ReadLine());
                                    cond = true;
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid Value. Please Try Again: ");
                                userInputInt = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("A fatal error has been logged. Please try again\n");
                            }
                        } while (cond);
                        CustomersBL.UpdateUser(userID, cust.fname, cust.lname, cust.dob, userInputInt, cust.address);
                        break;
                    case "5":
                        CustomersBL.UpdateUser(userID, cust.fname, cust.lname, cust.dob, cust.ssn, userInput);
                        break;
                    case "0":
                        cond = false;
                        BankingOptions.MainMenu(userID);
                        break;
                }
            } while (cond);
        }
    }
}
