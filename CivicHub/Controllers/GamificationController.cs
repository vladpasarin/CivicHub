using CivicHub.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamificationController : ControllerBase
    {
        private readonly IUserService _userService;

        public GamificationController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet("GetBadgeNumber/{id}")]
        public IActionResult GetBadgeNumber(Guid id)
        {
            var user = _userService.GetById(id);
            if (user == null) return NotFound("Userul nu exista");
            int numberOfPoints = user.Points;
            int badge = 1;
            if (numberOfPoints < 10)
            {
                badge = 1;
            }
            if (numberOfPoints >= 10 && numberOfPoints < 50)
            {
                badge = 2;
            }
            if (numberOfPoints >= 50 && numberOfPoints < 150)
            {
                badge = 3;
            }
            if (numberOfPoints >= 150 && numberOfPoints < 300)
            {
                badge = 4;
            }
            if (numberOfPoints >= 300 && numberOfPoints < 450)
            {
                badge = 5;
            }
            if (numberOfPoints >= 450 && numberOfPoints < 650)
            {
                badge = 6;
            }
            if (numberOfPoints >= 650 && numberOfPoints < 900)
            {
                badge = 7;
            }
            if (numberOfPoints >= 900 && numberOfPoints < 1200)
            {
                badge = 8;
            }
            if (numberOfPoints >= 1200)
            {
                badge = 9;
            }
            return Ok(badge);
        }

        [HttpGet("GetPoints/{id}")]
        public IActionResult GetPoints(Guid id)
        {
            var user = _userService.GetById(id);
            if (user == null) return NotFound("Userul nu exista");
            return Ok(user.Points);
        }

        [HttpGet("GetUsersTop")]
        public IActionResult GetUsersTop()
        {
            return Ok(_userService.getUsersTop());
        }
    }
}
