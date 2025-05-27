using System;
using System.Collections.Generic;

namespace PizzaRestaurant.Interfaces
{
    internal interface IPizza
    {
        void Prepare();
        string GetProductName();
        int GetPricePerProduct();
        int GetTotalPrice();
        int GetAmount();
    }
}
