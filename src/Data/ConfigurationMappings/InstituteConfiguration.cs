using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeasyAPI.src.Models;

namespace TimeasyAPI.src.Data.Mappings
{
    public class InstituteConfiguration : IEntityTypeConfiguration<Institute>
    {
        public void Configure(EntityTypeBuilder<Institute> builder)
        {
            builder.HasMany(i => i.Intervals)
                .WithOne(i => i.Institute)
                .HasForeignKey(i => i.InstituteId); 
          
        }
    }
}
