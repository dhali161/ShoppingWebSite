using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace FinalGroupProject
{
    public partial class Payment : System.Web.UI.Page
    {
        PaymentBLL paymentbll;
        public Payment()
        {
            paymentbll = new PaymentBLL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CalendarExpiry.Visible= false;
            }

        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            PaymentBLL pay = new PaymentBLL();
            
            pay.CustId = 1;
            pay.CardHolder=TxtBxCardHolder.Text;
            pay.CardNUmber = Int32.Parse(TxtBxCardNo.Text);
            pay.SecurityCode = int.Parse(TxtBxSecuityNo.Text);
           pay.ExpiryDate = CalendarExpiry.SelectedDate;
          //this will be used to insert values of payment info
            if (paymentbll.InsertPayment(pay))
            { 
                LabelOutput.Text = "Your Payment has been approved !!!";
                LabelOutput.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                LabelOutput.Text = "PLease try again!!";
                LabelOutput.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HomeOfSite.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //toggle the visibility of the calendar
            CalendarExpiry.Visible = !CalendarExpiry.Visible;
           
        }

        protected void CalendarExpiry_SelectionChanged(object sender, EventArgs e)
        {  
            TxtBxExpiry.Text = CalendarExpiry.SelectedDate.ToShortDateString();
            CalendarExpiry.Visible = false;

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {

            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}