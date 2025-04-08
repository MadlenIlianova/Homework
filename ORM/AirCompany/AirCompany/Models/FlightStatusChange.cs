using AirCompany.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirCompany.Models
{
    public class FlightStatusChange : BaseModel
    {
        public int FlightId { get; set; }
        public Flight Flight { get; set; } = null!;
        public int FlightStatusId { get; set; }
        public FlightStatus FlightStatus { get; set; } = null!;
        public DateTime ChangeAt { get; set; }
    }
}
