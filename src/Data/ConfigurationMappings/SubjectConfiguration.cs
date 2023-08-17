using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeasyAPI.src.Models;

namespace TimeasyAPI.src.Data.Mappings
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder
                .HasOne(s => s.RoomTypeNeeded)
                .WithMany(rt => rt.Subjects)
                .HasForeignKey(s => s.RoomTypeId);

            builder.HasIndex(s => s.Name).IsUnique();
        }
    }
}
