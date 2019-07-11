using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingBasket.Model
{
    public class Basket
    {
        private readonly IEnumerable<Discount> _discounts;
        public Basket(IEnumerable<Discount> discounts)
        {
            _discounts = discounts;
        }

        public decimal Total { get; internal set; }
        
        public void AddItem(Product product, int count)
        {            
            
        }

        public void UpdateItem(int productId, int count)
        {
            
        } 
        
        public void RefreshTotal()
        {
            
        }
    }
}
