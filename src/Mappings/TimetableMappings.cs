﻿using TimeasyAPI.src.DTOs.Course.CourseSubject;
using TimeasyAPI.src.DTOs.Courses;
using TimeasyAPI.src.DTOs.Timetable;
using TimeasyAPI.src.DTOs.Timetable.Requests;
using TimeasyAPI.src.Models;
using TimeasyAPI.src.Models.ValueObjects;

namespace TimeasyAPI.src.Mappings
{
    public static class TimetableMappings
    {


        public static Timetable MapToEntitie(this CreateTimetableRequest timetable)
        {
            var newTimetable = new Timetable
            {
                Name = timetable.Name,

            };

            var timetableCourses = timetable.Courses.Select(c =>
            {
                return new TimetableCourses
                {
                    CourseId = c.CourseId,
                    TimetableId = newTimetable.Id,
                    Monday = c.CourseOperatingDays.Monday,
                    Tuesday = c.CourseOperatingDays.Tuesday,
                    Wednesday = c.CourseOperatingDays.Wednesday,
                    Thursday = c.CourseOperatingDays.Thursday,
                    Friday = c.CourseOperatingDays.Friday,
                    Saturday = c.CourseOperatingDays.Saturday,
                };
            });

            var timetableSubjects = timetable.Subjects.Select( s =>
            {
                return new TimetableSubjects
                {
                    StudentsCount = s.StudentsCount,
                    SubjectId = s.SubjectId,
                    TimetableId = newTimetable.Id,
                    CourseId = s.CourseId
                    
                };
            });

            var timetablerooms = timetable.Rooms.Select(roomid =>
            {
                return new Room
                {
                    Id = roomid
                };
            });

            var timetableTeachers = timetable.Teachers.Select(teacherId =>
            {
                return new Teacher
                {
                    Id = teacherId,
                  
                };
            });

            newTimetable.Rooms.AddRange(timetablerooms);
            newTimetable.Teachers.AddRange(timetableTeachers);
            newTimetable.TimetableSubjects.AddRange(timetableSubjects);
            newTimetable.TimetableCourses.AddRange(timetableCourses);

            return newTimetable;
        }

        public static TimetableDTO EntitieToMap(this Timetable timetable)
        {
            return new TimetableDTO
            {
                Id = timetable.Id,
                Name = timetable.Name,
                Status = timetable.Status,
                EndedAt = timetable.EndedAt.HasValue ? timetable.EndedAt.Value : null,
                CreateAt = timetable.CreateAt
            };
        }

        public static GetTimetableCourseWithSubjectsDTO EntitieToMapWithSubjects(this TimetableCourses timetableCourse)
        {

            var Subjects = timetableCourse.Course.TimetableSubjects.Select(subject =>
            {
                return new GetTimetableSubject
                {
                    Id = subject.SubjectId,
                    Name = subject.Subject.Name,
                    StudentsCount = subject.StudentsCount,
                    IsDivided = subject.IsDivided,
                    DividedCount = subject.DividedCount
                };
            }).ToList();

            return new GetTimetableCourseWithSubjectsDTO
            {
                Id = timetableCourse.Course.Id,
                Name = timetableCourse.Course.Name,
                Period = timetableCourse.Course.Period,
                Turn = timetableCourse.Course.Turn,
                PeriodAmount = timetableCourse.Course.PeriodAmount,
                Subjects = Subjects
            };
        }

    }
}
