using System;
using System.Collections.Generic;

namespace PizzaRestaurant.Interfaces
{
    internal interface IOrderManager
    {
        void AddOrder(IPizza pizza, string date);
        void PrintSummary();
    }
}
