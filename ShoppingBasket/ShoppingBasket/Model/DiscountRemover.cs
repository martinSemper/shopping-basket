using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Model
{
    class DiscountRemover : BasketVisitor
    {
        public override void VisitItem(BasketItem basketItem)
        {
            basketItem.DiscountedProductsCount = 0;
            basketItem.DiscountRate = 0;            

            base.VisitItem(basketItem);
        }
    }
}
