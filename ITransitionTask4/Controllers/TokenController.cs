using ITransitionTask4.DataTransferObjects;
using ITransitionTask4.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ITransitionTask4.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IServiceManager _service;
        public TokenController(IServiceManager service) => _service = service;

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
        {
            var tokenDtoToReturn = await _service.AuthService.RefreshToken(tokenDto);

            return Ok(tokenDtoToReturn);
        }
    }
}
