using System;
using Entities;
using DAL;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class CustomersBL
    {
        public void Create(Customers newCustomer)
        {
            // Call the DAL to create a new record.
            CustomersDAL customerDAL = new CustomersDAL();
            customerDAL.Create(newCustomer);
        }

        public static Customers Get(int Issn, string Iflname, string Ilname)
        {
            CustomersDAL dal = new CustomersDAL();
            var customer = dal.Get(Issn, Iflname, Ilname);
            return customer;
        }

        public static Customers Get(int userID)
        {
            CustomersDAL dal = new CustomersDAL();
            var customer = dal.Get(userID);
            return customer;
        }

        public static Customers UpdateUser(int userID, string fname, string lname, int dob, int ssn, string address)
        {
            CustomersDAL dal = new CustomersDAL();
            var account = dal.UpdateUser(userID, fname, lname, dob, ssn, address);
            return account;
        }

        public static List<Customers> GetAll()
        {
            CustomersDAL dal = new CustomersDAL();
            var customers = dal.GetAll();

            return customers;
        }
    }
}
