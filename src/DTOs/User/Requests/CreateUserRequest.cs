using System.ComponentModel.DataAnnotations;

namespace TimeasyAPI.src.DTOs.User
{
    public class CreateUserRequest
    {

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "FullName must be at most 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [MaxLength(100, ErrorMessage = "Email must be at most 100 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "InstituteName is required.")]
        [MaxLength(100, ErrorMessage = "InstituteName must be at most 100 characters.")]
        public string InstituteName { get; set; }

        [RegularExpression("^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "OpenHour must be in HH:mm format.")]
        public string OpenHour { get; set; }

        [RegularExpression("^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "CloseHour must be in HH:mm format.")]
        public string CloseHour { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
    }
}
