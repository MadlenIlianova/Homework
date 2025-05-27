using System;
using System.Collections.Generic;
namespace PizzaRestaurant.Models
{
    internal class Margarita : Pizza
    {
        internal Margarita(string size, int amount) : base(size, amount) { }

        public override void Prepare()
        {
            Console.WriteLine("Preparing Margarita...");
            int dough = GetDoughWeight();
            Console.WriteLine($"Dough: {amount} * {dough} = {amount * dough} gr");
            PrintToppingInfo(amount);
            Console.WriteLine($"Total price: ${GetTotalPrice()}");
        }

        public override string GetProductName() 
        {
            return "Margarita";
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

        protected override void PrintToppingInfo(int amount)
        {
            Console.WriteLine($"Tomatoes: {amount} * 1 = {amount*1}");
        }
    }
}
















