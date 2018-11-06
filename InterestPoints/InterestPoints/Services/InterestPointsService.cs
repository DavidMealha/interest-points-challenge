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
            int smallestIndex = 0;
            float smallestDistance = float.MaxValue;
            int currentDistance;
            
            foreach (var item in interestPoints.Select((point, i) => new { i, point }))
            {
                currentDistance = CalculateDistance(item.point, currentLocation);
                if (currentDistance < smallestDistance)
                {
                    smallestIndex = item.i;
                    smallestDistance = currentDistance;
                }
            }

            return interestPoints[smallestIndex];
        }

        // more info: https://www.movable-type.co.uk/scripts/latlong.html
        private int CalculateDistance(InterestPoint point, GeographicPoint currentLocation)
        {
            int earthRadiusMeters = (int) 6371e3;

            float firstLatitudeRadians = (float)(currentLocation.latitude * (Math.PI / 180));
            float secondLatitudeRadians = (float)(point.latitude * (Math.PI / 180));

            float deltaLatitude = (float)((secondLatitudeRadians - firstLatitudeRadians) * (Math.PI / 180));
            float deltaLongitude = (float)((point.longitude - currentLocation.longitude) * (Math.PI / 180));

            float haversineA = (float)(Math.Sin(deltaLatitude / 2) * Math.Sin(deltaLatitude / 2) +
                Math.Cos(firstLatitudeRadians) * Math.Cos(secondLatitudeRadians) *
                Math.Sin(deltaLongitude / 2) * Math.Sin(deltaLongitude / 2));

            float haversineC = (float)(2 * Math.Atan2(Math.Sqrt(haversineA), Math.Sqrt(1 - haversineA)));

            return (int)(earthRadiusMeters * haversineC);
        }
    }
}
