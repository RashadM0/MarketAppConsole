using System;
using System.Collections.Generic;
using System.Text;
using MarketApp.Enums;
using MarketApp.Models;
using MarketApp.Services;

namespace MarketApp.Models
{
    class Product : Marketable
    {
        private static int _id = 0;
        public string ItemName;
        public double Price;
        public Category Category;
        public int CountItem;
        public int ID { get; set; }
        public DateTime date;
        public Product(string itemName, double price, Category category, int countItem)
        {
            ItemName = itemName;
            Price = price;
            Category = category;
            CountItem = countItem;
            ID = ++_id;
            date = DateTime.Now;
        }
        Marketable marketable = new Marketable();
        public override string ToString()
        {
            return $"\n++++++++++++++++++++++++" +
                $"\nID: {ID}" +
                $"\nItem Name: {ItemName}" +
                $"\nPrice: {Price}$" +
                $"\nCategory: {Category}" +
                $"\nItem Left: {CountItem}" +
                $"\n++++++++++++++++++++++++\n"; ;
        }
    }
}
