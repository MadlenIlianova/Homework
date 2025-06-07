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
        
        public List<Vehicle> GetVehicles()
        {
            var top5Cars = context.Vehicles
                .Take(5)
                .Where(x => x.Model != null)
                .OrderDescending()
                .ToList();                
            return top5Cars;
        }
    }
}
