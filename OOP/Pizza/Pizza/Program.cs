using PizzaRestaurant;
using System;
using System.Collections.Generic;
namespace PizzaRestaurant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var salesByDate = new Dictionary<string, DaySales>();

            while (true)
            {
                string input = ReadInput();
                if (input.ToLower() == "end")
                    break;

                if (!TryParseInput(input, out string type, out int amount, out string size, out string date))
                    continue;

                Pizza pizza = CreatePizza(type, size, amount);
                if (pizza == null)
                {
                    Console.WriteLine("Неизвестен тип пица!");
                    continue;
                }

                pizza.Prepare();
                AddPizzaToSales(salesByDate, date, pizza);
                Console.WriteLine();
            }
            PrintSummary(salesByDate);
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

            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 5 || parts[0].ToLower() != "pizza")
            {
                Console.WriteLine("Невалиден формат на поръчката!");
                return false;
            }

            type = parts[1].ToLower();

            if (!int.TryParse(parts[2], out amount))
            {
                Console.WriteLine("Невалидно количество!");
                return false;
            }

            size = parts[3].ToLower();
            date = parts[4];
            return true;
        }

        static Pizza CreatePizza(string type, string size, int amount)
        {
            if (type == "margarita")
                return new Margarita(size, amount);
            else if (type == "bosspizza")
                return new BossPizza(size, amount);
            else
                return null;
        }

        static void AddPizzaToSales(Dictionary<string, DaySales> salesByDate, string date, Pizza pizza)
        {
            if (!salesByDate.ContainsKey(date))
                salesByDate[date] = new DaySales();

            salesByDate[date].AddOrder(pizza);
        }

        static void PrintSummary(Dictionary<string, DaySales> salesByDate)
        {
            Console.WriteLine("Cash register reset:");
            foreach (var entry in salesByDate)
            {
                Console.WriteLine(entry.Key);
                Console.WriteLine($"Total pizzas: {entry.Value.TotalPizzas}");
                Console.WriteLine($"Margarita: {entry.Value.MargaritaCount}");
                Console.WriteLine($"BossPizza: {entry.Value.BossPizzaCount}");
                Console.WriteLine($"Total Income = ${entry.Value.TotalIncome}");
                Console.WriteLine();
            }
        }
    }
}










