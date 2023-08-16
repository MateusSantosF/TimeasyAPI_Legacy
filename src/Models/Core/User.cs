using System.ComponentModel.DataAnnotations;
using TimeasyAPI.src.Models.ValueObjects.Enums;

namespace TimeasyAPI.src.Models.Core
{
    public class User : BaseEntity
    {

        public string FullName { get; set; }

        public string Email { get; set; }


        public string Password { get; set; }


        public AcessLevel AcessLevel { get; set; }


        // EF Relations

        public Guid InstituteId { get; set; }
        public Institute Institute { get; set; }
    }
}
