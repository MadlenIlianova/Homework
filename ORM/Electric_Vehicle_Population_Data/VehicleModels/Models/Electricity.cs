using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleModels.BaseModels;

namespace VehicleModels.Models
{
    public class Electricity : BaseModel
    {
        public string ElectricVehicleType { get; set; }
        public int? ElectricRange { get; set; }
        public string ElectricUtility { get; set; }
        public string CAFV { get; set; }
        public int? LegislativeDistrict { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
