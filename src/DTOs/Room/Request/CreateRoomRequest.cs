using System.ComponentModel.DataAnnotations;

namespace TimeasyAPI.src.DTOs.Room.Request
{
    public class CreateRoomRequest
    {

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name must be at most 100 characters.")]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessage = "Block must be at most 50 characters.")]
        public string Block { get; set; }

        [Required(ErrorMessage = "Capacity is required.")]
        [Range(1, 1000, ErrorMessage = "Capacity must be greater than 0.")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        public Guid TypeId { get; set; }

    }
}
