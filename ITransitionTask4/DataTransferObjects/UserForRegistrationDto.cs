using System.ComponentModel.DataAnnotations;

namespace ITransitionTask4.DataTransferObjects
{
    public record UserForRegistrationDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }

        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; init; }
    }
}
