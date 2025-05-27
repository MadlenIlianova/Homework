using PizzaRestaurant.Interfaces;
using System;
using System.Collections.Generic;
namespace PizzaRestaurant.Models
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IOrderManager orderManager = new OrderManager();
            PizzaFactory pizzaFactory = new PizzaFactory();

            while (true)
            {
                string input = ReadInput();
                if (input.ToLower() == "end")
                    break;

                if (!TryParseInput(input, out string type, out int amount, out string size, out string date))
                {
                    Console.WriteLine("Невалиден формат на поръчката!");
                    continue;
                }

                IPizza pizza = PizzaFactory.CreatePizza(type, size, amount);
                if (pizza == null)
                {
                    Console.WriteLine("Неизвестен тип пица!");
                    continue;
                }

                pizza.Prepare();
                orderManager.AddOrder(pizza, date);
            }

            orderManager.PrintSummary();
        }

        static string ReadInput()
        {
            Console.WriteLine("Въведи поръчка или 'end' за край на поръчката:");
            return Console.ReadLine();
        }

        static bool TryParseInput(string input, out string type, out int amount, out string size, out string date)
        {
            type = "";
            amount = 0;
            size = "";
            date = "";

            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 5 || parts[0].ToLower() != "pizza")
                return false;

            type = parts[1].ToLower();
            if (!int.TryParse(parts[2], out amount))
                return false;

            size = parts[3].ToLower();
            date = parts[4];
            return true;
        }
    }
}













