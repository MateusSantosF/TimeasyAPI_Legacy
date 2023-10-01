using System.ComponentModel.DataAnnotations;

namespace TimeasyAPI.src.Models
{
    public class Interval : BaseEntity
    {
        public string Start { get; set; }
        public string End { get; set; }

        // EF Relations

     
        public Institute Institute { get; set; }

        public Guid InstituteId { get; set; }
    }
}
