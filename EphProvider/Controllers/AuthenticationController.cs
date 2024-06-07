using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EphProvider.Models;
using EphProvider.Services;
using EphProvider.Helpers;

namespace EphProvider.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtHelper _jwtHelper;

        public AuthenticationController(IUserService userService, JwtHelper jwtHelper)
        {
            _userService = userService;
            _jwtHelper = jwtHelper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            var user = await _userService.AuthenticateAsync(model.Username, model.Password);
            if (user == null)
                return Unauthorized();

            var token = _jwtHelper.GenerateJwtToken(user);

            return Ok(new { token });
        }
    }
}
