using ShoppingBasket.Logger;
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
        readonly DiscountRemover _discountRemover = new DiscountRemover();
        readonly ILogger _logger;

        public Basket(IEnumerable<Discount> discounts, ILogger logger)
        {
            _discountApplicator = new DiscountApplicator(discounts);
            _logger = logger;
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
            // reset 
            _discountRemover.VisitBasket(this);

            _discountApplicator.ApplyDiscounts(this);
            _priceCalculator.VisitBasket(this);

            _logger?.LogBasket(this);
        }
    }
}
