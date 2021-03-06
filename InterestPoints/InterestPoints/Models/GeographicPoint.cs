﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPoints.Models
{
    public class GeographicPoint
    {
        [Required]
        [Range(-90, 90)]
        public float? latitude { get; set; }

        [Required]
        [Range(-180, 180)]
        public float? longitude { get; set; }
    }
}
