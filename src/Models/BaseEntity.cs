using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeasyAPI.src.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [DefaultValue(true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public bool Active { get; set; }    
        
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
