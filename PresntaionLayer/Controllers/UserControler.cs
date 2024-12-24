using BuissnesLogic.DTO;
using BuissnesLogic.ServiceIntrface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresntaionLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserControler : ControllerBase
    {
        private readonly IUserService _userService;

        public UserControler(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AddUserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.RegisterAsync(userDto);
            return Ok(new { message = result });
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.LoginAsync(loginDto.PhoneNumber, loginDto.Password);
            if (result == null)
                return Unauthorized(new { message = "Invalid phonenumber or password" });

            return Ok(new { token = result });
        }

       
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] AddUserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userService.AddUserAsync(userDto);
            return Ok(new { message = "User added successfully" });
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound(new { message = "User not found" });

            return Ok(user);
        }

        [Authorize]
        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            if (user == null)
                return NotFound(new { message = "User not found" });

            return Ok(user);
        }

        // Update user
        /*  [HttpPut("{id}")]
          public async Task<IActionResult> UpdateUser(int id, [FromBody] AddUserDto userDto)
          {
              if (!ModelState.IsValid)
                  return BadRequest(ModelState);

              userDto.Id = id; // Ensure the ID matches the request
              await _userService.UpdateUserAsync(userDto);
              return Ok(new { message = "User updated successfully" });
          }*/

       [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok(new { message = "User deleted successfully" });
        }
    }
}
