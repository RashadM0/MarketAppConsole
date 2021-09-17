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
        #region Products
        public void AddProducts(Product product)
        {
            products.Add(product);
        }
        public void EditProducts(string newName, int newCount, double price, Category category, Category newCategory, int id)
        {
            string[] categoryType = Enum.GetNames(typeof(Category));
            for (int i = 0; i < categoryType.Length; i++)
            {
                Console.WriteLine($"=================\n{i + 1}: {categoryType[i]}");
            }
            string typestr;
            int typeint;
            Console.Write("---------------------------------\nNew Category: ");
            typestr = Console.ReadLine();
            while (!int.TryParse(typestr, out typeint) || typeint < 1 || typeint > categoryType.Length)
            {
                Console.Write("Please Try Again: ");
                typestr = Console.ReadLine();
            }
            category = (Category)typeint;
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
