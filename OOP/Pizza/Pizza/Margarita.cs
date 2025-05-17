using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant
{
    internal class Margarita : Pizza
    {
        public Margarita(string size, int amount) : base(size, amount)
        {

        }
        public override void Prepare()
        {
            Console.WriteLine("Margarita preparing…");
            int dough = GetDoughWeight();
            Console.WriteLine($"Pizza dough {amount}*{dough} ={amount * dough}gr");
            Console.WriteLine($"Tomatoes {amount}*1 = {amount}");
            Console.WriteLine($"Total: ${GetTotalPrice()}");
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

        private int GetDoughWeight()
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
        public override string GetProductName()
        {
            return "Margarita";
        }
    }
}
















