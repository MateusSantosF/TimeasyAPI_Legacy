using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeasyAPI.src.Models;

namespace TimeasyAPI.src.Data.ConfigurationMappings
{
    public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
    {
        public void Configure(EntityTypeBuilder<RoomType> builder)
        {
             builder.HasKey( rt => rt.Id );

            builder.Property(rt => rt.OperationalSystem).IsRequired(false);
        }
    }
}
