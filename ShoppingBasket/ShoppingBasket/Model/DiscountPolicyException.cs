using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Model
{
    public class DiscountPolicyException : ArgumentException
    {
        public DiscountPolicyException(string message) : base(message)
        {

        }
    }
}
