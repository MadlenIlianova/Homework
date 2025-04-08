using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.Models
{
    public class Cars
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public int Seats { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public int Lenght { get; set; }

        public int EngineId { get; set; }
        public Engine Engine { get; set; }





    }
}
