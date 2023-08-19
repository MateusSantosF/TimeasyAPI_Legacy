using System.ComponentModel.DataAnnotations;

namespace TimeasyAPI.src.DTOs.Interval
{
    public class IntervalDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Start time is required.")]
        [RegularExpression("^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Start time must be in HH:mm format.")]
        public string Start { get; set; }

        [Required(ErrorMessage = "End time is required.")]
        [RegularExpression("^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "End time must be in HH:mm format.")]
        public string End { get; set; }
    }
}
