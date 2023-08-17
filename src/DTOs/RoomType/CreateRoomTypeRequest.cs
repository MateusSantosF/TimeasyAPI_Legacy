using System.ComponentModel.DataAnnotations;
using TimeasyAPI.src.Validators;

namespace TimeasyAPI.src.DTOs.RoomType
{
    public class CreateRoomTypeRequest
    {

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name must be at most 100 characters.")]
        public string Name { get; set; }

        public bool IsComputerLab { get; set; }


        [OperationalSystem(ErrorMessage = "Invalid OperationalSystem name")]
        public string OperationalSystem { get; set; }
    }
}
