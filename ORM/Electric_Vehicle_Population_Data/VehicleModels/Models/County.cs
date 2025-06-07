using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleModels.BaseModels;

namespace VehicleModels.Models
{
    public class County : BaseModel
    {
        public string CountyName { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
        public List<City> Cities { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
