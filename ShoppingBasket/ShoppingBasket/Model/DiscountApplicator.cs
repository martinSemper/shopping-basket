using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingBasket.Model
{
    class DiscountApplicator 
    {
        readonly IEnumerable<Discount> _discounts;

        public DiscountApplicator(IEnumerable<Discount> discounts)
        {
            _discounts = discounts;

            if (_discounts.Select(d => d.TargetId).Distinct().Count() != _discounts.Count())
                throw new DiscountPolicyException("Each product may be targeted by only one discount at a time.");
        }
        
        public void ApplyDiscounts(Basket basket)
        {
            if (_discounts == null)
                return;

            foreach(var discount in _discounts)
            {
                var trigger = basket.Items.SingleOrDefault(i => i.Product.Id == discount.TriggerId);

                if (trigger == null)
                    continue;

                var target = basket.Items.SingleOrDefault(i => i.Product.Id == discount.TargetId);

                if (target == null)
                    continue;

                int discountsTriggered = trigger.Count / discount.TriggerStep;

                target.DiscountedProductsCount += Math.Min(discountsTriggered, target.Count);
                target.DiscountRate = discount.DiscountRate;
            }
        }
    }
}
