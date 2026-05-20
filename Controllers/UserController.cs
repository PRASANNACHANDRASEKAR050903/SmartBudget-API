using Microsoft.AspNetCore.Mvc;
using SmartBudget.API.Models;
using SmartBudget.API.Repository;

namespace SmartBudget.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _repository;

        public UserController(UserRepository repository)
        {
            _repository = repository;
        }

        // REGISTER
        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            var result = _repository.Register(user);

            if (result)
                return Ok(new { message = "User Registered Successfully" });

            return BadRequest(new { message = "Registration Failed" });
        }

        // LOGIN
        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            var result = _repository.Login(user);

            if (result)
                return Ok(new { message = "Login Successful" });

            return Unauthorized(new { message = "Invalid Email or Password" });
        }
    }
}