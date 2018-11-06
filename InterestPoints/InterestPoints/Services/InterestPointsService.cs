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
            BoundingBox boundingBox = GetPointBoundingBox(point);
            return FindNearestPoint(_interestPointRepository.GetPointsInsideBoundingBox(boundingBox), point);
        }

        private BoundingBox GetPointBoundingBox(GeographicPoint point)
        {
            float kilometersPerDegree = 111; //could be constants
            float oneKilometerToDegrees = 1 / kilometersPerDegree;
            float fiveKilometersToDegress = 5 * oneKilometerToDegrees;

            float smallerLatitude = (float)point.latitude - fiveKilometersToDegress;
            float largerLatitude = (float)point.latitude + fiveKilometersToDegress;

            float latitudeToRadians = (float)((Math.PI / 180) * point.latitude);

            float smallerLongitude = (float)(point.longitude - (fiveKilometersToDegress / Math.Cos(latitudeToRadians)));
            float largerLongitude = (float)(point.longitude + (fiveKilometersToDegress / Math.Cos(latitudeToRadians)));

            return new BoundingBox() {
                smallerLatitude = smallerLatitude,
                smallerLongitude = smallerLongitude,
                largerLatitude = largerLatitude,
                largerLongitude = largerLongitude
            };
        }

        private InterestPoint FindNearestPoint(List<InterestPoint> interestPoints, GeographicPoint currentLocation)
        {
            int smallestIndex;
            float smallestDistance = float.MaxValue;

            foreach (InterestPoint point in interestPoints)
            {

            }

            return new InterestPoint();
        }

        private float CalculateDistance(InterestPoint point, GeographicPoint currentLocation)
        {
            return 0;
        }
    }
}
