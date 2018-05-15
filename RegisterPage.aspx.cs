using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
namespace FinalGroupProject
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        private BLL bll;

        public RegisterPage()
        {
            bll = new BLL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OkBtn_Click(object sender, EventArgs e)
        {
            //bll is here customer table bll
            BLL customer = new BLL();
            customer.CustName = txtbxName.Text.Trim();
            customer.Password = Encrypter.EncryptText(txtbxPass.Text.Trim());
            customer.Email = txtbxEmail.Text;
            customer.Phone = decimal.Parse(txtbxPhone.Text);
            customer.Address = txtbxAddr.Text;

           // by using bll we are inserting a new customer

            if (bll.InsertCustomer(customer))
            {
                labelOutput.Text = "You have Signed Up";
                labelOutput.ForeColor = System.Drawing.Color.Green;
                FormsAuthentication.RedirectFromLoginPage(customer.CustName, false);
            }
            else
            {
                labelOutput.Text = "Please try again!!";
                labelOutput.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}