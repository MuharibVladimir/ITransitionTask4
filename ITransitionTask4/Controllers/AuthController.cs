using ITransitionTask4.DataTransferObjects;
using ITransitionTask4.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ITransitionTask4.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IServiceManager _service;
        public AuthController(IServiceManager service) => _service = service;

        [HttpPost("registration")]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto
            userForRegistration)
        {
            var result = await _service.AuthService.RegisterUser(userForRegistration);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _service.AuthService.ValidateUser(user))
                return Unauthorized();

            var tokenDto = await _service.AuthService.CreateToken(populateExp: true);

            return Ok(tokenDto);
        }

    }
}
