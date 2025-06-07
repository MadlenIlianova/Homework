using CsvHelper;
using System.Globalization;
using VehicleModels.Models;

namespace Infrastructure
{
    public class CsvFileReader : ICsvFileReader
    {
        public List<Model> GetData() 
        {
            using (var reader = new StreamReader(GlobalParams.GlobalParams.FileDir))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture)) 
            {
            csv.Context.RegisterClassMap<ModelClassMap>();
            var vehicles = csv.GetRecords<Model>().Where(v => 
            !string.IsNullOrWhiteSpace(v.VIN1_10))
                      .ToList();
                return vehicles;                    
            }              
        }
    }
}
