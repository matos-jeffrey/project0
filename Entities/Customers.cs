using System;

namespace Entities
{
    public class Customers
    {
        static int countID = 100;
        //Creates a class for a new customer asing for basic information
        public int userID = countID++;
        public string fname { get; set; }
        public string lname { get; set; }
        public int dob { get; set; }
        public int ssn { get; set; }
        public string address { get; set; }
        
        public Customers()
        {

        }

        public Customers(string uifname, string uilname, int uidob, int uissn, string uiaddress)
        {
            this.userID = countID++;
            this.fname = uifname;
            this.lname = uilname;
            this.dob = uidob;
            this.ssn = uissn;
            this.address = uiaddress;
        }
    }
}
