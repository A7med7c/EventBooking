
using EventBooking.Domain.Dtos;
using EventBooking.Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace EventBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserRepository userRepository) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await userRepository.RegisterAsync(registerDto);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);
         
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await userRepository.LoginAsync(loginDto);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost("addrole")]
        public async Task<ActionResult<string>> AddRoleToUser([FromBody]AddRoleDto addRoleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await userRepository.AddRoleAsync(addRoleDto);

            if (!string.IsNullOrEmpty(result))
                return BadRequest();

            return Ok(addRoleDto);
        }
    }
}
