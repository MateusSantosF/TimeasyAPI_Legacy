using System.ComponentModel.DataAnnotations;

namespace TimeasyAPI.src.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public bool Active { get; set; } = true;    
        
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
