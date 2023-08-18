using System.ComponentModel.DataAnnotations;
using TimeasyAPI.src.Validators;

namespace TimeasyAPI.src.DTOs.RoomType
{
    public class UpdateRoomTypeRequest
    {

        [Required]
        public string Id { get; set; }

        [MaxLength(100, ErrorMessage = "Name must be at most 100 characters.")]
        public string? Name { get; set; }
        public bool ?IsComputerLab { get; set; }

        [OperationalSystem(ErrorMessage = "Invalid OperationalSystem name")]
        public string? OperationalSystem { get; set; }
    }
}
