using System;
using System.Collections.Generic;
using Entities;

namespace DAL
{
    public class CustomersDAL
    {
        static List<Customers> customerList = new List<Customers>();

        //Creates a record of the new user
        public void Create(Customers newCustomer)
        {
            customerList.Add(new Customers() { fname = newCustomer.fname, lname = newCustomer.lname, dob = newCustomer.dob, ssn = newCustomer.ssn, address = newCustomer.address, userID = newCustomer.userID });
        }

        // Connect to DB, search for record with matching id.
        public Customers Get(int Issn, string Iflname, string Ilname)
        {
            Customers cust = null;
            foreach (var i in customerList)
            {
                if (i.ssn == Issn && i.fname == Iflname && i.lname == Ilname)
                {
                    cust = i;
                    break;
                } 
            }
            return cust;
        }

        public Customers Get(int userID)
        {
            Customers cust = null;
            foreach (var i in customerList)
            {
                if (i.userID == userID)
                {
                    cust = i;
                    break;
                }
            }
            return cust;
        }
        public List<Customers> GetAll()
        {
            // Connect to the DB and fetch all Customer records.
            return customerList;
        }

        public Customers UpdateUser(int userID, string fname, string lname, int dob, int ssn, string address)
        {
            var itemIndex = customerList.FindIndex(user => user.userID == userID);

            customerList[itemIndex].fname = fname;
            customerList[itemIndex].lname = lname;
            customerList[itemIndex].dob = dob;
            customerList[itemIndex].ssn = ssn;
            customerList[itemIndex].address = address;

            Customers acc = customerList[itemIndex];
            return acc;
        }

    }
}
