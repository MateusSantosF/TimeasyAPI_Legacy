using TimeasyAPI.src.DTOs.Teacher;
using TimeasyAPI.src.DTOs.Teacher.Requests;
using TimeasyAPI.src.Models;
using TimeasyAPI.src.Models.ValueObjects.Enums;

namespace TimeasyAPI.src.Mappings
{
    public static class TeacherMappings
    {
        public static Teacher MapToEntitie(this CreateTeacherRequest teacher)
        {
            return new Teacher
            {
                FullName = teacher.FullName,
                Registration = teacher.Registration,
                Email = teacher.Email,
                AcademicDegree = Enum.Parse<AcademicDegree>(teacher.AcademicDegree, true),
                BirthDate = teacher.BirthDate, 
                TeachingHours = teacher.TeachingHours,
                IfspServiceTime = teacher.IfspServiceTime,
                CampusServiceTime = teacher.CampusServiceTime
            };
        }
        public static TeacherDTO EntitieToMap(this Teacher teacher)
        {
            return new TeacherDTO
            {
                Id = teacher.Id.ToString(),
                InstituteId = teacher.InstituteId.ToString(),
                FullName = teacher.FullName,
                Registration = teacher.Registration,
                Email = teacher.Email,
                AcademicDegree = teacher.AcademicDegree.ToString(),
                BirthDate = teacher.BirthDate,
                TeachingHours = teacher.TeachingHours,
                IfspServiceTime = teacher.IfspServiceTime,
                CampusServiceTime = teacher.CampusServiceTime
            };
        }
    }
}
