using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingBasket.Model
{
    public class Basket
    {
        readonly List<BasketItem> _basketItems = new List<BasketItem>();
        readonly PriceCalculator _priceCalculator = new PriceCalculator();
        readonly DiscountApplicator _discountApplicator;

        public Basket(IEnumerable<Discount> discounts)
        {
            _discountApplicator = new DiscountApplicator(discounts);
        }

        public decimal Total { get; internal set; }

        public IEnumerable<BasketItem> Items { get { return _basketItems; } }

        public void AddItem(Product product, int count)
        {
            var existingItem = _basketItems.SingleOrDefault(i => i.Product.Id == product.Id);

            if (existingItem != null)
                throw new InvalidOperationException("Item with the same ProductId is already added.");

            _basketItems.Add(new BasketItem() { Product = product, Count = count });
        }

        public void UpdateItem(int productId, int count)
        {
            var existingItem = _basketItems.SingleOrDefault(i => i.Product.Id == productId);

            if (existingItem != null)
                throw new InvalidOperationException("Item was not found");

            existingItem.Count = count;
        } 
        
        public void RefreshTotal()
        {
            _discountApplicator.ApplyDiscounts(this);
            _priceCalculator.VisitBasket(this);
        }
    }
}
