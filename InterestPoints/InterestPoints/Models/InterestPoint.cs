using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPoints.Models
{
    public class InterestPoint
    {
        public ObjectId Id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public double latitude { get; set; }

        public double longitude { get; set; }

        public string region { get; set; }

        public string country { get; set; }

        public string type { get; set; }

        public string phone_number { get; set; }
    }
}
