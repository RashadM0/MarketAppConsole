using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApp.Models
{
    class SalesItem
    {
        public int No;
        public Product Product;
        public int Count;

        public SalesItem(int no, Product product, int count)
        {
            No = no;
            Product = product;
            Count = count;
        }
    }
}
