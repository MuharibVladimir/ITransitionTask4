using ITransitionTask4.Entities.Models;
using ITransitionTask4.Middlewares;
using Microsoft.AspNetCore.Identity;
using System.Reflection.PortableExecutable;

namespace ITransitionTask4.Extensions
{
    public static class UserStatusMiddlewareExtensions
    {
        public static IApplicationBuilder UseUserStatusMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserStatusMiddleware>();

        }
    }
}
