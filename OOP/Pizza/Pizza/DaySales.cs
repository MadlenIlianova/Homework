using System;
using System.Collections.Generic;
using PizzaRestaurant;

namespace PizzaRestaurant
{
    internal class DaySales
    {
        internal int MargaritaCount { get; private set; }
        internal int BossPizzaCount { get; private set; }
        internal int TotalIncome { get; private set; }

        internal int TotalPizzas
        {
            get { return MargaritaCount + BossPizzaCount; }
        }

        internal void AddOrder(Pizza pizza)
        {
            string name = pizza.GetProductName().ToLower();
            int amount = pizza.GetAmount();
            if (pizza.GetProductName() == "Margarita")
            {
                MargaritaCount += amount;
            }
            else if (pizza.GetProductName() == "BossPizza")
            {
                BossPizzaCount += amount;
            }

            TotalIncome += pizza.GetTotalPrice();
        }
    }
}

