using System;
using System.Collections.Generic;
using System.Text;
using MarketApp.Models;
using MarketApp.Enums;

namespace MarketApp.Interfaces
{
    interface IMarketable
    {
        #region Products
        void AddProducts(Product product);
        void EditProducts(string newName, int newCount, double price, Category category, Category newCategory, int id);
        void GetProductForGivenCategory(Product product);
        void GetProductForGivenPrice(double lowPrice, double highPrice, string id, string name, Category category, int count, double price);
        void GetProductForGivenName(string id, string name, Category category, int count, double price);
        List<Product> ShowProducts();
        #endregion
        #region Sales
        void Sales(string no, double amount, SalesItem salesItem, DateTime date);
        void ItemSales(string id, int count);
        void ReturnProduct(string itemName, int count);
        void GetAllSales(string no, double amount, int count, DateTime date);
        void GetSalesForGivenDates(string no, double amount, int count, DateTime date, DateTime date1);
        void GetSalesForGivenDates(DateTime oldDate, DateTime newdate, DateTime date, string no, double amount, int count);
        void GetSalesForGivenPrice(double lowPrice, double highPrice, string no, double amount, int count, DateTime date);
        void GetSalesForGivenNumber(string no, double amount, int count, DateTime date);
        #endregion
    }
}
