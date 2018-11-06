using InterestPoints.DataAccess;
using InterestPoints.Helpers;
using InterestPoints.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPoints.Services
{
    public class InterestPointsService
    {
        public readonly InterestPointRepository _interestPointRepository;

        public InterestPointsService(InterestPointRepository interestPointRepository)
        {
            _interestPointRepository = interestPointRepository;
        }
        
        public List<InterestPoint> GetInterestPoints(TravelRoute route)
        {
            if (route.start_latitude > route.end_latitude && route.start_longitude < route.end_longitude)
            {
                return _interestPointRepository.GetInterestPoints(route, ORIENTATION_TYPE.SOUTH_EAST);
            }
            else if (route.start_latitude < route.end_latitude && route.start_longitude < route.end_longitude)
            {
                return _interestPointRepository.GetInterestPoints(route, ORIENTATION_TYPE.NORTH_EAST);
            }
            else if (route.start_latitude > route.end_latitude && route.start_longitude > route.end_longitude)
            {
                return _interestPointRepository.GetInterestPoints(route, ORIENTATION_TYPE.SOUTH_WEST);
            }
            else if (route.start_latitude < route.end_latitude && route.start_longitude > route.end_longitude)
            {
                return _interestPointRepository.GetInterestPoints(route, ORIENTATION_TYPE.NORTH_WEST);
            }
            return new List<InterestPoint>();
        }

        public InterestPoint GetNearestInterestPoint(GeographicPoint point)
        {
            //find nearest point in a 5km radius
            //if none find in a 10km radius
            //if none find in a 25km radius
            //if none find in a 50km radius
            return new InterestPoint() { };
        }
    }
}
