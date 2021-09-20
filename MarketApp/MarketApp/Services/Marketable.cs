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
        public List<Product> basket = new List<Product>();
        #region Products
        public void ItemList()
        {
            products.Add(new Product("Lay's", 1.5, Category.Food, 20));
            products.Add(new Product("Snickers", 0.60, Category.Food, 20));
            products.Add(new Product("Toblerone", 2.60, Category.Food, 20));
            products.Add(new Product("Sausage", 3.25, Category.Food, 20));
            products.Add(new Product("Meat", 6.10, Category.Food, 20));
            products.Add(new Product("Haribo", 1.25, Category.Food, 20));
            products.Add(new Product("Coca-Cola", 1, Category.Drinkable, 20));
            products.Add(new Product("Tea", 2.30, Category.Drinkable, 20));
            products.Add(new Product("Jack Daniel's", 30, Category.Drinkable, 10));
            products.Add(new Product("Absolute", 35, Category.Drinkable, 10));
            products.Add(new Product("Chivas Regal", 40, Category.Drinkable, 10));
            products.Add(new Product("Chivas", 40, Category.Drinkable, 10));
            products.Add(new Product("Sierra Tequilla", 40, Category.Drinkable, 10));
            products.Add(new Product("Sierra Tequilla", 40, Category.Drinkable, 10));
            products.Add(new Product("Camel", 8.50, Category.Cigarettes, 30));
            products.Add(new Product("Marlboro", 11, Category.Cigarettes, 30));
            products.Add(new Product("Parliament", 11, Category.Cigarettes, 30));
            products.Add(new Product("Winston", 2.50, Category.Cigarettes, 30));
            products.Add(new Product("American Spirit", 10, Category.Cigarettes, 30));
            products.Add(new Product("Toilet Paper", 1.50, Category.Others, 30));
            products.Add(new Product("Soap", 0.60, Category.Others, 30));
            products.Add(new Product("Tooth Paste", 1.90, Category.Others, 30));
            products.Add(new Product("Mug", 14, Category.Others, 30));
            products.Add(new Product("Mask", 0.10, Category.Others, 30));
        }
        public void AddProducts(Product product)
        {
            products.Add(product);
        }
        public void DeleteProduct(Product product)
        {
            products.Remove(product);
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
        public void GetProductForGivenCategory(Product product)
        {

        }
        public void GetProductForGivenName(string id, string name, Category category, int count, double price)
        {

        }
        public void GetProductForGivenPrice(double lowPrice, double highPrice, string id, string name, Category category, int count, double price)
        {

        }
        #endregion
        #region Sales
        public void ReturnProduct(string itemName, int count)
        {
            throw new NotImplementedException();
        }
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
