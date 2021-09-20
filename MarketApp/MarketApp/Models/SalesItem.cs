using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApp.Models
{
    class SalesItem
    {
        private static int _no = 0;
        public int No;
        public Product Product;
        public int Count { get; set; }

        public SalesItem(Product product, int count)
        {
            Product = product;
            Count = count;
            No = ++_no;
        }
    }
    }

