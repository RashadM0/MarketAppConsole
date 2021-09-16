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
        private static int _id = 1;
        public string ItemName;
        public double Price;
        public Category Category;
        public int CountItem;
        public int ID { get; set; }
        //public static List<Product> products;
        
        public Product(string itemName, double price, Category category, int countItem)
        {
            ItemName = itemName;
            Price = price;
            Category = category;
            CountItem = countItem;
            ID = ++_id;
        }
        Marketable marketable = new Marketable();
        //public static Product AddItem()
        //{
        //    Category category = new Category();
        //    Console.Clear();
        //    Console.Write("Please Enter Product Name: ");
        //    string itemName = Convert.ToString(Console.ReadLine().Trim());
        //    double price;
        //    Console.Write("---------------------------------\nPrice: ");
        //ChoiseAgain:
        //    bool isNumber = double.TryParse(Console.ReadLine(), out price);
        //    if (!isNumber)
        //    {
        //        Console.Write(
        //            "\n" +
        //            "Please Enter the Price Correctly: ");
        //        goto ChoiseAgain;
        //    }
        //    if (price <= 0)
        //    {
        //        Console.Write(
        //            "\n" +
        //            "Please Enter the Price Correctly: ");
        //        goto ChoiseAgain;
        //    }
        //    int countItem;
        //    Console.Write("---------------------------------\nHow Many Pieces: ");
        //CountAgain:
        //    bool isNumber1 = int.TryParse(Console.ReadLine(), out countItem);
        //    if (!isNumber1)
        //    {
        //        Console.Write(
        //            "\n" +
        //            "Wrong Choise. Try Again: ");
        //        goto CountAgain;
        //    }
        //    if (countItem <= 0)
        //    {
        //        Console.Write(
        //            "\n" +
        //            "Wrong Choise. Try Again: ");
        //        goto CountAgain;
        //    }
        //    else
        //    {
        //        Console.Clear();
        //        Console.WriteLine("\n--------Item Added--------\n");
        //        Console.WriteLine("++++++++++++++++++++++++++++++++++++++" +
        //        $"\nItem Name: {itemName}" +
        //        "\n++++++++++++++++++++++++++++++++++++++" +
        //        $"\nPrice: {price}" +
        //        "\n++++++++++++++++++++++++++++++++++++++" +
        //        $"\nItem Left: {countItem}" +
        //        "\n++++++++++++++++++++++++++++++++++++++" +
        //        $"\nID: {_id}\n\n");
        //    }
        //    Product product = new Product(itemName, price, category, countItem);
        //    return product;
        //}
    }
}
