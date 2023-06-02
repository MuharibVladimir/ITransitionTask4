using ITransitionTask4.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

namespace ITransitionTask4.Middlewares
{
    public class UserStatusMiddleware: IMiddleware
    {
        //private readonly RequestDelegate _next;
        private readonly UserManager<User> _userManager;

        public UserStatusMiddleware(UserManager<User> userManager)
        {
            //_next = next;
            _userManager = userManager;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var userId = context.User.FindFirstValue("id");

            if (userId != null)
            {
                var userEntity = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

                if (userEntity == null || userEntity.Status.Equals("Blocked"))
                {
                    context.Response.StatusCode = 403;
                    return ;
                }
            }

            await next.Invoke(context);


        }
    }
}
