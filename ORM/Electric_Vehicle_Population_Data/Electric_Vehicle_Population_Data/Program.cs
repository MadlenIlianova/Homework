
using DataContext;
using Infrastructure;

namespace Electric_Vehicle_Population_Data
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new VehicleDbContext())
            {
                CsvFileReader csvFileReader = new CsvFileReader();
                csvFileReader.GetData();
                var dataSeed = new DataSeeder(csvFileReader, context);
                dataSeed.SeedData();
                Console.WriteLine("gotovo");
            }
        }
    }
}


