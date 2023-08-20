using TimeasyAPI.src.DTOs.Course.CourseSubject;
using TimeasyAPI.src.DTOs.Course.Requests;
using TimeasyAPI.src.DTOs.Courses;
using TimeasyAPI.src.Models;
using TimeasyAPI.src.Models.ValueObjects;

namespace TimeasyAPI.src.Mappings
{
    public static class CourseMappings
    {

        public static Course MapToEntitie(this CreateCourseRequest course)
        {    
            var newCourse =  new Course
            {
                Name = course.Name,
                Period = course.Period,
                Turn = course.Turn,
                PeriodAmount = course.PeriodAmount,
            };

            var courseSubjects = course.Subjects.Select(s =>
            {
                return new CourseSubject
                {
                    SubjectId = s.SubjectId,
                    CourseId = newCourse.Id,
                    Period = s.Period,
                    WeeklyClassCount = s.WeeklyClassCount
                };
            }).ToList();

            newCourse.CourseSubject.AddRange(courseSubjects);

            return newCourse;
        }

        public static CourseDTO EntitieToMap(this Course course)
        {

            var Subjects = course.CourseSubject.Select(s =>
            {
                return new CourseSubjectDTO
                {
                    SubjectId = s.SubjectId,
                    SubjectName = s.Subject != null ? s.Subject.Name : string.Empty,
                    WeeklyClassCount = s.WeeklyClassCount,
                    Period = s.Period
                };
            }).ToList();

            return new CourseDTO
            {
                Id = course.Id,
                Name = course.Name,
                Period = course.Period,
                Turn = course.Turn,
                PeriodAmount = course.PeriodAmount,
                Subjects = Subjects
            };
        }
    }
}
