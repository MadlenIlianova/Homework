using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleModels.Models;

namespace DataContext
{
    public class Queries
    {
        private readonly VehicleDbContext context;

        public List<object> GetTop5VehicleModelsWithCities()
        {
            var result = context.Vehicles
                .Where(v => v.Model != null && v.City != null)
                .GroupBy(v => v.Model)
                .Select(g => new
                {
                    Model = g.Key,
                    TotalCount = g.Count(),
                    TopCities = g.GroupBy(v => v.City.CityName)
                                 .Select(cg => new
                                 {
                                     City = cg.Key,
                                     Count = cg.Count()
                                 })
                                 .OrderByDescending(cg => cg.Count)
                                 .ToList()
                })
                .OrderByDescending(x => x.TotalCount)
                .Take(5)
                .ToList<object>();

            return result;
        }
        public List<object> GetVehiclesGroupedByMakeFilteredByElectricRange()
        {
            var result = context.Vehicles
                .Where(v => v.Electricity != null && v.Electricity.ElectricRange > 0)
                .GroupBy(v => v.Make)
                .Select(g => new
                {
                    Make = g.Key,
                    Count = g.Count(),
                    AverageRange = g.Average(v => v.Electricity.ElectricRange),
                    MaxRange = g.Max(v => v.Electricity.ElectricRange)
                })
                .OrderByDescending(g => g.MaxRange) // или g.AverageRange
                .ToList<object>();

            return result;
        }
    }
}
