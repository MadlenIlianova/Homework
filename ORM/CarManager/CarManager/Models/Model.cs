﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.Models
{
    public class Model
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Year { get; set; }
        public ICollection<Cars> Cars { get; set; } = new List<Cars>();



    }
}
