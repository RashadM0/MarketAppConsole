using System;
using MarketApp.Models;
using MarketApp.Services;
using MarketApp.Interfaces;
using MarketApp.Enums;

namespace MarketApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Marketable marketable = new Marketable();
            TryAgain:
            #region Welcoming
            Console.WriteLine(@"
                ██     ██ ███████ ██       ██████  ██████  ███    ███ ███████ 
                ██     ██ ██      ██      ██      ██    ██ ████  ████ ██      
                ██  █  ██ █████   ██      ██      ██    ██ ██ ████ ██ █████   
                ██ ███ ██ ██      ██      ██      ██    ██ ██  ██  ██ ██      
                 ███ ███  ███████ ███████  ██████  ██████  ██      ██ ███████ 
                                                             ");
            Console.WriteLine("\t******************************************************************************");
            #endregion
            #region MainMenu
            Console.WriteLine("=================================================" +
                "\nPress '1' For Carry out Operations on Products" +
                "\n=================================================" +
                "\nPress '2' For Carry out Sales Operations" +
                "\n=================================================" +
                "\nPress '0' For Exit" +
                "\n=================================================");
            Console.Write("\n" +
                "\n--------------------------------------" +
                "\nYour choise: ");
            #endregion
            bool isDigit = false;
            ChoiseAgain:
            string choise = Console.ReadLine().Trim();
            foreach (var item in choise)
            {
                if (char.IsDigit(item) == true)
                    isDigit = true;
                else
                {
                    Console.Write("Please Enter Proper Value: ");
                    goto ChoiseAgain;
                }
                switch (choise)
                {
                    case "1":
                        OperationsOnProduct();
                        goto TryAgain;
                    case "2":
                        SalesOperations();
                        goto TryAgain;
                    case "0":
                        Console.WriteLine("Thank you for using our application :)");
                        Console.WriteLine(DateTime.Now);
                        Console.ReadLine();
                        break;
                        goto TryAgain;
                    default:
                        break;
                }
            }
        }
        #region MainMethods
        public static void OperationsOnProduct()
        {
            Marketable marketable = new Marketable();
            Console.Clear();
            Console.WriteLine("=================================================" +
                "\nPress '1' For Add New Product" +
                "\n=================================================" +
                "\nPress '2' For Make Change on Products" +
                "\n=================================================" +
                "\nPress '3' For Delete Product" +
                "\n=================================================" +
                "\nPress '4' For Show All Products" +
                "\n=================================================" +
                "\nPress '5' For Show All Categories and Products" +
                "\n=================================================" +
                "\nPress '6' For Show All Products by Price Range" +
                "\n=================================================" +
                "\nPress '7' For Show All Products by Name" +
                "\n=================================================" +
                "\nPress '0' For Back to Menu" +
                "\n=====================================================");
            Console.Write("\n" +
                "\n--------------------------------------" +
                "\nYour choise: ");
            bool isDigit = false;
            choiseAgain:
            string choise = Console.ReadLine().Trim();
            foreach (var item in choise)
            {
                if (char.IsDigit(item) == true)
                    isDigit = true;
                else
                {
                    Console.WriteLine("Please Enter Proper Value");
                    goto choiseAgain;
                }
                switch (choise)
                {
                    case "1":
                        AddProducts(ref marketable);
                        break;
                    default:
                        break;
                }
            }
        }
        public static void SalesOperations()
        {
            Console.Clear();
            Console.WriteLine("=====================================================" +
                "\nPress '1' For Add New Sale Operation" +
                "\n=====================================================" +
                "\nPress '2' For Return Product from Sale Operation" +
                "\n=====================================================" +
                "\nPress '3' For Delete Sale Operation" +
                "\n=====================================================" +
                "\nPress '4' For Show All Sale Operations" +
                "\n=====================================================" +
                "\nPress '5' For Show All Sale Operations by Date Range" +
                "\n=====================================================" +
                "\nPress '6' For Show All Sale Operations by Price Range" +
                "\n================================================+====" +
                "\nPress '7' For Show All Sale Operations by Given Date" +
                "\n=====================================================" +
                "\nPress '0' For Back to Menu" +
                "\n=====================================================");
            Console.Write("\n" +
                "\n--------------------------------------" +
                "\nYour choise: ");
            string choise = Console.ReadLine().Trim();
        }
        #endregion
        static void AddProducts(ref Marketable marketable)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------\nSelect a Category\n");
            Console.WriteLine("=================" +
                "\n1: Food" +
                "\n=================" +
                "\n2: Drinkable" +
                "\n=================" +
                "\n3: Cigarettes" +
                "\n================" +
                "\n4: Others" +
                "\n=================");
            Console.Write("\n" +
                "\n--------------------------------------" +
                "\nYour choise: ");
            //string[] category = Enum.GetNames(typeof(Category));
            //for (int i = 0; i < category.Length; i++)
            //{
            //    Console.WriteLine($"{i+1}: {category[i]}");
            //}
            bool isDigit = false;
        choiseAgain:
            string choise = Console.ReadLine().Trim();
            foreach (var item in choise)
            {
                if (char.IsDigit(item) == true)
                {
                    isDigit = true;
                }
                else
                {
                    Console.WriteLine("Please Enter Proper Value");
                    goto choiseAgain;
                }
                switch (choise)
                {
                    case "1":
                        AddItem();
                        Console.Write("Press Any Key For Continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    default:
                        break;
                }
            }
        }
        static void AddItem()
        {
            Console.Clear();
            Console.Write("Please Enter Product Name: ");
            string itemName = Convert.ToString(Console.ReadLine().Trim());
            double price;
            Console.Write("---------------------------------\nPrice: ");
        ChoiseAgain:
            bool isNumber = double.TryParse(Console.ReadLine(), out price);
            if (!isNumber)
            {
                Console.Write(
                    "\n" +
                    "Please Enter the Price Correctly: ");
                goto ChoiseAgain;
            }
            if (price <= 0)
            {
                Console.Write(
                    "\n" +
                    "Please Enter the Price Correctly: ");
                goto ChoiseAgain;
            }
            int countItem;
            Console.Write("---------------------------------\nHow Many Pieces: ");
        CountAgain:
            bool isNumber1 = int.TryParse(Console.ReadLine(), out countItem);
            if (!isNumber1)
            {
                Console.Write(
                    "\n" +
                    "Wrong Choise. Try Again: ");
                goto CountAgain;
            }
            if (countItem <= 0)
            {
                Console.Write(
                    "\n" +
                    "Wrong Choise. Try Again: ");
                goto CountAgain;
            }
            int id;
            Console.Write("---------------------------------\nID: ");
        IDAgain:
            bool isNumber2 = int.TryParse(Console.ReadLine(), out id);
            if (!isNumber2)
            {
                Console.Write(
                    "\n" +
                    "ID Must be a Number: ");
                goto IDAgain;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\n--------Item Added--------\n");
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++" +
                $"\nItem Name: {itemName}" +
                "\n++++++++++++++++++++++++++++++++++++++" +
                $"\nPrice: {price}" +
                "\n++++++++++++++++++++++++++++++++++++++" +
                $"\nItem Left: {countItem}" +
                "\n++++++++++++++++++++++++++++++++++++++" +
                $"\nID: {id}\n\n");
            }  
        }
    }
}
