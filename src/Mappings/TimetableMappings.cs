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
                    TimetableId = newTimetable.Id
                };
            });

            //var timetableRooms = timetable.Rooms.Select(roomId =>
            //{
            //    return new Room
            //    {
            //        Id = roomId
            //    };
            //});

            //newTimetable.Rooms.AddRange(timetableRooms);
            newTimetable.TimetableSubjects.AddRange(timetableSubjects);
            newTimetable.TimetableCourses.AddRange(timetableCourses);

            return newTimetable;
        }

        public static TimetableDTO EntitieToMap(this Timetable timetable)
        {

            var courses = timetable.TimetableCourses.Select(c =>
            {
                return new TimetableCourseDTO
                {
                    CourseId = c.CourseId,
                    CourseOperatingDays = new WeekdayAvailability
                    {
                        Monday = c.Monday,
                        Tuesday = c.Tuesday,
                        Wednesday = c.Wednesday,
                        Thursday = c.Thursday,
                        Friday = c.Friday,
                        Saturday = c.Saturday,
                    }
                };
            });

            var rooms = timetable.Rooms.Select(room =>
            {
                return room.Id;
            });

            var subjects = timetable.TimetableSubjects.Select(s =>
            {
                return new TimetableSubjectDTO
                {
                    SubjectId = s.SubjectId,
                    CourseId = s.CourseId,
                };
            });

            return new TimetableDTO
            {
                Id = timetable.Id,
                Name = timetable.Name,
                Status = timetable.Status,
                EndedAt = timetable.EndedAt.HasValue ? timetable.EndedAt.Value : null,
                CreateAt = timetable.CreateAt,
                Courses = courses,
                Subjects = subjects,
            };
        }

    }
}
