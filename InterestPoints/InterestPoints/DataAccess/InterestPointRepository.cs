using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestPoints.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace InterestPoints.DataAccess
{
    public class InterestPointRepository : RepositoryBase<InterestPoint>
    {
        public InterestPointRepository(IConfiguration configuration) : base(configuration) {
            _collection = _db.GetCollection<InterestPoint>("interest-points");
        }

        public List<InterestPoint> GetAll()
        {
            return _collection.Find(new BsonDocument()).ToList();
        }
    }
}
