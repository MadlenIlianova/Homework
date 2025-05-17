using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films
{
    public class MovieReader
    {
        public void GetData()
        {

            // Използваме директно File.ReadAllLines, за да прочетем CSV файла
            string[] lines = File.ReadAllLines("../../../imdb_top_2000_movies.csv");

            // Извеждаме заглавния ред
            Console.WriteLine("Заглавни колони: " + lines[0]);

            // Обработваме всички редове от данните като пример
            for (int i = 1; i < Math.Max(11, lines.Length); i++)
            {
                string[] columns = lines[i].Split(',');
                Console.WriteLine($"Ред {i}: {string.Join(" | ", columns)}");
            }

            Console.WriteLine($"Общ брой филми: {lines.Length - 1}"); // Изваждаме 1 за заглавния ред
        }
    }
}

