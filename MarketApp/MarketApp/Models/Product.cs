using System;
using System.Collections.Generic;
using System.Text;
using MarketApp.Enums;

namespace MarketApp.Models
{
    class Product
    {
        string ItemName;
        double Price;
        Category Category;
        int CountItem;
        int ID;
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
