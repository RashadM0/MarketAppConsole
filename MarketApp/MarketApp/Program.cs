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
                        OperationsOnProduct(ref marketable);
                        goto TryAgain;
                    case "2":
                        SalesOperations();
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
                        goto MainChoise;
                    case "2":
                        EditProduct(marketable);
                        Console.WriteLine("Press Any Key for Continue");
                        Console.ReadLine();
                        break;
                    case "3":
                        //delete
                        break;
                    case "4":
                        ShowProducts(marketable);
                        Console.WriteLine("Press Any Key for Continue");
                        Console.ReadLine();
                        goto MainChoise;
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
            Console.Clear();
            Console.WriteLine("\n--------Item Added--------\n");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++" +
            $"\nItem Name: {itemName}" +
            "\n++++++++++++++++++++++++++++++++++++++" +
            $"\nPrice: {price}" +
            "\n++++++++++++++++++++++++++++++++++++++" +
            $"\nItem Left: {countItem}" +
            "\n++++++++++++++++++++++++++++++++++++++" +
            $"\nID: {product.ID}\n\n");
        }
        static void EditProduct(Marketable marketable)
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
            switch (category)
            {
                case Category.Food:
                    if (typestr == Category.Food.ToString())
                    {
                        EditItem(category);
                    }
                    //EditItem(category);
                    Console.WriteLine("Press Any Key For Continue");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case Category.Drinkable:
                    EditItem(category);
                    Console.WriteLine("Press Any Key For Continue");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case Category.Cigarettes:
                    EditItem(category);
                    Console.WriteLine("Press Any Key For Continue");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case Category.Others:
                    EditItem(category);
                    Console.WriteLine("Press Any Key For Continue");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                default:
                    break;
            }
            //Console.Clear();
            //Console.WriteLine("---------------------------------\nSelect a Category\n");
            //Console.WriteLine("=================" +
            //    "\n1: Food" +
            //    "\n=================" +
            //    "\n2: Drinkable" +
            //    "\n=================" +
            //    "\n3: Cigarettes" +
            //    "\n================" +
            //    "\n4: Others" +
            //    "\n=================");
            //Console.Write("\n" +
            //    "\n--------------------------------------" +
            //    "\nYour choise: ");
            //string choise = Console.ReadLine().Trim();
            //switch (choise)
            //{
            //    case "1":

            //        break;
            //    default:
            //        break;
            //}


            //Console.Write("Enter Item ID");
            //int id;
            //ChoiseAgain:
            //bool isNumber = int.TryParse(Console.ReadLine(), out id);
            //if (!isNumber)
            //{
            //    Console.Write(
            //        "\n" +
            //        "Invalid ID. Please Try Again: ");
            //    goto ChoiseAgain;
            //}
            //if (id <= 0)
            //{
            //    Console.Write(
            //        "\n" +
            //        "Invalid ID. Please Try Again: ");
            //    goto ChoiseAgain;
            //}
        }
        //static void AddItem(/*Product product, */Marketable marketable)
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
        //    Product product = new Product(itemName, price, category, countItem);
        //    marketable.products.Add(product);
        //   // Console.WriteLine(marketable.products.Count);
        //    //marketable.products.Add(product);
        //    //marketable.AddProducts(product);
        //    //Console.Clear();
        //    Console.WriteLine("\n--------Item Added--------\n");
        //    Console.WriteLine(marketable.products.Count);
        //    Console.WriteLine("++++++++++++++++++++++++++++++++++++++" +
        //    $"\nItem Name: {itemName}" +
        //    "\n++++++++++++++++++++++++++++++++++++++" +
        //    $"\nPrice: {price}" +
        //    "\n++++++++++++++++++++++++++++++++++++++" +
        //    $"\nItem Left: {countItem}" +
        //    "\n++++++++++++++++++++++++++++++++++++++" +
        //    $"\nID: {product.ID}\n\n");
        //}
        static void EditItem(Category category)
        {
            //Category category = new Category();
            Marketable marketable = new Marketable();
            Console.Write("---------------------------------\nEnter Item ID: ");
            int id;
        ChoiseAgain:
            bool isNumber = int.TryParse(Console.ReadLine(), out id);
            if (!isNumber)
            {
                Console.Write(
                    "\n" +
                    "Invalid ID. Please Try Again: ");
                goto ChoiseAgain;
            }
            else if (id <= 0)
            {
                Console.Write(
                    "\n" +
                    "Invalid ID. Please Try Again: ");
                goto ChoiseAgain;
            }
            else
            {
                //if (category == Category.Food)
                //{
                foreach (var item in marketable.products)
                {
                    if (item.ID == id)
                    {
                        Console.WriteLine("Food Detected: ");
                        Console.WriteLine("++++++++++++++++++++++++++++++++++++++" +
                        $"\n{item.ItemName}" +
                        "\n++++++++++++++++++++++++++++++++++++++" +
                        $"\n{item.Price}$" +
                        "\n++++++++++++++++++++++++++++++++++++++" +
                        $"\n{item.CountItem}" +
                        "\n++++++++++++++++++++++++++++++++++++++" +
                        $"\n{item.ID}\n\n");
                    }
                    else
                    {
                        Console.Write("There is no Product. Please Try Again: ");
                        goto ChoiseAgain;
                    }
                    break;
                }
                //}
                //    if (category == Category.Drinkable)
                //    {
                //        foreach (var item in marketable.drinkable)
                //        {
                //            if (item.ID == id)
                //            {
                //                Console.WriteLine("Drinks Detected: ");
                //                Console.WriteLine("++++++++++++++++++++++++++++++++++++++" +
                //                $"\n{item.ItemName}" +
                //                "\n++++++++++++++++++++++++++++++++++++++" +
                //                $"\n{item.Price}$" +
                //                "\n++++++++++++++++++++++++++++++++++++++" +
                //                $"\n{item.CountItem}" +
                //                "\n++++++++++++++++++++++++++++++++++++++" +
                //                $"\n{item.ID}\n\n");
                //            }
                //            else
                //            {
                //                Console.Write("There is no Product. Please Try Again: ");
                //                goto ChoiseAgain;
                //            }
                //            break;
                //        }
                //    }
                //    if (category == Category.Cigarettes)
                //    {
                //        foreach (var item in marketable.cigarettes)
                //        {
                //            if (item.ID == id)
                //            {
                //                Console.WriteLine("Smokes Detected: ");
                //                Console.WriteLine("++++++++++++++++++++++++++++++++++++++" +
                //                $"\n{item.ItemName}" +
                //                "\n++++++++++++++++++++++++++++++++++++++" +
                //                $"\n{item.Price}$" +
                //                "\n++++++++++++++++++++++++++++++++++++++" +
                //                $"\n{item.CountItem}" +
                //                "\n++++++++++++++++++++++++++++++++++++++" +
                //                $"\n{item.ID}\n\n");
                //            }
                //            else
                //            {
                //                Console.Write("There is no Product. Please Try Again: ");
                //                goto ChoiseAgain;
                //            }
                //            break;
                //        }
                //    }
                //    if (category == Category.Others)
                //    {
                //        foreach (var item in marketable.others)
                //        {
                //            if (item.ID == id)
                //            {
                //                Console.WriteLine("Products Detected: ");
                //                Console.WriteLine("++++++++++++++++++++++++++++++++++++++" +
                //                $"\n{item.ItemName}" +
                //                "\n++++++++++++++++++++++++++++++++++++++" +
                //                $"\n{item.Price}$" +
                //                "\n++++++++++++++++++++++++++++++++++++++" +
                //                $"\n{item.CountItem}" +
                //                "\n++++++++++++++++++++++++++++++++++++++" +
                //                $"\n{item.ID}\n\n");
                //            }
                //            else
                //            {
                //                Console.Write("There is no Product. Please Try Again: ");
                //                goto ChoiseAgain;
                //            }
                //            break;
                //        }
                //    }
            }
        }
        static void ShowProducts(Marketable marketable)
        {
            Console.Clear();
            foreach (var item in marketable.products)
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
    }
}
