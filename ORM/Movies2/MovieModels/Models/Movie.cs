using Movies2.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies2.Models
{
    public class Movie : BaseModel
    {
       
        public int Duration { get; set; }
        public double Gross { get; set; }
        public int? ReleaseYear { get; set; }
        public double IMDBRating { get; set; }
        public double Metascore { get; set; }
        public double Vote { get; set; }


        public List<Genre>? Genres { get; set; }

        public int? DirectorId { get; set; }
        public Director? Director { get; set; }

        public int? CastId { get; set; }
        public Cast? Cast { get; set; }

    }
}
