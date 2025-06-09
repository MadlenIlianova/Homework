using DataContext;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleModels.Models;

namespace Electric_Vehicle_Population_Data
{

    public class VehicleRepository : IVehicleRepository
    {
        private readonly VehicleDbContext _dbContext;

        public VehicleRepository(VehicleDbContext context)
        {
            _dbContext = context;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _dbContext.Vehicles.Add(vehicle);
            _dbContext.SaveChanges();
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            var existing = _dbContext.Vehicles.FirstOrDefault(v => v.Id == vehicle.Id && v.DeletedAt == null);
            if (existing != null)
            {
                existing.Make = vehicle.Make;
                existing.Model = vehicle.Model;
                existing.ModelYear = vehicle.ModelYear;
                existing.UpdatedAt = DateTime.UtcNow;

                _dbContext.SaveChanges();
            }
        }

        public void DeleteVehicle(int id)
        {
            var vehicle = _dbContext.Vehicles.FirstOrDefault(v => v.Id == id && v.DeletedAt == null);
            if (vehicle != null)
            {
                vehicle.DeletedAt = DateTime.UtcNow; // soft-delete
                _dbContext.SaveChanges();
            }
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _dbContext.Vehicles
                .Where(v => v.DeletedAt == null)
                .ToList();
        }

        public Vehicle GetById(int id)
        {
            return _dbContext.Vehicles.FirstOrDefault(v => v.Id == id && v.DeletedAt == null);
        }
    }

}
