using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalGroupProject
{

    public class OrderBLL
    {
        private OrderDAL orderDAL;

        public OrderBLL()
        {
            orderDAL = new OrderDAL();
        }
        public int OrderId { get; set; }
       // public int CustomerId { get; set; }
        public int ItemId { get; set; }
        public string shippedAddr { get; set; }
        public decimal Price { get; set; }
        public string Shipped { get; set; }

        public bool InsertOrder(OrderBLL order)
        {
            return orderDAL.InsertOrder(order);
        }
        public List<OrderBLL> GetAllOrders()
        {
            return orderDAL.GetAllOrders();
        }

        public bool DeleteItem(int id)
        {
            return orderDAL.DeleteItem(id);
        }
    }
}