using TimeasyAPI.Controllers.Middlewares.Exceptions;
using TimeasyAPI.src.DTOs.Teacher;
using TimeasyAPI.src.DTOs.Teacher.Requests;
using TimeasyAPI.src.Helpers;
using TimeasyAPI.src.Models;
using TimeasyAPI.src.Models.ValueObjects.Enums;

namespace TimeasyAPI.src.Mappings
{
    public static class TeacherMappings
    {
        public static Teacher MapToEntitie(this CreateTeacherRequest teacher)
        {
            if (!Enum.TryParse(teacher.AcademicDegree, true, out AcademicDegree result))
            {
                throw new AppException("Error convert academic Degree.");
            }

            var birthDate = teacher.BirthDate.TryParseToBrLocateDate();
            var ifspServiceTime = teacher.IfspServiceTime.TryParseToBrLocateDate();
            var campusServiceTime = teacher.CampusServiceTime.TryParseToBrLocateDate();

            return new Teacher
            {
                FullName = teacher.FullName,
                Registration = teacher.Registration,
                Email = teacher.Email,
                AcademicDegree = result,
                BirthDate = birthDate, 
                TeachingHours = teacher.TeachingHours,
                IfspServiceTime = ifspServiceTime,
                CampusServiceTime = campusServiceTime
            };
        }
        public static TeacherDTO EntitieToMap(this Teacher teacher)
        {
            return new TeacherDTO
            {
                Id = teacher.Id,
                InstituteId = teacher.InstituteId,
                FullName = teacher.FullName,
                Registration = teacher.Registration,
                Email = teacher.Email,
                AcademicDegree = teacher.AcademicDegree,
                BirthDate = teacher.BirthDate.ToString("dd/MM/yyyy"),
                TeachingHours = teacher.TeachingHours,
                IfspServiceTime = teacher.IfspServiceTime.ToString("dd/MM/yyyy"),
                CampusServiceTime = teacher.CampusServiceTime.ToString("dd/MM/yyyy")
            };
        }
    }
}
