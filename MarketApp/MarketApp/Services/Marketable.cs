using System;
using System.Collections.Generic;
using System.Text;
using MarketApp.Enums;
using MarketApp.Interfaces;
using MarketApp.Models;

namespace MarketApp.Services
{
    class Marketable : IMarketable
    {
        public List<Product> products = new List<Product>();
        //public List<Product> drinkable = new List<Product>();
        //public List<Product> cigarettes = new List<Product>();
        //public List<Product> others = new List<Product>();
        #region Products
        public void AddProducts(Product product/*string itemName, double price, Category category, int countItem*/)
        {
            //Product product = new Product(itemName, price, category, countItem);
            products.Add(product);
        }
        public void EditProducts(string name, string newName, int count, double amount, Category category, int id)
        {
            //if (category == Category.Food)
            //{
            //    foreach (var item in foods)
            //    {
            //        if (item.ID == id)
            //        {
            //            Console.WriteLine("Food Detected: ");
            //            Console.WriteLine("++++++++++++++++++++++++++++++++++++++" +
            //            $"\n{item.ItemName}" +
            //            "\n++++++++++++++++++++++++++++++++++++++" +
            //            $"\n{item.Price}$" +
            //            "\n++++++++++++++++++++++++++++++++++++++" +
            //            $"\n{item.CountItem}" +
            //            "\n++++++++++++++++++++++++++++++++++++++" +
            //            $"\n{item.ID}\n\n");
            //        }
            //    }
            //}
            //if (category == Category.Drinkable)
            //{
            //    foreach (var item in drinkable)
            //    {
            //        if (item.ID == id)
            //        {
            //            Console.WriteLine("Drinks Detected: ");
            //            Console.WriteLine("++++++++++++++++++++++++++++++++++++++" +
            //            $"\n{item.ItemName}" +
            //            "\n++++++++++++++++++++++++++++++++++++++" +
            //            $"\n{item.Price}$" +
            //            "\n++++++++++++++++++++++++++++++++++++++" +
            //            $"\n{item.CountItem}" +
            //            "\n++++++++++++++++++++++++++++++++++++++" +
            //            $"\n{item.ID}\n\n");
            //        }
            //    }
            //}
            //if (category == Category.Cigarettes)
            //{
            //    foreach (var item in cigarettes)
            //    {
            //        if (item.ID == id)
            //        {
            //            Console.WriteLine("Smokes Detected: ");
            //            Console.WriteLine("++++++++++++++++++++++++++++++++++++++" +
            //            $"\n{item.ItemName}" +
            //            "\n++++++++++++++++++++++++++++++++++++++" +
            //            $"\n{item.Price}$" +
            //            "\n++++++++++++++++++++++++++++++++++++++" +
            //            $"\n{item.CountItem}" +
            //            "\n++++++++++++++++++++++++++++++++++++++" +
            //            $"\n{item.ID}\n\n");
            //        }
            //    }
            //}
            //if (category == Category.Others)
            //{
            //    foreach (var item in others)
            //    {
            //        if (item.ID == id)
            //        {
            //            Console.WriteLine("Products Detected: ");
            //            Console.WriteLine("++++++++++++++++++++++++++++++++++++++" +
            //            $"\n{item.ItemName}" +
            //            "\n++++++++++++++++++++++++++++++++++++++" +
            //            $"\n{item.Price}$" +
            //            "\n++++++++++++++++++++++++++++++++++++++" +
            //            $"\n{item.CountItem}" +
            //            "\n++++++++++++++++++++++++++++++++++++++" +
            //            $"\n{item.ID}\n\n");
            //        }
            //    }
            //}
        }
        public List<Product> ShowProducts()
        {
            Console.Clear();
            foreach (var item in products)
            {
                if (item != null)
                {
                    Console.WriteLine("++++++++++++++++++++++++++++++++++++++" +
                        $"\nProduct Id: {item.ID}" +
                        "\n++++++++++++++++++++++++++++++++++++++" +
                        $"\nProduct Name: {item.ItemName}" +
                        "\n++++++++++++++++++++++++++++++++++++++" +
                        $"\nCategory: {item.Category}" +
                        "\n++++++++++++++++++++++++++++++++++++++" +
                        $"\nProduct Left: {item.CountItem}" +
                        "\n++++++++++++++++++++++++++++++++++++++" +
                        $"\nPrice: {item.Price}\n\n");
                }
            }
            return products;
        }
        public void GetProductForGivenCategory(Category category, string id, string name, int count, double price)
        {
            throw new NotImplementedException();
        }
        public void GetProductForGivenName(string id, string name, Category category, int count, double price)
        {
            throw new NotImplementedException();
        }
        public void GetProductForGivenPrice(double lowPrice, double highPrice, string id, string name, Category category, int count, double price)
        {
            throw new NotImplementedException();
        }
        public void ReturnProduct(string itemName, int count)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Sales
        public void GetAllSales(string no, double amount, int count, DateTime date)
        {
            throw new NotImplementedException();
        }
        public void GetSalesForGivenDates(string no, double amount, int count, DateTime date, DateTime date1)
        {
            throw new NotImplementedException();
        }
        public void GetSalesForGivenDates(DateTime oldDate, DateTime newdate, DateTime date, string no, double amount, int count)
        {
            throw new NotImplementedException();
        }
        public void GetSalesForGivenNumber(string no, double amount, int count, DateTime date)
        {
            throw new NotImplementedException();
        }
        public void GetSalesForGivenPrice(double lowPrice, double highPrice, string no, double amount, int count, DateTime date)
        {
            throw new NotImplementedException();
        }
        public void ItemSales(string id, int count)
        {
            throw new NotImplementedException();
        }
        public void Sales(string no, double amount, SalesItem salesItem, DateTime date)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
