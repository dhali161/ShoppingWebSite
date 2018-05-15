using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalGroupProject.MyDataSetTableAdapters;

namespace FinalGroupProject
{
    public class OrderDAL
    {
        private OrdersTableAdapter adpOrder;
        private MyDataSet.OrdersDataTable tblOrders;
        private List<OrderBLL> listOrders;

        public OrderDAL()
        {
            adpOrder = new OrdersTableAdapter();
            tblOrders = new MyDataSet.OrdersDataTable();
        }
        public List<OrderBLL> GetAllOrders()
        {
            adpOrder.Fill(tblOrders);
            listOrders = null;
            if(tblOrders.Count>0)
          
            {
                //this list will be used to fill data in the grid view of cart
                listOrders = new List<OrderBLL>();
         
                foreach (var row in tblOrders)
                {
                    
                    OrderBLL order = new OrderBLL();
                    order.OrderId = row.OrderID;
                    order.ItemId = row.ItemID;
                    //order.CustomerId = row.CustID;
                    order.shippedAddr = row.ShippingAddress;
                    order.Price = row.Price;
                    order.Shipped = row.Shipped;
                    listOrders.Add(order);
                }
            }

            return listOrders;
        }
        // this will be used to add items to cart
        public bool InsertOrder(OrderBLL order)
        {
            int result = adpOrder.Insert( order.ItemId, order.ItemId, order.shippedAddr, order.Price, order.Shipped);
            return result == 1;
        }

        public bool DeleteItem(int id)
        {
            int result = adpOrder.Delete(id);
            return result == 1;
        }
    }
}