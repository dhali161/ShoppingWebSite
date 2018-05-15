using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalGroupProject.MyDataSetTableAdapters;
namespace FinalGroupProject
{
    public class ItemsDAL
    {
        private ItemsTableAdapter adpItems;
        private MyDataSet.ItemsDataTable tblItems;
        private List<ItemsBLL> listItems;

        // constructor
        public ItemsDAL()
        {
            adpItems = new ItemsTableAdapter();
            tblItems = new MyDataSet.ItemsDataTable();
        }

        // public methods
        public List<ItemsBLL> GetAllItems()
        {
            adpItems.Fill(tblItems);
            listItems = null;
           
            if (tblItems.Count > 0)
            {
                listItems = new List<ItemsBLL>();
                
                foreach (var row in tblItems)
                {
                    ItemsBLL items = new ItemsBLL();
                    items.ItemId = row.ItemID;
                    items.ItemName = row.ItemName;
                    items.Description = row.Description;
                    items.Price = row.Price;
                    items.Image = row.Image;
                    items.Quantity = row.Quantity;

                    listItems.Add(items);
                  
                }
            }
            return listItems;

        }
        public ItemsBLL GetProductById(int id)
        {
            int rowsFetched = adpItems.FillByID(tblItems, id);
            ItemsBLL items = null;
           
            if (rowsFetched == 1)
            {
                items = new ItemsBLL();
                var row = tblItems[0];
                items.ItemId = row.ItemID;
                items.ItemName = row.ItemName;
                items.Price = row.Price;
                items.Quantity = row.Quantity;
                items.Description = row.Description;
                items.Image = row.Image;
            }

            return items;
        }
     //   public bool InsertQuantity(ItemsBLL item,string quantity,int id)
     //   {
           // int result = adpItems.updateQuantity(quantity, id);
           // return result == 1;
       // }

    }

}