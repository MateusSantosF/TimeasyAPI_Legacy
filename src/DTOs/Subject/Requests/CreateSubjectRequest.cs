using System.ComponentModel.DataAnnotations;

namespace TimeasyAPI.src.DTOs.Subject.Requests
{
    public class CreateSubjectRequest
    {
        [Required(ErrorMessage = "Acronym is required.")]
        [MaxLength(10, ErrorMessage = "Acronym must be at most 10 characters.")]
        public string Acronym { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name must be at most 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Complexity is required.")]
        public string Complexity { get; set; }

        [Required(ErrorMessage = "RoomType is required.")]
        public Guid RoomTypeId { get; set; }
    }
}
