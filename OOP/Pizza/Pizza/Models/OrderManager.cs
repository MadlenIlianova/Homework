using PizzaRestaurant.Interfaces;
using System;
using System.Collections.Generic;
namespace PizzaRestaurant.Models
{
    internal class OrderManager : IOrderManager
    {
        private readonly Dictionary<string, DaySales> salesByDate = new();
        public void AddOrder(IPizza pizza, string date)
        {
            if (!salesByDate.ContainsKey(date))
                salesByDate[date] = new DaySales();

            salesByDate[date].AddOrder(pizza);
        }

        public void PrintSummary()
        {
            Console.WriteLine("Cash register reset:");
            foreach (var entry in salesByDate)
            {
                Console.WriteLine($"Date: {entry.Key}");
                Console.WriteLine($"Total pizzas: {entry.Value.TotalPizzas}");
                Console.WriteLine($"Margarita: {entry.Value.MargaritaCount}");
                Console.WriteLine($"BossPizza: {entry.Value.BossPizzaCount}");
                Console.WriteLine($"Total income: ${entry.Value.TotalIncome}");
                Console.WriteLine();
            }
        }
    }
}
