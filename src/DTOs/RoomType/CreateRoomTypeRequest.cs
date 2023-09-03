using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TimeasyAPI.src.Models.ValueObjects.Enums;
using TimeasyAPI.src.Validators;

namespace TimeasyAPI.src.DTOs.RoomType
{
    public class CreateRoomTypeRequest
    {

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name must be at most 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "IsComputerLab is required.")]
        public bool IsComputerLab { get; set; }

        [OperationalSystem(ErrorMessage = "Invalid OperationalSystem name")]
        public OperationalSystem? OperationalSystem { get; set; }
    }
}
