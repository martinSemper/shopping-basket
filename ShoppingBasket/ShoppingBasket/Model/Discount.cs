using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingBasket.Model
{
    public class Discount
    {
        public int TriggerId { get; set; }
        public int TriggerStep { get; set; }
        public int TargetId { get; set; }
        public decimal DiscountRate { get; set; }
    }
}
