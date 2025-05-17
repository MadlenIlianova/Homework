using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant
{
    internal class DaySales
    {
        public int MargaritaCount { get; private set; }
        public int BossPizzaCount { get; private set; }
        public int TotalIncome { get; private set; }

        public int TotalPizzas
        {
            get { return MargaritaCount + BossPizzaCount; }
        }

        public void AddOrder(Pizza pizza) 
        {
            string name = pizza.GetProductName().ToLower();
            int amount = pizza.GetAmount();
            if (pizza.GetProductName() == "Margarita")
                MargaritaCount+=amount;
            else if (pizza.GetProductName() == "BossPizza")
                BossPizzaCount += amount;

            TotalIncome += pizza.GetTotalPrice();
        }

    }
}

