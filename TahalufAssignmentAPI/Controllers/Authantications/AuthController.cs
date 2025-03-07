using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        //Login.=
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
        [HttpPost("VerifyOTP")]
        
        public async Task<IActionResult> VerifyOTP(VerificationInputDTO input)
        {
            try
            {
                var response = await _authantication.VerifyOTP(input);
                return response.Equals("Authantication Failed") ? Unauthorized("Verification Is Not Correct") : Ok(response);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //Logout
        [HttpPut("Logout")]
        public async Task<IActionResult> Logout([FromRoute] int input)
        {
            try
            {
                var response = await _authantication.Logout(input);
                return response ? Ok("Logout Successfully") : Unauthorized("Person Id Is Not Correct");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
