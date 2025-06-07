
using System.ComponentModel.DataAnnotations.Schema;
using VehicleModels.BaseModels;

namespace VehicleModels.Models
{
    public class Vehicle : BaseModel
    {
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int? ModelYear { get; set; }
        public int? BaseMSRP { get; set; }
        public int DOLVehicleId { get; set; }
        public string Location { get; set; }
        public int? PostalCode { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
        public int ElectricityId { get; set; }
        public Electricity Electricity { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int CountyId { get; set; }
        public County County { get; set; }
        public int CensusTractId { get; set; }
        public CensusTract CensusTract { get; set; }
    }
}
