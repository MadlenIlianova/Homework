using PizzaRestaurant.Interfaces;
using System;
using System.Collections.Generic;

namespace PizzaRestaurant.Models
{
    internal class DaySales
    {
        internal int MargaritaCount { get; private set; }
        internal int BossPizzaCount { get; private set; }
        internal int TotalIncome { get; private set; }

        internal int TotalPizzas
        {
            get
            {
                return MargaritaCount + BossPizzaCount;
            }
        }

        public void AddOrder(IPizza pizza)
        {
            string name = pizza.GetProductName().ToLower();
            int amount = pizza.GetAmount();

            if (name == "margarita")
                MargaritaCount += amount;
            else if (name == "bosspizza")
                BossPizzaCount += amount;

            TotalIncome += pizza.GetTotalPrice();
        }
    }
}


