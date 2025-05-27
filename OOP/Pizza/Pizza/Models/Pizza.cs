using System;
using System.Collections.Generic;
using PizzaRestaurant.Interfaces;

namespace PizzaRestaurant.Models
{
    public abstract class Pizza : IPizza
    {
        protected readonly string size;
        protected readonly int amount;

        protected Pizza(string size, int amount)
        {
            this.size = size.ToLower();
            this.amount = amount;
        }

        public abstract void Prepare();

        public abstract string GetProductName();

        public abstract int GetPricePerProduct();

        public int GetTotalPrice()
        {
            return GetPricePerProduct() * amount;
        }

        public int GetAmount()
        {
            return amount;
        }

        protected int GetDoughWeight()
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
                Console.WriteLine("Невалиден размер!");
            }
            return weight;
        }

        protected abstract void PrintToppingInfo(int amount);
    }
}




