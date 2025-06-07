using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleModels.BaseModels;

namespace VehicleModels.Models
{
    public class City : BaseModel
    {
        public string CityName { get; set; }
        public int CountyId { get; set; }
        public County County { get; set; }
        public List<CensusTract> CensusTracts { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
