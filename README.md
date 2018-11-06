## Stack
* .NET Core API
* MongoDB hosted through Atlas

## Observations
* The Mongo collection has a compound index (latitude,longitude) to improve the performance of searching interest points between two points.
* In order to get the interest points between the start and the end of a trip, a perimeter between point A and B is calculated and all the interest points inside that perimeter are considered to be relevents data points.
* To find the nearest interest point in a specific location, the program computes a bounding box of 5km, making a search in the database for the nearest interest point to a max of 25km radius.
* It was also considered to increase the size of the bounding box in the case of encountering 0 results. (to implement)

## Endpoints
* Retrieve all interest points for a trip
```shell
  curl http://localhost:10882/api/interest-points?start_latitude=38.794208&start_longitude=-9.340710&end_latitude=38.568686&end_longitude=-8.840879
```

* Find nearest interest point
```shell
  curl http://localhost:10882/api/interest-points/nearest?latitude=38.5333312&longitude=-8.8833298
```