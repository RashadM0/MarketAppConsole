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
        #region Products
        public void  AddProducts(string itemName, double price, Category category, int countItem, int id)
        {
            Product product = new Product(itemName, price, category, countItem, id);
            //AddProducts(itemName, price, category, countItem, id
            List<Product> foods = new List<Product>();
            foods.Add(product);
            Console.WriteLine("--------Item Added--------");

        //    Console.Clear();
        //    Console.Write("Please Enter Product Name");
        //    string productName = Convert.ToString(Console.ReadLine().Trim());
        //    double itemPrice;
        //ChoiseAgain:
        //    bool isNumber = double.TryParse(Console.ReadLine(), out itemPrice);
        //    if (!isNumber && itemPrice <= 0)
        //    {
        //        Console.Write(
        //            "\n" +
        //            "Please Enter the Price Correctly: ");
        //        goto ChoiseAgain;
        //    }
        //    //if (itemPrice <= 0)
        //    //{
        //    //    Console.Write(
        //    //        "\n" +
        //    //        "Please Enter the Price Correctly: ");
        //    //    goto ChoiseAgain;
        //    //}


        }
        public void EditProducts(string name, int count, double amount, Category category, string id)
        {
            throw new NotImplementedException();
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
        public void Products(string itemName, double price, Category category, int countItem, string id)
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
