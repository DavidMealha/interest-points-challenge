using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestPoints.Helpers;
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

        public List<InterestPoint> GetInterestPoints(TravelRoute route, string routeDirection)
        {
            return GetInterestPointsWithDirection(route, routeDirection);
        }

        public List<InterestPoint> GetPointsInsideBoundingBox(BoundingBox boundingBox)
        {
            return _collection.Find(point =>
                point.latitude > boundingBox.smallerLatitude &&
                point.latitude < boundingBox.largerLatitude &&
                point.longitude > boundingBox.smallerLongitude &&
                point.longitude < boundingBox.largerLongitude
            ).ToList();
        }

        private List<InterestPoint> GetInterestPointsWithDirection(TravelRoute route, string routeDirection)
        {
            if (ORIENTATION_TYPE.SOUTH_EAST.Equals(routeDirection))
            {
                return _collection.Find(point => 
                    point.latitude < route.start_latitude && 
                    point.latitude > route.end_latitude &&
                    point.longitude > route.start_longitude && 
                    point.longitude < route.end_longitude
                ).ToList();
            }
            else if (ORIENTATION_TYPE.NORTH_EAST.Equals(routeDirection))
            {
                return _collection.Find(point =>
                    point.latitude > route.start_latitude &&
                    point.latitude < route.end_latitude &&
                    point.longitude > route.start_longitude &&
                    point.longitude < route.end_longitude
                ).ToList();
            }
            else if (ORIENTATION_TYPE.SOUTH_WEST.Equals(routeDirection))
            {
                return _collection.Find(point =>
                    point.latitude < route.start_latitude &&
                    point.latitude > route.end_latitude &&
                    point.longitude < route.start_longitude &&
                    point.longitude > route.end_longitude
                ).ToList();
            }
            else if (ORIENTATION_TYPE.NORTH_WEST.Equals(routeDirection))
            {
                return _collection.Find(point =>
                    point.latitude > route.start_latitude &&
                    point.latitude < route.end_latitude &&
                    point.longitude < route.start_longitude &&
                    point.longitude > route.end_longitude
                ).ToList();
            }

            return new List<InterestPoint>();
        }
    }
}
