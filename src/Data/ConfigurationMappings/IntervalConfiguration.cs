using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeasyAPI.src.Models;

namespace TimeasyAPI.src.Data.Mappings
{
    public class IntervalConfiguration : IEntityTypeConfiguration<Interval>
    {
        public void Configure(EntityTypeBuilder<Interval> builder)
        {

            builder
                .HasOne(i => i.Institute)
                .WithMany(i => i.Intervals)
                .HasForeignKey(i => i.InstituteId);
           
        }
    }
}
