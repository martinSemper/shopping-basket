﻿using NUnit.Framework;
using ShoppingBasket.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Tests
{
    [TestFixture]
    public class BasketTest
    {
        readonly List<Discount> _discounts = new List<Discount>();

        Product _butter = new Product(1, 0.8m);
        Product _bread = new Product(2, 1);
        Product _milk = new Product(3, 1.15m);

        public BasketTest()
        {
            CreateDiscounts();
        }

        [Test]
        public void BasketInstantiationTwoDiscountsSameTargetThrows()
        {
            var discount1 = new Discount() { TriggerId = 1, TargetId = 2 };
            var discount2 = new Discount() { TriggerId = 2, TargetId = 2 };

            var discounts = new Discount[] { discount1, discount2 };

            Assert.Throws<DiscountPolicyException>(() => new Basket(discounts, null));
        }

        [Test]
        public void TresholdNotReachedNoDiscount()
        {
            Basket basket = new Basket(_discounts, new DummyLogger());

            basket.AddItem(_butter, 1);
            basket.AddItem(_bread, 1);
            basket.AddItem(_milk, 1);

            basket.RefreshTotal();

            Assert.AreEqual(2.95m, basket.Total);
        }

        [Test]
        public void TwoButersTwoBreadsOneBread50PercentOff()
        {
            Basket basket = new Basket(_discounts, new DummyLogger());

            basket.AddItem(_butter, 2);
            basket.AddItem(_bread, 2);

            basket.RefreshTotal();

            Assert.AreEqual(3.10m, basket.Total);
        }

        [Test]
        public void ThreeButersTwoBreadsOneBread50PercentOff()
        {
            Basket basket = new Basket(_discounts, new DummyLogger());

            basket.AddItem(_butter, 3);
            basket.AddItem(_bread, 2);

            basket.RefreshTotal();

            Assert.AreEqual(3.90m, basket.Total);
        }

        [Test]
        public void FourMilksOneMilkFree()
        {
            Basket basket = new Basket(_discounts, new DummyLogger());

            basket.AddItem(_milk, 4);

            basket.RefreshTotal();

            Assert.AreEqual(3.45m, basket.Total);
        }

        [Test]
        public void TwoButtersEightMilksTriggerThreeDiscounts()
        {
            Basket basket = new Basket(_discounts, new DummyLogger());

            basket.AddItem(_butter, 2);
            basket.AddItem(_bread, 1);
            basket.AddItem(_milk, 8);

            basket.RefreshTotal();

            Assert.AreEqual(9m, basket.Total);
        }        

        [Test]
        public void RefreshTotalCalledTwiceYieldsSameResult()
        {
            Basket basket = new Basket(_discounts, new DummyLogger());

            basket.AddItem(_butter, 2);
            basket.AddItem(_bread, 1);
            basket.AddItem(_milk, 8);

            basket.RefreshTotal();

            Assert.AreEqual(9m, basket.Total);

            basket.RefreshTotal();

            Assert.AreEqual(9m, basket.Total);
        }
        
        private void CreateDiscounts()
        {
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

            _discounts.Add(twoButtersOneBread50percent);
            _discounts.Add(threeMilksFourthMilkFree);
        }
    }
}
