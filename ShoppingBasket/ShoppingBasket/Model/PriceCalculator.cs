using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Model
{
    class PriceCalculator : BasketVisitor
    {
        public override void VisitBasket(Basket basket)
        {
            base.VisitBasket(basket);

            foreach(var item in basket.Items)
            {
                basket.Total += item.TotalPrice;
            }
        }

        public override void VisitItem(BasketItem basketItem)
        {
            decimal regularTotal = (basketItem.Count - basketItem.DiscountedProductsCount) * basketItem.Product.UnitPrice;
            decimal discountedTotal = basketItem.DiscountedProductsCount * basketItem.Product.UnitPrice * (1 - basketItem.DiscountRate);

            basketItem.TotalPrice = regularTotal + discountedTotal;

            base.VisitItem(basketItem);
        }
    }
}
