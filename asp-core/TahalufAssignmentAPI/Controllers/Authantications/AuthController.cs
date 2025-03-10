using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TahalufAssignmentCore.Attributes;
using TahalufAssignmentCore.DTOs.Auths;
using TahalufAssignmentCore.Services;

namespace TahalufAssignmentAPI.Controllers.Authantications
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthanticationService _authantication;

        public AuthController(IAuthanticationService authantication)
        {
            _authantication = authantication;
        }
        [AllowAnonymous]
        [HttpPost("Register")]

        public async Task<IActionResult> Register([FromBody] SiteUserCreateDTO input)
        {
            try
            {
                var response = await _authantication.RegisterUser(input);
                return response.Equals("Authantication Failed") ? BadRequest("Failed Create Account") : Ok(response);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        
        public async Task<IActionResult> Auth([FromBody] LoginDTO input)
        {
            try
            {
                var response = await _authantication.Login(input);
                return response.Equals("Authantication Failed") ? Unauthorized("Email Or Password Is Not Correct") : Ok(response);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpPut("Logout/{Id}")]
        public async Task<IActionResult> Logout([FromRoute] int Id)
        {
            try
            {
                var response = await _authantication.Logout(Id);
                return response ? Ok("Logout Successfully") : Unauthorized("User Id Is Not Correct");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
