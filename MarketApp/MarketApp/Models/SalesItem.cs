using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApp.Models
{
    class SalesItem
    {
        int No;
        Product Product;
        int Count;

        public SalesItem(int no, Product product, int count)
        {
            No = no;
            Product = product;
            Count = count;
        }
    }
}
