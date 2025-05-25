using System;
using System.Collections.Generic;
using PizzaRestaurant;
namespace PizzaRestaurant
{
    internal class PizzaOrder
    {
        internal Pizza CreatePizza(string type, string size, int amount)
        {
            switch (type.ToLower())
            {
                case "margarita":
                    return new Margarita(size, amount);
                case "bosspizza":
                    return new BossPizza(size, amount);
                default:
                    throw new ArgumentException($"Невалиден тип пица!");
            }
        }
    }
}
