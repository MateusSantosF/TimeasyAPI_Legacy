using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeasyAPI.src.Models.ValueObjects;

namespace TimeasyAPI.src.Data.Mappings
{
    public class CourseSubjectConfiguration : IEntityTypeConfiguration<CourseSubject>
    {
        public void Configure(EntityTypeBuilder<CourseSubject> builder)
        {
            builder.HasKey(cs => new { cs.CourseId, cs.SubjectId });
  
            builder
                .HasOne(s => s.Subject)
                .WithMany(tc => tc.CourseSubject)
                .HasForeignKey(s => s.SubjectId);

            builder
               .HasOne(s => s.Course)
               .WithMany(tc => tc.CourseSubject)
               .HasForeignKey(s => s.CourseId);
        }
    }
}
