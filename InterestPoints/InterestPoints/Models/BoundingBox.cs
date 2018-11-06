using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPoints.Models
{
    public class BoundingBox
    {
        public float smallerLatitude { get; set; }

        public float smallerLongitude { get; set; }

        public float largerLatitude { get; set; }

        public float largerLongitude { get; set; }
    }
}
