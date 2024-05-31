using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using REST.APIs.Models.DTOs;
using System.Linq;
using System.Threading.Tasks;

namespace REST.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequestDto registerUserRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var identityUser = new IdentityUser
            {
                UserName = registerUserRequestDto.Username,
                Email = registerUserRequestDto.Username
            };

            var identityUserResult = await _userManager.CreateAsync(identityUser, registerUserRequestDto.Password);

            if (identityUserResult.Succeeded)
            {
                if (registerUserRequestDto.Roles != null && registerUserRequestDto.Roles.Any())
                {
                    foreach (var role in registerUserRequestDto.Roles)
                    {
                        await _userManager.AddToRoleAsync(identityUser, role);
                    }
                }

                return Ok("User registered successfully");
            }
            else
            {
                return BadRequest(identityUserResult.Errors);
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequestDto loginUserRequestDto)
        {
            var user = await _userManager.FindByEmailAsync(loginUserRequestDto.Username);

            if (user != null)
            {
                var loginResult = await _userManager.CheckPasswordAsync(user, loginUserRequestDto.Password);

                if (loginResult)
                {
                    // Generate token
                    return Ok("Login successful"); 
                }
            }

            return BadRequest("Invalid login attempt");
        }
    }
}
