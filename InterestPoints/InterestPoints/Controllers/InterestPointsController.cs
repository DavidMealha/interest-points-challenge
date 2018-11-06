using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestPoints.DataAccess;
using InterestPoints.Models;
using InterestPoints.Services;
using Microsoft.AspNetCore.Mvc;

namespace InterestPoints.Controllers
{
    [Route("api/interest-points")]
    public class InterestPointsController : Controller
    {
        public readonly InterestPointsService _interestPointsService;

        public InterestPointsController(InterestPointsService interestPointsService)
        {
            _interestPointsService = interestPointsService;
        }

        [HttpGet]
        public IActionResult GetInterestPoints(TravelRoute route)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(Json(new { result = "missing or invalid parameters" }));
            }

            return Ok(Json(_interestPointsService.GetInterestPoints(route)));
        }

        [HttpGet]
        [Route("nearest")]
        public IActionResult GetNearestInterestPoint(GeographicPoint point)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(Json(new { result = "missing or invalid parameters" }));
            }

            return Ok(Json(_interestPointsService.GetNearestInterestPoint(point)));
        }

    }
}