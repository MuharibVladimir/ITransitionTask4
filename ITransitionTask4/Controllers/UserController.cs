using ITransitionTask4.DataTransferObjects;
using ITransitionTask4.Entities.Models;
using ITransitionTask4.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using System.Xml.Linq;

namespace ITransitionTask4.Controllers
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _service;
        public UserController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = HttpContext.User.FindFirstValue("id");
            var users = await _service.UserService.GetAllUsersAsync(trackChanges: false);

            return Ok(users);
        }

        [HttpDelete("{userId}", Name = "DeleteUsers")]
        public async Task<IActionResult> DeleteUsers([FromBody] IEnumerable<string> userIds, string userId)
        {
            await _service.UserService.DeleteUsersAsync(userIds);

            if (userIds.Contains(userId))
            {
                return StatusCode(403);
            }

            return Ok();
        }

        [HttpPost("{userId}",Name = "BlockUsers")]
        public async Task<IActionResult> BlockUsers([FromBody] IEnumerable<string> userIds, string userId)
        {
            await _service.UserService.BlockUsersAsync(userIds);

            if (userIds.Contains(userId))
            {
                return StatusCode(403);
            }

            return Ok();
        }

        [HttpPost("blocked", Name = "UnBlockUsers")]
        public async Task<IActionResult> UnblockUsers([FromBody] IEnumerable<string> userIds)
        {
            await _service.UserService.UnBlockUsersAsync(userIds);

            return Ok();
        }
    }
}
