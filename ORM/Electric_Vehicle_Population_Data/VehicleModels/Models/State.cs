using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleModels.BaseModels;

namespace VehicleModels.Models
{
    public class State : BaseModel
    {
        public string StateName { get; set; }
        public List<County> Counties { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
