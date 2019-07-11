using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Model
{
    public class Product
    {    
        public Product(int id, decimal unitPrice)
        {
            Id = id;
            UnitPrice = unitPrice;
        }
        public string Name { get; set; }
        public int Id { get; }
        public decimal UnitPrice { get; }
    }
}
