using ShoppingBasket.Logger.Templates;
using ShoppingBasket.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Logger
{
    public class ConsoleLogger : BasketVisitor, ILogger
    {
        public void LogBasket(Basket basket)
        {
            VisitBasket(basket);
        }

        public override void VisitBasket(Basket basket)
        {
            base.VisitBasket(basket);

            using (var paragraph = new Paragraph(1))
            {
                Console.WriteLine("Basket total: " + basket.Total);
            }                
        }

        public override void VisitItem(BasketItem basketItem)
        {            
            bool hasDiscounts = basketItem.DiscountedProductsCount > 0;
            decimal basePrice = basketItem.Count * basketItem.Product.UnitPrice;

            using (var itemParagraph = new Paragraph(1))
            {
                Console.WriteLine("Product: " + basketItem.Product.Name);
                Console.WriteLine("Unit price: " + basketItem.Product.UnitPrice);
                Console.WriteLine("Total Count: " + basketItem.Count);
                Console.WriteLine("Base price: " + basePrice);

                if (hasDiscounts)
                {
                    using (var discountsParagraph = new Paragraph(1))
                    {

                        Console.WriteLine("Discounted products: " + basketItem.DiscountedProductsCount);
                        Console.WriteLine("Discount rate: " + basketItem.DiscountRate * 100 + " %");
                        Console.WriteLine("Total discount: " + (basePrice - basketItem.TotalPrice));
                    }
                }

                Console.WriteLine("Total item price: " + basketItem.TotalPrice);
            }

            base.VisitItem(basketItem);
        }        
    }
}
