using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Model
{
    public class BasketItem
    {
        public Product Product { get; internal set; }
        public int Count { get; internal set; }
        public int DiscountedProductsCount { get; internal set; }
        public decimal DiscountRate { get; internal set; }
        public decimal TotalPrice { get; internal set; }
    }
}
