﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeasyAPI.src.Data;

#nullable disable

namespace TimeasyAPI.src.Data.Migrations
{
    [DbContext(typeof(TimeasyDbContext))]
    [Migration("20231001173346_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RoomTimetable", b =>
                {
                    b.Property<Guid>("RoomsId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TimetablesId")
                        .HasColumnType("char(36)");

                    b.HasKey("RoomsId", "TimetablesId");

                    b.HasIndex("TimetablesId");

                    b.ToTable("RoomTimetable");
                });

            modelBuilder.Entity("TeacherTimetable", b =>
                {
                    b.Property<Guid>("TeachersId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TimetablesId")
                        .HasColumnType("char(36)");

                    b.HasKey("TeachersId", "TimetablesId");

                    b.HasIndex("TimetablesId");

                    b.ToTable("TeacherTimetable");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.Core.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("End")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("FPAId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Start")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("FPAId");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.Core.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<uint>("AcessLevel")
                        .HasColumnType("int unsigned");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("InstituteId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("InstituteId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("InstituteId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<uint>("Period")
                        .HasColumnType("int unsigned");

                    b.Property<int>("PeriodAmount")
                        .HasColumnType("int");

                    b.Property<uint>("Turn")
                        .HasColumnType("int unsigned");

                    b.HasKey("Id");

                    b.HasIndex("InstituteId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.FPA", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<uint>("Status")
                        .HasColumnType("int unsigned");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TimetableId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.HasIndex("TimetableId");

                    b.ToTable("FPA");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.Institute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("CloseHour")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Friday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Monday")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OpenHour")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Saturday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Thursday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Tuesday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Wednesday")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Institute");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.Interval", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("End")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("InstituteId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Start")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("InstituteId");

                    b.ToTable("Interval");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Block")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid?>("RoomTypeId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.RoomType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsComputerLab")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<uint?>("OperationalSystem")
                        .HasColumnType("int unsigned");

                    b.HasKey("Id");

                    b.ToTable("RoomType");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Acronym")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<uint>("Complexity")
                        .HasColumnType("int unsigned");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("RoomTypeId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<uint>("AcademicDegree")
                        .HasColumnType("int unsigned");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("CampusServiceTime")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("IfspServiceTime")
                        .HasColumnType("date");

                    b.Property<Guid>("InstituteId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Registration")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TeachingHours")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InstituteId");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.Timetable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateOnly>("CreateAt")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("EndedAt")
                        .HasColumnType("date");

                    b.Property<Guid>("InstituteId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<uint>("Status")
                        .HasColumnType("int unsigned");

                    b.HasKey("Id");

                    b.HasIndex("InstituteId");

                    b.ToTable("Timetable");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.ValueObjects.CourseSubject", b =>
                {
                    b.Property<Guid>("CourseId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.Property<int>("WeeklyClassCount")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("CourseSubject");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.ValueObjects.FpaSubjects", b =>
                {
                    b.Property<Guid>("SubjectId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("FPAId")
                        .HasColumnType("char(36)");

                    b.HasKey("SubjectId", "CourseId");

                    b.HasIndex("CourseId");

                    b.HasIndex("FPAId");

                    b.ToTable("FpaSubjects");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.ValueObjects.TimetableCourses", b =>
                {
                    b.Property<Guid>("CourseId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TimetableId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("Friday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Monday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Saturday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Thursday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Tuesday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Wednesday")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("CourseId", "TimetableId");

                    b.HasIndex("TimetableId");

                    b.ToTable("TimetableCourses");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.ValueObjects.TimetableSubjects", b =>
                {
                    b.Property<Guid>("SubjectId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TimetableId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("char(36)");

                    b.Property<int>("DividedCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsDivided")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("StudentsCount")
                        .HasColumnType("int");

                    b.HasKey("SubjectId", "TimetableId");

                    b.HasIndex("CourseId");

                    b.HasIndex("TimetableId");

                    b.ToTable("TimetableSubjects");
                });

            modelBuilder.Entity("RoomTimetable", b =>
                {
                    b.HasOne("TimeasyAPI.src.Models.Room", null)
                        .WithMany()
                        .HasForeignKey("RoomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimeasyAPI.src.Models.Timetable", null)
                        .WithMany()
                        .HasForeignKey("TimetablesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TeacherTimetable", b =>
                {
                    b.HasOne("TimeasyAPI.src.Models.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimeasyAPI.src.Models.Timetable", null)
                        .WithMany()
                        .HasForeignKey("TimetablesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.Core.Schedule", b =>
                {
                    b.HasOne("TimeasyAPI.src.Models.FPA", "FPA")
                        .WithMany("Schedules")
                        .HasForeignKey("FPAId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FPA");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.Core.User", b =>
                {
                    b.HasOne("TimeasyAPI.src.Models.Institute", "Institute")
                        .WithMany("Users")
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institute");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.Course", b =>
                {
                    b.HasOne("TimeasyAPI.src.Models.Institute", "Institute")
                        .WithMany("Courses")
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institute");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.FPA", b =>
                {
                    b.HasOne("TimeasyAPI.src.Models.Teacher", "Teacher")
                        .WithMany("FPA")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimeasyAPI.src.Models.Timetable", "Timetable")
                        .WithMany("FPAs")
                        .HasForeignKey("TimetableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");

                    b.Navigation("Timetable");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.Interval", b =>
                {
                    b.HasOne("TimeasyAPI.src.Models.Institute", "Institute")
                        .WithMany("Intervals")
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institute");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.Room", b =>
                {
                    b.HasOne("TimeasyAPI.src.Models.RoomType", "Type")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeId");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.Subject", b =>
                {
                    b.HasOne("TimeasyAPI.src.Models.RoomType", "RoomTypeNeeded")
                        .WithMany("Subjects")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoomTypeNeeded");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.Teacher", b =>
                {
                    b.HasOne("TimeasyAPI.src.Models.Institute", "Institute")
                        .WithMany("Teachers")
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institute");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.Timetable", b =>
                {
                    b.HasOne("TimeasyAPI.src.Models.Institute", "Institute")
                        .WithMany("Timetables")
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institute");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.ValueObjects.CourseSubject", b =>
                {
                    b.HasOne("TimeasyAPI.src.Models.Course", "Course")
                        .WithMany("CourseSubject")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimeasyAPI.src.Models.Subject", "Subject")
                        .WithMany("CourseSubject")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.ValueObjects.FpaSubjects", b =>
                {
                    b.HasOne("TimeasyAPI.src.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimeasyAPI.src.Models.FPA", null)
                        .WithMany("Subjects")
                        .HasForeignKey("FPAId");

                    b.HasOne("TimeasyAPI.src.Models.Subject", "Subject")
                        .WithMany("Subjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.ValueObjects.TimetableCourses", b =>
                {
                    b.HasOne("TimeasyAPI.src.Models.Course", "Course")
                        .WithMany("TimetableCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimeasyAPI.src.Models.Timetable", "Timetable")
                        .WithMany("TimetableCourses")
                        .HasForeignKey("TimetableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Timetable");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.ValueObjects.TimetableSubjects", b =>
                {
                    b.HasOne("TimeasyAPI.src.Models.Course", "Course")
                        .WithMany("TimetableSubjects")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimeasyAPI.src.Models.Subject", "Subject")
                        .WithMany("TimetableSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimeasyAPI.src.Models.Timetable", "Timetable")
                        .WithMany("TimetableSubjects")
                        .HasForeignKey("TimetableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Subject");

                    b.Navigation("Timetable");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.Course", b =>
                {
                    b.Navigation("CourseSubject");

                    b.Navigation("TimetableCourses");

                    b.Navigation("TimetableSubjects");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.FPA", b =>
                {
                    b.Navigation("Schedules");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.Institute", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Intervals");

                    b.Navigation("Teachers");

                    b.Navigation("Timetables");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.RoomType", b =>
                {
                    b.Navigation("Rooms");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.Subject", b =>
                {
                    b.Navigation("CourseSubject");

                    b.Navigation("Subjects");

                    b.Navigation("TimetableSubjects");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.Teacher", b =>
                {
                    b.Navigation("FPA");
                });

            modelBuilder.Entity("TimeasyAPI.src.Models.Timetable", b =>
                {
                    b.Navigation("FPAs");

                    b.Navigation("TimetableCourses");

                    b.Navigation("TimetableSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}