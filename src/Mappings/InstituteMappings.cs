using TimeasyAPI.src.DTOs.Institute;
using TimeasyAPI.src.DTOs.Institute.Request;
using TimeasyAPI.src.Models;

namespace TimeasyAPI.src.Mappings
{
    public static class InstituteMappings
    {

        public static Institute MapToEntitie(this UpdateInstituteRequest institute)
        {
            return new Institute
            {
                Id = Guid.Parse(institute.InstituteId),
                Name = institute.InstituteName,
                OpenHour = institute.OpenHour,
                CloseHour = institute.CloseHour,
                Monday = institute.Monday,
                Tuesday = institute.Tuesday,
                Wednesday = institute.Wednesday,
                Thursday = institute.Thursday,
                Friday = institute.Friday,
                Saturday = institute.Saturday
            };
        }

        public static InstituteDTO EntitieToMap(this Institute institute)
        {
            return new InstituteDTO
            {
                Id = institute.Id.ToString(),
                Name = institute.Name,
                OpenHour = institute.OpenHour,
                CloseHour = institute.CloseHour,
                Monday = institute.Monday,
                Tuesday = institute.Tuesday,
                Wednesday = institute.Wednesday,
                Thursday = institute.Thursday,
                Friday = institute.Friday,
                Saturday = institute.Saturday,
                Intervals = institute?.Intervals.MapToEntitie()
            };
        }

    }
}
