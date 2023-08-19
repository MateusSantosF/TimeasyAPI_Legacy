using TimeasyAPI.src.DTOs.Interval;
using TimeasyAPI.src.DTOs.Interval.Requests;
using TimeasyAPI.src.Models;

namespace TimeasyAPI.src.Mappings
{
    public static class IntervalMappings
    {

        public static Interval MapToEntitie(this CreateIntervalRequest interval)
        {
            return new Interval
            {
                Start = interval.Start,
                End = interval.End
            };
        }

        public static Interval MapToEntitie(this IntervalDTO interval)
        {
            return new Interval
            {
                Id = interval.Id,
                Start = interval.Start,
                End = interval.End
            };
        }

        public static List<IntervalDTO> MapToEntitie(this ICollection<Interval> intervals)
        {
            return intervals.Select(i =>
            {
                return new IntervalDTO
                {
                    Id = i.Id,
                    Start = i.Start,
                    End = i.End
                };
            }).ToList();    
            
        }
    }
}
