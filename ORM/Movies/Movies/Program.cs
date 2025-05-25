using Movies.CsvRead;

namespace Movies
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CsvFileReader reader = new CsvFileReader();
            
            var list=reader.GetData();

            foreach (var item in list) 
            {
                Console.WriteLine(item.MovieName);
            }
        }
    }
}
