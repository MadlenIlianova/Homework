using System.Data.Common;
using System.Drawing;


namespace PizzaRestaurant
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, DaySales> salesByDate = new Dictionary<string, DaySales>();

            while (true)
            {
                Console.WriteLine("Въведи поръчка или 'end' за край на поръчката:");
                string input = Console.ReadLine();

                if (input.ToLower() == "end")
                    break;
                Console.WriteLine();

                string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 5 || parts[0].ToLower() != "pizza")
                {
                    Console.WriteLine("Невалиден формат на поръчката!");
                    continue;
                }
                

                string type = parts[1].ToLower();
                int amount = int.Parse(parts[2]);
                string size = parts[3].ToLower();
                string date = parts[4];

                Pizza pizza = null;

                if (type == "margarita")
                    pizza = new Margarita(size, amount);
                else if (type == "bosspizza")
                    pizza = new BossPizza(size, amount);
                else
                {
                    Console.WriteLine("Неизвестен тип пица!");
                    continue;
                }

                pizza.Prepare();

                if (!salesByDate.ContainsKey(date))
                    salesByDate[date] = new DaySales();

                salesByDate[date].AddOrder(pizza);
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Cash register reset:");
            foreach (var entry in salesByDate)
            {
                Console.WriteLine(entry.Key);
                Console.WriteLine($"Total pizzas = {entry.Value.TotalPizzas}");
                Console.WriteLine($"Margarita = {entry.Value.MargaritaCount}");
                Console.WriteLine($"BossPizza = {entry.Value.BossPizzaCount}");
                Console.WriteLine($"Total Income = ${entry.Value.TotalIncome}");
                Console.WriteLine();


            }
        }
    }
}

