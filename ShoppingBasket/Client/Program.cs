using ShoppingBasket.Logger;
using ShoppingBasket.Model;
using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Product _butter = new Product(1, 0.8m) { Name = "butter" };
            Product _bread = new Product(2, 1) { Name = "bread" };
            Product _milk = new Product(3, 1.15m) { Name = "milk" };

            var twoButtersOneBread50percent = new Discount()
            {
                DiscountRate = 0.5m,
                TriggerStep = 2,
                TriggerId = 1,
                TargetId = 2
            };

            var threeMilksFourthMilkFree = new Discount()
            {
                DiscountRate = 1m,
                TriggerStep = 4,
                TriggerId = 3,
                TargetId = 3
            };

            var basket = new Basket(new Discount[] { twoButtersOneBread50percent, threeMilksFourthMilkFree }, new ConsoleLogger());

            basket.AddItem(_butter, 2);
            basket.AddItem(_bread, 1);
            basket.AddItem(_milk, 8);

            basket.RefreshTotal();
        }
    }
}
