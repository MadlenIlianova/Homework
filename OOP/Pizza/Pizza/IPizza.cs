using System;
using System.Collections.Generic;
using PizzaRestaurant;

namespace PizzaRestaurant
{
    internal interface IPizza
    {
        void Prepare();
        string GetProductName();
        int GetPricePerProduct();
        int GetTotalPrice();
    }
}
