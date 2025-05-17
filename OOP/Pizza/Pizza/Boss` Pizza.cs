using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant
{
    internal class BossPizza : Pizza
    {
        public BossPizza(string size, int amount) : base(size, amount)
        {

        }
        public override void Prepare()
        {
            Console.WriteLine("BossPizza preparing…");
            int dough = GetDoughWeight();
            Console.WriteLine($"Pizza dough {amount}*{dough} ={amount * dough}gr");
            Console.WriteLine($"Ham {amount}*100 = {amount*100}gr");
            Console.WriteLine($"Total: ${GetTotalPrice()}");
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
        public override string GetProductName()
        {
            return "BossPizza";
        }
    }
}
