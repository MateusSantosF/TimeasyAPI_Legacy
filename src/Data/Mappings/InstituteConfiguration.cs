using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeasyAPI.src.Models;

namespace TimeasyAPI.src.Data.Mappings
{
    public class InstituteConfiguration : IEntityTypeConfiguration<Institute>
    {
        public void Configure(EntityTypeBuilder<Institute> builder)
        {

            builder
                .HasMany(i => i.Courses)
                .WithOne(c => c.Institute)
                .HasForeignKey(c => c.InstituteId);

            builder
               .HasMany(i => i.Users)
               .WithOne(u => u.Institute)
               .HasForeignKey(c => c.InstituteId);

            builder
              .HasMany(i => i.Teachers)
              .WithOne(t => t.Institute)
              .HasForeignKey(c => c.InstituteId);

            builder
              .HasMany(i => i.Timetables)
              .WithOne(t => t.Institute)
              .HasForeignKey(c => c.InstituteId);
        }
    }
}
