using TimeasyAPI.src.DTOs.FPA.Schedule;
using TimeasyAPI.src.Models.Core;

namespace TimeasyAPI.src.Mappings
{
    public static class ScheduleMapping
    {

        public static Schedule MapToEntitie(this ScheduleDTO interval)
        {
            return new Schedule
            {
                Start = interval.Start,
                End = interval.End
            };
        }
    }
}
