using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalGroupProject
{
    public class BLL
    {
        // private fields
        private DAL customerDAL;

        //constructor
        public BLL()
        {
            customerDAL = new DAL();
        }

        // properties that correspond to the table columns
        public int CustId { get; set; }
        public string CustName { get; set; }
        public string Password { get; set; }
        public string Email{ get; set; }
        public string Address { get; set; }
        public decimal Phone { get; set; }


        public List<BLL> GetAllCustomers()
        {
            return customerDAL.GetAllCustomers();
        }

        public bool InsertCustomer(BLL product)
        {
            return customerDAL.InsertCustomer(product);
        }
        public bool AuthenticateUser(BLL customer)
        {
            return customerDAL.AuthenticateUser(customer);
        }

    }
}