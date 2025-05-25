using Movies.Base_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class Director : BaseModel
    {
        public string DirectorName { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
