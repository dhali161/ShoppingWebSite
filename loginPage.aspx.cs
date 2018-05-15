using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using FinalGroupProject.MyDataSetTableAdapters;

namespace FinalGroupProject
{
    public partial class loginPage : System.Web.UI.Page
    {
        private BLL bll;
        
        
        public loginPage()
        {
            bll = new BLL();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        protected void RegBtn_Click(object sender, EventArgs e)
        {
            
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            BLL customer = new BLL();
            string username = TxtBoxUserName.Text.Trim();
            string password = Encrypter.EncryptText(TxtBoxPsswrd.Text.Trim());
      
            customer.CustName = username;
            customer.Password = password;
            
            //check if user exists in the table then login the user
            if (bll.AuthenticateUser(customer))
            {
                labelOutput.Text = "Login Done!";
                labelOutput.ForeColor = System.Drawing.Color.Green;
               

                FormsAuthentication.RedirectFromLoginPage(username, false);
            }
            else
            {
                labelOutput.Text = "Login failed. Please try again.";
                labelOutput.ForeColor = System.Drawing.Color.Red;
                }
           
        }

    }
}