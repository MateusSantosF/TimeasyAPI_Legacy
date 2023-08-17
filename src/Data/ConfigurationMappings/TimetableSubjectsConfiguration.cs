﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeasyAPI.src.Models.ValueObjects;

namespace TimeasyAPI.src.Data.Mappings
{
    public class TimetableSubjectsConfiguration : IEntityTypeConfiguration<TimetableSubjects>
    {
        public void Configure(EntityTypeBuilder<TimetableSubjects> builder)
        {
            builder.HasKey(t => new { t.SubjectId, t.TimetableId });

            builder
                .HasOne(s => s.Subject)
                .WithMany(tc => tc.TimetableSubjects)
                .HasForeignKey(s => s.SubjectId);

            builder
                .HasOne(t => t.Timetable)
                .WithMany(tc => tc.TimetableSubjects)
                .HasForeignKey(t => t.TimetableId);
        }
    }
}