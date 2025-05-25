using System;
using System.Collections.Generic;
using PizzaRestaurant;
namespace PizzaRestaurant
{
    internal class Margarita : Pizza 
    {
        internal Margarita(string size, int amount) : base(size, amount)
        {

        }
        public override void Prepare()
        {
            Console.WriteLine("Margarita preparing…");
            int dough = GetDoughWeight();
            Console.WriteLine($"Pizza dough:{amount}*{dough}={amount * dough}gr");
            PrintToppingInfo(amount);
            Console.WriteLine($"Total:${GetTotalPrice()}");
        }

        public override int GetPricePerProduct()
        {
            if (size == "small")
            {
                return 5;
            }
            else if (size == "medium")
            {
                return 10;
            }
            else if (size == "large")
            {
                return 15;
            }
            else
            {
                return 0;
            }
        }

        public override void PrintToppingInfo(int amount)
        {
            Console.WriteLine($"Tomatoes:{amount}*1={amount}");
        }

        public override string GetProductName()
        {
            return "Margarita";
        }
    }
}
















