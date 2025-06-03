using Movies2.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies2.Models
{
    public class Director : BaseModel
    {
        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}
