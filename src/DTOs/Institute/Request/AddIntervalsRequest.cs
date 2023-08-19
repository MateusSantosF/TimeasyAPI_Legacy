using TimeasyAPI.src.DTOs.Interval;
using TimeasyAPI.src.DTOs.Interval.Requests;

namespace TimeasyAPI.src.DTOs.Institute.Request
{
    public class AddIntervalsRequest
    {

        public Guid InstituteId {  get; set; }    

        public List<CreateIntervalRequest> Intervals { get; set; }
    }
}
