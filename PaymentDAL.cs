using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalGroupProject.MyDataSetTableAdapters;

namespace FinalGroupProject
{
    public class PaymentDAL
    {
        private PaymentInfoTableAdapter adpPay;
        private MyDataSet.PaymentInfoDataTable tblPayment;
        //private List<PaymentBLL> listPay;
        public PaymentDAL()
        {
            adpPay = new PaymentInfoTableAdapter();
            tblPayment = new MyDataSet.PaymentInfoDataTable();
        }
        //this will be used to insert the credit card info in payment table
        public bool InsertPayment(PaymentBLL pay)
        {
            int result = adpPay.Insert(pay.CustId,pay.CardHolder,pay.CardNUmber,pay.SecurityCode,pay.ExpiryDate);
            return result == 1;
        }
    }
}