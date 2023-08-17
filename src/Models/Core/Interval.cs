using System.ComponentModel.DataAnnotations;

namespace TimeasyAPI.src.Models
{
    public class Interval : BaseEntity
    {
        public string Start { get; set; }
        public string End { get; set; }

        // EF Relations

        public Guid InstituteId { get; set; }
        public Institute Institute { get; set; }
        public ICollection<FPA> FPAs { get; set; }
    }
}
