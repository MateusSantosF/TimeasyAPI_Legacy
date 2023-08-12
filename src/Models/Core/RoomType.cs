using System.ComponentModel.DataAnnotations;
using TimeasyAPI.src.Models.ValueObjects.Enums;

namespace TimeasyAPI.src.Models
{
    public class RoomType: BaseEntity
    {

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name must be at most 100 characters.")]
        public string Name { get; set; }

        public bool IsComputerLab { get; set; }

        [Required(ErrorMessage = "OperationalSystem is required.")]
        public OperationalSystem OperationalSystem { get; set; }

        // EF Relations
        public ICollection<Subject> Subjects { get; set; }

        public ICollection<Room> Rooms { get; set;}
    }
}
