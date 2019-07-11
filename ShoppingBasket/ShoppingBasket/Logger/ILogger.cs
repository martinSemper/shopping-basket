using ShoppingBasket.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Logger
{
    public interface ILogger
    {
        void LogBasket(Basket basket);
    }
}
