using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApp.Models
{
    class Sales
    {
        int No;
        double Amount;
        SalesItem SalesItem;
        DateTime Date;

        public Sales(int no, double amount, SalesItem salesItem, DateTime date)
        {
            No = no;
            Amount = amount;
            SalesItem = salesItem;
            Date = date;
        }
    }
}
