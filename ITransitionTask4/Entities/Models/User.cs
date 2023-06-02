using Microsoft.AspNetCore.Identity;

namespace ITransitionTask4.Entities.Models
{
    public class User : IdentityUser
    {
        public string? Name { get; set; }
        public DateTime? RegisterDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string? Status { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        //public int StatusId { get; set; }
        //public Status? Status { get; set; }
    }
}
