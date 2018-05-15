using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalGroupProject.MyDataSetTableAdapters;
namespace FinalGroupProject
{
    public class DAL
    {
        // private fields
  
        private CustomerTableAdapter adpCustomer;
        private MyDataSet.CustomerDataTable tblCustomers;
        private List<BLL> listCustomers;

        // constructor
        public DAL()
        {
            adpCustomer = new CustomerTableAdapter();
            tblCustomers = new MyDataSet.CustomerDataTable();
        }

        public List<BLL> GetAllCustomers()
        { 
            adpCustomer.Fill(tblCustomers);
            listCustomers = null;

            if (tblCustomers.Count > 0)
            {

                listCustomers = new List<BLL>();
                // loop through the table
                foreach (var row in tblCustomers)
                {
                    BLL customer = new BLL();
                    customer.CustId = row.CustID;
                    customer.CustName = row.CustName;
                    customer.Password = row.Password;
                    customer.Email = row.Email;
                    customer.Phone = row.Phone;
                    customer.Address = row.Address;

                    listCustomers.Add(customer);

                }
            }
                return listCustomers;
            
        }
        // used to login the user by using username or password
        public bool AuthenticateUser(BLL customer)
        {
            int result = (int)adpCustomer.checkUsernameAndPassword(customer.CustName, customer.Password);
  
            return result == 1;
        }
        //used to register the user
        public bool InsertCustomer(BLL customer)
        {
          
           int result = adpCustomer.Insert(customer.CustName, customer.Password,
                customer.Email, customer.Phone, customer.Address);
            return result == 1;
        }

        

    }
}