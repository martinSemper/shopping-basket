using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Model
{
    public abstract class BasketVisitor
    {
        public virtual void VisitBasket(Basket basket)
        {
            foreach(var item in basket.Items)
            {
                VisitItem(item);
            }
        }

        public virtual void VisitItem(BasketItem basketItem)
        {

        }
    }
}
