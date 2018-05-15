using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalGroupProject
{
    public class PaymentBLL
    {
        private PaymentDAL paymentDAL;
      
        public PaymentBLL()
        {
            paymentDAL = new PaymentDAL();
        }

        public int CustId { get; set; }
        public string CardHolder { get; set; }
        public Int32 CardNUmber { get; set; }
        public int SecurityCode { get; set; }
        public DateTime ExpiryDate { get; set; }
        
        public bool InsertPayment(PaymentBLL pay)
        {
            return paymentDAL.InsertPayment(pay);
        }
    }
}