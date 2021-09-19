using System;
using MarketApp.Models;
using MarketApp.Services;
using MarketApp.Interfaces;
using MarketApp.Enums;
using System.Linq;
using System.Collections.Generic;

namespace MarketApp
{
    class Program
    {
        #region Back
        static void MenuMethod()
        {
        }
        #endregion
        static void Main(string[] args)
        {
            Marketable marketable = new Marketable();
            marketable.ItemList();
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
                        OperationsOnProduct(ref marketable);
                        goto TryAgain;
                    case "2":
                        SalesOperations(ref marketable);
                        goto TryAgain;
                    case "0":
                        Console.WriteLine("Thank you for using our application :)");
                        Console.WriteLine(DateTime.Now);
                        Console.ReadLine();
                        break;
                    default:
                        break;
                }
            }
        }
        static void FoundItemById(Marketable marketable)
        {
            int id;
            Console.Write("Please Enter Product ID: ");
        TryAgain:
            bool isNumber = int.TryParse(Console.ReadLine(), out id);
            if (!isNumber)
            {
                Console.Write(
                    "\n" +
                    "Wrong Choise. Try Again: ");
                goto TryAgain;
            }
            if (id <= 0)
            {
                Console.Write(
                    "\n" +
                    "Wrong Choise. Try Again: ");
                goto TryAgain;
            }
            foreach (var item in marketable.products)
            {
                if (marketable.products.Find(product => product.ID == id) == null)
                {
                    Console.Write("ID Not Found. Try again: ");
                    goto TryAgain;
                }
                Product product = marketable.products.Find(product => product.ID == id);
                Console.Clear();
                Console.WriteLine("\n--------Item Detected--------\n");
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++" +
                $"\nItem Name: {product.ItemName}" +
                "\n++++++++++++++++++++++++++++++++++++++" +
                $"\nPrice: {product.Price + "$"}" +
                "\n++++++++++++++++++++++++++++++++++++++" +
                $"\nCategory: {product.Category}" +
                "\n++++++++++++++++++++++++++++++++++++++" +
                $"\nItem Left: {product.CountItem}" +
                "\n++++++++++++++++++++++++++++++++++++++" +
                $"\nID: {product.ID}\n\n");
            }
        }
        static void SelectCategory(Marketable marketable)
        {
            Console.Clear();
            List<Product> basket = new List<Product>();
            string[] categoryType = Enum.GetNames(typeof(Category));
            for (int i = 0; i < categoryType.Length; i++)
            {
                Console.WriteLine($"=================\n{i + 1}: {categoryType[i]}");
            }
            string typestr;
            int typeint;
            Console.Write("---------------------------------\nSelect a Category: ");
            typestr = Console.ReadLine();
            while (!int.TryParse(typestr, out typeint) || typeint < 1 || typeint > categoryType.Length)
            {
                Console.Write("Please Try Again: ");
                typestr = Console.ReadLine();
            }
            Category category = (Category)typeint;
            List<Product> product = marketable.products.FindAll(product => product.Category == (Category)typeint);
            foreach (var item in product)
            {
                Console.WriteLine($"\n++++++++++++++++++++++++" +
                $"\nID: {item.ID}" +
                $"\nItem Name: {item.ItemName}" +
                $"\nPrice: {item.Price}$" +
                $"\nCategory: {item.Category}" +
                $"\nItem Left: {item.CountItem}" +
                $"\n++++++++++++++++++++++++\n");
            }
        }
        #region MainMethods
        public static void OperationsOnProduct(ref Marketable marketable)
        {
        MainChoise:
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
                        AddProducts(marketable);
                        Console.WriteLine("Press Any Key for Continue");
                        Console.ReadLine();
                        Console.Clear();
                        goto MainChoise;
                    case "2":
                        EditProduct(marketable);
                        Console.WriteLine("Press Any Key for Continue");
                        Console.ReadLine();
                        Console.Clear();
                        goto MainChoise;
                    case "3":
                        DeleteProduct(marketable);
                        Console.WriteLine("Press Any Key for Continue");
                        Console.ReadLine();
                        Console.Clear();
                        goto MainChoise;
                    case "4":
                        ShowProducts(marketable);
                        Console.WriteLine("Press Any Key for Continue");
                        Console.ReadLine();
                        Console.Clear();
                        goto MainChoise;
                    case "5":
                        ShowProductsByCategories(marketable);
                        Console.WriteLine("Press Any Key for Continue");
                        Console.ReadLine();
                        Console.Clear();
                        goto MainChoise;
                    case "6":
                        ShowProductsByPriceRange(marketable);
                        Console.WriteLine("Press Any Key for Continue");
                        Console.ReadLine();
                        Console.Clear();
                        goto MainChoise;
                    case "7":
                        ShowProductsByName(marketable);
                        Console.WriteLine("Press Any Key for Continue");
                        Console.ReadLine();
                        Console.Clear();
                        goto MainChoise;
                    case "0":
                        MenuMethod();
                        Console.Clear();
                        break;
                    default:
                        break;
                }
            }
        }
        public static void SalesOperations(ref Marketable marketable)
        {
        MainChoise:
            Console.Clear();
            Console.WriteLine("=====================================================" +
                "\nPress '1' For Sell Product" +
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
                        AddSale(marketable);
                        Console.WriteLine("Press Any Key for Continue");
                        Console.ReadLine();
                        Console.Clear();
                        goto MainChoise;
                    case "2":
                    //return
                    case "3":
                    //delete
                    case "4":
                    //showall
                    case "5":
                    //daterange
                    case "6":
                    //pricerange
                    case "7":
                    //givendate
                    case "0":
                        MenuMethod();
                        Console.Clear();
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion
        #region ProductMethods
        static void AddProducts(Marketable marketable)
        {
            Console.Clear();
            string[] categoryType = Enum.GetNames(typeof(Category));
            for (int i = 0; i < categoryType.Length; i++)
            {
                Console.WriteLine($"=================\n{i + 1}: {categoryType[i]}");
            }
            string typestr;
            int typeint;
            Console.Write("---------------------------------\nSelect a Category: ");
            typestr = Console.ReadLine();
            while (!int.TryParse(typestr, out typeint) || typeint < 1 || typeint > categoryType.Length)
            {
                Console.Write("Please Try Again: ");
                typestr = Console.ReadLine();
            }
            Category category = (Category)typeint;
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
            Product product = new Product(itemName, price, category, countItem);
            marketable.products.Add(product);
            int id = product.ID;
            Console.Clear();
            Console.WriteLine("\n--------Item Added--------\n");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++" +
            $"\nItem Name: {itemName}" +
            "\n++++++++++++++++++++++++++++++++++++++" +
            $"\nPrice: {price + "$"}" +
            "\n++++++++++++++++++++++++++++++++++++++" +
            $"\nItem Left: {countItem}" +
            "\n++++++++++++++++++++++++++++++++++++++" +
            $"\nID: {id}\n\n");
        }
        static void EditProduct(Marketable marketable)
        {
            Console.Clear();
            SelectCategory(marketable);
            int id;
            Console.Write("Please Enter Product ID: ");
        TryAgain:
            bool isNumber = int.TryParse(Console.ReadLine(), out id);
            if (!isNumber)
            {
                Console.Write(
                    "\n" +
                    "Wrong Choise. Try Again: ");
                goto TryAgain;
            }
            if (id <= 0)
            {
                Console.Write(
                    "\n" +
                    "Wrong Choise. Try Again: ");
                goto TryAgain;
            }
            foreach (var item in marketable.products)
            {
                if (marketable.products.Find(product => product.ID == id) == null)
                {
                    Console.Write("ID Not Found. Try again: ");
                    goto TryAgain;
                }
                Product product = marketable.products.Find(product => product.ID == id);
                Console.Clear();
                Console.WriteLine("\n--------Item Detected--------\n");
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++" +
                $"\nItem Name: {product.ItemName}" +
                "\n++++++++++++++++++++++++++++++++++++++" +
                $"\nPrice: {product.Price + "$"}" +
                "\n++++++++++++++++++++++++++++++++++++++" +
                $"\nCategory: {product.Category}" +
                "\n++++++++++++++++++++++++++++++++++++++" +
                $"\nItem Left: {product.CountItem}" +
                "\n++++++++++++++++++++++++++++++++++++++" +
                $"\nID: {product.ID}\n\n");
                Console.Write("***************************************\nEnter New Item Name: ");
                string newName = Console.ReadLine().Trim();
                Console.Write("---------------------------------\nNew Price: ");
                double newPrice;
            PriceAgain:
                bool isNumber1 = double.TryParse(Console.ReadLine(), out newPrice);
                if (!isNumber1)
                {
                    Console.Write(
                        "\n" +
                        "Please Enter the Price Correctly: ");
                    goto PriceAgain;
                }
                if (newPrice <= 0)
                {
                    Console.Write(
                        "\n" +
                        "Please Enter the Price Correctly: ");
                    goto PriceAgain;
                }
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
                Category category = (Category)typeint;
                int newCount;
                Console.Write("---------------------------------\nHow Many Pieces: ");
            CountAgain:
                bool isNumber2 = int.TryParse(Console.ReadLine(), out newCount);
                if (!isNumber2)
                {
                    Console.Write(
                        "\n" +
                        "Wrong Choise. Try Again: ");
                    goto CountAgain;
                }
                if (newCount <= 0)
                {
                    Console.Write(
                        "\n" +
                        "Wrong Choise. Try Again: ");
                    goto CountAgain;
                }
                product.ItemName = newName;
                product.Price = newPrice;
                product.CountItem = newCount;
                product.Category = (Category)typeint;

                Console.WriteLine("\n--------Item Edited--------\n");
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++" +
                    $"\nItem Name: {product.ItemName}" +
                    "\n++++++++++++++++++++++++++++++++++++++" +
                    $"\nPrice: {product.Price + "$"}" +
                    "\n++++++++++++++++++++++++++++++++++++++" +
                    $"\nCategory: {product.Category}" +
                    "\n++++++++++++++++++++++++++++++++++++++" +
                    $"\nItem Left: {product.CountItem}" +
                    "\n++++++++++++++++++++++++++++++++++++++" +
                    $"\nID: {product.ID}\n\n");
                break;
            }
        }
        static void DeleteProduct(Marketable marketable)
        {
            Console.Clear();
            SelectCategory(marketable);
            int id;
            Console.Write("Please Enter Product ID: ");
        TryAgain:
            bool isNumber = int.TryParse(Console.ReadLine(), out id);
            if (!isNumber)
            {
                Console.Write(
                    "\n" +
                    "Wrong Choise. Try Again: ");
                goto TryAgain;
            }
            if (id <= 0)
            {
                Console.Write(
                    "\n" +
                    "Wrong Choise. Try Again: ");
                goto TryAgain;
            }
            Product product = marketable.products.Find(product => product.ID == id);
            if (product == null)
            {
                Console.Write("ID Not Found. Try Again: ");
                goto TryAgain;
            }
            Console.WriteLine("\n--------Item Detected--------\n");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++" +
            $"\nItem Name: {product.ItemName}" +
            "\n++++++++++++++++++++++++++++++++++++++" +
            $"\nPrice: {product.Price + "$"}" +
            "\n++++++++++++++++++++++++++++++++++++++" +
            $"\nCategory: {product.Category}" +
            "\n++++++++++++++++++++++++++++++++++++++" +
            $"\nItem Left: {product.CountItem}" +
            "\n++++++++++++++++++++++++++++++++++++++" +
            $"\nID: {product.ID}\n\n");
            Console.Write("Enter Count of item That You Want to Delete: ");
            int countItem;
        CountAgain:
            bool isDigit = int.TryParse(Console.ReadLine(), out countItem);
            if (!isDigit)
            {
                Console.Write(
                    "\n" +
                    "Wrong Choise. Try Again: ");
                goto CountAgain;
            }
            if (countItem <= 0)
            {
                Console.WriteLine("Count Must be More than '0'");
                goto CountAgain;
            }
            if (countItem > product.CountItem)
            {
                Console.Write($"Only {product.CountItem} Left. Please Add Less: ");
                goto CountAgain;
            }
            else if (countItem == product.CountItem)
            {
                Console.Write("Press any Key, If You Want Delete: ");
                Console.ReadLine();
                marketable.products.Remove(marketable.products.Find(product => product.ID == id));
                Console.WriteLine("\n--------Item Deleted--------\n");
                return;
            }
            else if (countItem < product.CountItem)
            {
                product.CountItem -= countItem;
                Console.Write("Press any Key, If You Want Delete: ");
                Console.ReadLine();
                //marketable.products.Remove(marketable.products.Find(product => product.ID == id));
                //marketable.products.Add(item);
                Console.Write($"{countItem} of Item is Deleted. ");
                return;
            }
        }
        static void ShowProducts(Marketable marketable)
        {
            Console.Clear();
            if (marketable.products.Count != 0)
            {
                foreach (var item in marketable.products)
                {
                    Console.WriteLine($"\n++++++++++++++++++++++++" +
                $"\nID: {item.ID}" +
                $"\nItem Name: {item.ItemName}" +
                $"\nPrice: {item.Price}$" +
                $"\nCategory: {item.Category}" +
                $"\nItem Left: {item.CountItem}" +
                $"\n++++++++++++++++++++++++\n");
                }
            }
            else
                Console.WriteLine("\n--------Item Not Found--------\n");
        }
        static void ShowProductsByCategories(Marketable marketable)
        {
            SelectCategory(marketable);
        }
        static void ShowProductsByPriceRange(Marketable marketable)
        {
            Console.Clear();
            Console.Write("Enter Start Price: ");
            double startPrice;
        ChoiseAgain:
            bool isNumber = double.TryParse(Console.ReadLine(), out startPrice);
            if (!isNumber)
            {
                Console.Write(
                    "\n" +
                    "Please Enter the Price Correctly: ");
                goto ChoiseAgain;
            }
            if (startPrice <= 0)
            {
                Console.Write(
                    "\n" +
                    "Please Enter the Price Correctly: ");
                goto ChoiseAgain;
            }
            double finalPrice;
            Console.Write("---------------------------------\nLast Price: ");
        ChoiseAgain1:
            bool isNumber1 = double.TryParse(Console.ReadLine(), out finalPrice);
            if (!isNumber1)
            {
                Console.Write(
                    "\n" +
                    "Please Enter the Price Correctly: ");
                goto ChoiseAgain1;
            }
            if (finalPrice <= startPrice)
            {
                Console.Write(
                    "\n" +
                    "Last Price Cannot Less Than Start Price. Try Again: ");
                goto ChoiseAgain1;
            }
            List<Product> product = marketable.products.FindAll(product => product.Price >= startPrice && product.Price <= finalPrice);
            foreach (var item in product)
            {
                foreach (var item1 in product)
                {
                    Console.WriteLine(item1.ToString());
                }
            }
        }
        static void ShowProductsByName(Marketable marketable)
        {
            Console.Clear();
            Console.Write("Enter Product Name: ");
            string name = Convert.ToString(Console.ReadLine().Trim().ToLower());
            List<Product> product = marketable.products.FindAll(product => product.ItemName.Trim().ToLower() == name);

            foreach (var item in product)
            {
                Console.WriteLine("\n--------Item Detected--------\n");
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++" +
                $"\nItem Name: {item.ItemName}" +
                "\n++++++++++++++++++++++++++++++++++++++" +
                $"\nPrice: {item.Price + "$"}" +
                "\n++++++++++++++++++++++++++++++++++++++" +
                $"\nCategory: {item.Category}" +
                "\n++++++++++++++++++++++++++++++++++++++" +
                $"\nItem Left: {item.CountItem}" +
                "\n++++++++++++++++++++++++++++++++++++++" +
                $"\nID: {item.ID}\n\n");
            }

        }
        #endregion
        #region SalesMethods
        static void AddSale(Marketable marketable)
        {
            double amount = 0;
            List<Product> basket = new List<Product>();
            SelectCategory(marketable);
            //FoundItemById(marketable);
            int id;
            Console.Write("Please Enter Product ID: ");
        TryAgain:
            bool isNumber = int.TryParse(Console.ReadLine(), out id);
            if (!isNumber)
            {
                Console.Write(
                    "\n" +
                    "Wrong Choise. Try Again: ");
                goto TryAgain;
            }
            if (id <= 0)
            {
                Console.Write(
                    "\n" +
                    "Wrong Choise. Try Again: ");
                goto TryAgain;
            }
            if (marketable.products.Find(product => product.ID == id) == null)
            {
                Console.Write("ID Not Found. Try again: ");
                goto TryAgain;
            }
            Product product = marketable.products.Find(product => product.ID == id);
            Console.Clear();
            Console.WriteLine("\n--------Item Detected--------\n");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++" +
            $"\nItem Name: {product.ItemName}" +
            "\n++++++++++++++++++++++++++++++++++++++" +
            $"\nPrice: {product.Price + "$"}" +
            "\n++++++++++++++++++++++++++++++++++++++" +
            $"\nCategory: {product.Category}" +
            "\n++++++++++++++++++++++++++++++++++++++" +
            $"\nItem Left: {product.CountItem}" +
            "\n++++++++++++++++++++++++++++++++++++++" +
            $"\nID: {product.ID}\n\n");
            Console.Write("Enter Count of item That You Want Add to Cart: ");
            int countItem;
        CountAgain:
            bool isDigit = int.TryParse(Console.ReadLine(), out countItem);
            if (!isDigit)
            {
                Console.Write(
                    "\n" +
                    "Wrong Choise. Try Again: ");
                goto CountAgain;
            }
            if (countItem <= 0)
            {
                Console.WriteLine("Count Must be More than '0'");
                goto CountAgain;
            }
            if (countItem > product.CountItem)
            {
                Console.Write($"Only {product.CountItem} Left. Please Add Less: ");
                goto CountAgain;
            }
            for (int i = 0; i < countItem; i++)
            {
                basket.Add(product);
            }
            if (product.CountItem == countItem)
            {
                marketable.products.Remove(product);
            }
            else
            {
                product.CountItem -= countItem;
            }
            foreach (Product item2 in basket)
            {
                amount += product.Price;
            }
            Console.WriteLine("=================================================");
            Console.WriteLine("Item Succesfully Added to Cart");
            Console.WriteLine($"Your Final Pay Is: {amount} $");
            Console.WriteLine(DateTime.Now);
        }
        #endregion
    }
}
