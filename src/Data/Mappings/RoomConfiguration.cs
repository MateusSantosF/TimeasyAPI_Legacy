using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeasyAPI.src.Models;

namespace TimeasyAPI.src.Data.Mappings
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder
                .HasOne(r => r.Type)
                .WithMany(t => t.Rooms)
                .HasForeignKey( r=> r.RoomTypeId);

            builder
                .HasMany(r => r.Timetables)
                .WithMany(t => t.Rooms);
        }
    }
}
