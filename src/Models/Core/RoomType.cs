using System.ComponentModel.DataAnnotations;
using TimeasyAPI.src.Models.ValueObjects.Enums;

namespace TimeasyAPI.src.Models
{
    public class RoomType: BaseEntity
    {

        public string Name { get; set; }

        public bool IsComputerLab { get; set; }

        public OperationalSystem? OperationalSystem { get; set; }

        // EF Relations
        public ICollection<Subject> Subjects { get; set; }

        public ICollection<Room> Rooms { get; set;}
    }
}
