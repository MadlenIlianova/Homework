using System;
using System.Collections.Generic;
namespace PizzaRestaurant.Models
{
    internal class BossPizza : Pizza
    {
        internal BossPizza(string size, int amount) : base(size, amount) { }

        public override void Prepare()
        {
            Console.WriteLine("Preparing BossPizza...");
            int dough = GetDoughWeight();
            Console.WriteLine($"Dough: {amount} * {dough} = {amount * dough} gr");
            PrintToppingInfo(amount);
            Console.WriteLine($"Total price: ${GetTotalPrice()}");
        }

        public override string GetProductName()
        {
            return "BossPizza";
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

        protected override void PrintToppingInfo(int amount)
        {
            Console.WriteLine($"Ham: {amount} * 100 = {amount * 100} gr");
        }
    }
}
