using System;
using System.Collections.Generic;
using PizzaRestaurant;

namespace PizzaRestaurant
{
    abstract class Pizza : IPizza , ITopping
    {
        protected readonly string size;
        protected readonly int amount;

        protected Pizza(string size,int amount)
        {
            this.size = size;
            this.amount = amount;
        }
        public abstract void Prepare();
        
        public abstract string GetProductName();

        public abstract int GetPricePerProduct();

        internal int GetDoughWeight()
        {
            int weight = 0;

            if (size == "small")
            {
                weight = 300;
            }
            else if (size == "medium")
            {
                weight = 500;
            }
            else if (size == "large")
            {
                weight = 800;
            }
            else
            {
                Console.WriteLine("Невалиден размер! Избрана стойност: 0g.");
            }

            return weight;
        }

        public int GetTotalPrice()
        {
            return GetPricePerProduct() * amount;

        }

        public abstract void PrintToppingInfo(int amount);

        internal int GetAmount()
        {
            return amount;
        } 
    }
}



