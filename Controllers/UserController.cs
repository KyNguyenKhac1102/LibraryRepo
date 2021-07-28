using System;
using LibraryApp.Dtos;
using LibraryApp.Helper;
using LibraryApp.Models;
using LibraryApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        private readonly JwtService _jwtService;
        public UserController(IUserService service, JwtService jwtService)
        {
            _service = service;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            };

            return Created("success", _service.Create(user));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _service.GetByEmail(dto.Email);

            if (user == null)
            {
                return BadRequest(new { message = "Invalid Email!!" });
            }

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                return BadRequest(new { message = "Invalid Password" });
            }

            var jwt = _jwtService.Generate(user.UserId);
            // send jwt to frontend cookie    
            Response.Cookies.Append("jwtt", jwt, new CookieOptions
            {
                HttpOnly = true,
            });

            return Ok(new { message = "success" });
        }

        [HttpGet("user")]
        public IActionResult User()
        {
            try
            {
                var jwt = Request.Cookies["jwtt"];

                var token = _jwtService.Verify(jwt);
                int userId = int.Parse(token.Issuer);

                var user = _service.GetById(userId);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Unauthorized();
            }
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok(new { message = "Successful deleted" });
        }
    }
}
