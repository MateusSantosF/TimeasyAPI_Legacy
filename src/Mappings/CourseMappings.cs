using TimeasyAPI.src.DTOs.Course.Requests;
using TimeasyAPI.src.Models;

namespace TimeasyAPI.src.Mappings
{
    public static class CourseMappings
    {

        public static Course MapToEntitie(this CreateCourseRequest couse)
        {
            return new Course
            {
                Name = couse.Name,
                Period = couse.Period,
            };
        }
    }
}
