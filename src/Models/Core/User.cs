using System.ComponentModel.DataAnnotations;
using TimeasyAPI.src.Models.ValueObjects.Enums;

namespace TimeasyAPI.src.Models.Core
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "FullName is required.")]
        [MaxLength(100, ErrorMessage = "FullName must be at most 100 characters.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [MaxLength(100, ErrorMessage = "Email must be at most 100 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "AcessLevel is required.")]
        public AcessLevel AcessLevel { get; set; }


        // EF Relations

        public Guid InstituteId { get; set; }
        public Institute Institute { get; set; }
    }
}
