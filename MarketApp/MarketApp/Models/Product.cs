using System;
using System.Collections.Generic;
using System.Text;
using MarketApp.Enums;

namespace MarketApp.Models
{
    class Product
    {
        public string ItemName;
        public double Price;
        public Category Category;
        public int CountItem;
        public int ID;
        public static List<Product> products;

        public Product(string itemName, double price, Category category, int countItem, int id)
        {
            ItemName = itemName;
            Price = price;
            Category = category;
            CountItem = countItem;
            ID = id;
        }
    }
}
