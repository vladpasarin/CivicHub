using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CivicHub.Entities;
using CivicHub.Helpers;
using CivicHub.IServices;
using CivicHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CivicHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            return Ok(_userService.Register(request));
        }

        [HttpPost("login")]
        public IActionResult Login(AuthenticationRequest request)
        {
            return Ok(_userService.Login(request));
        }

        [HttpGet("all")]
        //[Authorize]
        public IActionResult GetAll()
        {
            var user = (User)HttpContext.Items["User"];
            var users = _userService.GetAll();
            if (users == null)
                return StatusCode(500);

            return Ok(users);
        }

        [HttpGet("GetUser/{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = (User)HttpContext.Items["User"];
            var users = _userService.GetById(id);
            if (users == null)
                return StatusCode(500);

            return Ok(users);
        }
    }
}
