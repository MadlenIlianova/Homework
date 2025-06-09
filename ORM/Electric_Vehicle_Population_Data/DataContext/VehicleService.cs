using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext
{
    public class VehicleService
    {
        private readonly Repository _repository;
        private readonly VehicleDbContext _context;

        public VehicleService(VehicleDbContext context)
        {
            _context = context;
            _repository = new Repository(context);
        }

        public void DeleteVehicle(int id)
        {
            var vehicle = _context.Vehicles.FirstOrDefault(v => v.Id == id && !v.IsDeletedAt);
            if (vehicle != null)
            {
                _repository.SoftDelete(vehicle);
            }
        }
    }

}
