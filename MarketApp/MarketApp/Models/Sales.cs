using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApp.Models
{
    class Sales
    {
        public int No;
        public double Amount;
        public SalesItem SalesItem;
        public DateTime Date;

        public Sales(int no, double amount, SalesItem salesItem, DateTime date)
        {
            No = no;
            Amount = amount;
            SalesItem = salesItem;
            Date = date;
        }
    }
}
