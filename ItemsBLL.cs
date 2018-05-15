using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalGroupProject
{
    public class ItemsBLL
    {
        private ItemsDAL itemsDAL;

        //constructor
        public ItemsBLL()
        {
            itemsDAL = new ItemsDAL();
        }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public decimal Quantity { get; set; }


        public List<ItemsBLL> GetAllItems()
        {
            return itemsDAL.GetAllItems();
        }

       public ItemsBLL GetDataByid(int id)
        {
            return itemsDAL.GetProductById(id);
       }
    }
}