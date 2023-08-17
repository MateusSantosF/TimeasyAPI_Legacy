using System.ComponentModel.DataAnnotations;

namespace TimeasyAPI.src.DTOs.Institute.Request
{
    public class UpdateInstituteRequest
    {
        [Required(ErrorMessage = "InstituteId is required.")]
        public string InstituteId { get; set; } 

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
