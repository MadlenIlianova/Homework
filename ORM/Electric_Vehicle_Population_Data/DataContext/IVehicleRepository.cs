using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleModels.Models;

namespace Infrastructure
{
    public interface IVehicleRepository
    {
        void AddVehicle(Vehicle vehicle);
        void UpdateVehicle(Vehicle vehicle);
        void DeleteVehicle(int id);
        List<Vehicle> GetAllVehicles();
        Vehicle GetById(int id);
    }
}
