using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestPoints.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace InterestPoints.Controllers
{
    [Route("api/interest-point")]
    public class InterestPointsController : Controller
    {
        public readonly InterestPointRepository _interestPointRepository;

        public InterestPointsController(InterestPointRepository interestPointRepository)
        {
            _interestPointRepository = interestPointRepository;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return Json(_interestPointRepository.GetAll());
        }
    }
}
