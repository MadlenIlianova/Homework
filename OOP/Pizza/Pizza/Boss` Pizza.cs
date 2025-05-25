using System;
using System.Collections.Generic;
using PizzaRestaurant;
namespace PizzaRestaurant
{
    internal class BossPizza : Pizza
    {
        internal BossPizza(string size, int amount) : base(size, amount)
        {

        }
        public override void Prepare()
        {
            Console.WriteLine("BossPizza preparing…");
            int dough = GetDoughWeight();
            Console.WriteLine($"Pizza dough:{amount}*{dough}={amount * dough}gr");
            PrintToppingInfo(amount);
            Console.WriteLine($"Total:${GetTotalPrice()}");
        }
        
        public override int GetPricePerProduct()
        {
            if (size == "small")
            {
                return 20;
            }
            else if (size == "medium")
            {
                return 25;
            }
            else if (size == "large")
            {
                return 30;
            }
            else
            {
                return 0;
            }
        }
        public override void PrintToppingInfo(int amount)
        {
            Console.WriteLine($"Ham:{amount}*100={amount*100}gr");
        }
        public override string GetProductName()
        {
            return "BossPizza";
        }
    }
}
