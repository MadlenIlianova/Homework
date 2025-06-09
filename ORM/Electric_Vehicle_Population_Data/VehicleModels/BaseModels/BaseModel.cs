﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleModels.BaseModels
{
    public class BaseModel : IBaseModel
    {
        public int Id { get ; set ; }
        public DateTime CreatedAt { get ; set ; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } 
        public DateTime? DeletedAt {  get; set; }
        public bool IsDeletedAt { get; set; } 
    }
}
