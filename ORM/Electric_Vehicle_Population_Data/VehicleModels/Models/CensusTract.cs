using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleModels.BaseModels;

namespace VehicleModels.Models
{
    public class CensusTract : BaseModel
    {
        public long? CensusTract2020 { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public List<Vehicle>Vehicles { get; set; }
    }
}
