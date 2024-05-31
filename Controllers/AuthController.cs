using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using REST.APIs.Models.DTOs;
using System.Threading.Tasks;

namespace REST.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(UserManager<IdentityUser> userManager) : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager = userManager;

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

            var identityUserResult = await _userManager.CreateAsync(identityUser, 
                registerUserRequestDto.Password);

            if (identityUserResult.Succeeded)
            {


                foreach (var role in registerUserRequestDto.Roles)
                {
                    await _userManager.AddToRoleAsync(identityUser, role);
                }
                return Ok("User registered successfully"); 
            }
            else
            {
                return BadRequest(identityUserResult.Errors);
            }
        }
    }
}
