using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeasyAPI.src.Models.ValueObjects;

namespace TimeasyAPI.src.Data.ConfigurationMappings
{
    public class FpaSubjectConfiguration : IEntityTypeConfiguration<FpaSubjects>
    {
        public void Configure(EntityTypeBuilder<FpaSubjects> builder)
        {
            builder.HasKey(x => new { x.SubjectId, x.CourseId});
        }
    }
}
