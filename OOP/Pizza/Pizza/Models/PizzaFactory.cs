using PizzaRestaurant.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant.Models
{
    internal class PizzaFactory
    {
        internal static IPizza CreatePizza(string type, string size, int amount)
        {
            switch (type)
            {
                case "margarita":
                    return new Margarita(size, amount);
                case "bosspizza":
                    return new BossPizza(size, amount);
                default:
                    return null;
            }
        }
    }
}
