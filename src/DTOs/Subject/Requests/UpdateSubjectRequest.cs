using System.ComponentModel.DataAnnotations;
using TimeasyAPI.src.Models.ValueObjects.Enums;

namespace TimeasyAPI.src.DTOs.Subject.Requests
{
    public class UpdateSubjectRequest
    {
        [Required(ErrorMessage = "Id is required")]
        public string Id { get; set; }
        
        [MaxLength(10, ErrorMessage = "Acronym must be at most 10 characters.")]
        public string? Acronym { get; set; }

      
        [MaxLength(100, ErrorMessage = "Name must be at most 100 characters.")]
        public string? Name { get; set; }

        public string? Complexity { get; set; }

        public string? RoomTypeId { get; set; }
    }
}
