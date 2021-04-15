using System;
using System.Collections.Generic;
using System.Text;

namespace P1_DOTNET.Models
{
    class Stock
    {
        public string Code { get; set; }
        public int Quantity { get; set; }

        public Stock(string code, int quantity)
        {
            this.Code = code;
            this.Quantity = quantity;
        }

        public void IncrementQuantity(int number)
        {
            this.Quantity = Quantity + number;
        }

    }

}
