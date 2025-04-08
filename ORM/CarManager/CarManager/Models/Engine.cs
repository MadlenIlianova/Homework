using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.Models
{
    public class Engine
    {
        public int Id { get; set; }
        public int Horsepower { get; set; }
        public int Cylinders { get; set; }
        public string FuelType { get; set; }
        public ICollection<Cars> Cars { get; set; } = new List <Cars>();
    }
}
