using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPoints.Models
{
    public class TravelRoute
    {
        [Required]
        [Range(-90, 90)]
        public float? start_latitude { get; set; }

        [Required]
        [Range(-180, 180)]
        public float? start_longitude { get; set; }

        [Required]
        [Range(-90, 90)]
        public float? end_latitude { get; set; }

        [Required]
        [Range(-180, 180)]
        public float? end_longitude { get; set; }
    }
}
