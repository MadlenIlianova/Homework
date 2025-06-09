
using DataContext;
using Infrastructure;
using VehicleModels.Models;

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

                var repository = new VehicleRepository(context);

                Vehicle vehicle = new Vehicle();
                repository.AddVehicle(vehicle);
                repository.UpdateVehicle(vehicle);
                repository.GetById(0);
                repository.DeleteVehicle(0);
                repository.GetAllVehicles();
                
            }
        }
    }
}


