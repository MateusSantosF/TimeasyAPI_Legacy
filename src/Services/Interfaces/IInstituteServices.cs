using TimeasyAPI.src.DTOs.Institute;
using TimeasyAPI.src.DTOs.Institute.Request;

namespace TimeasyAPI.src.Services.Interfaces
{
    public interface IInstituteServices
    {

        public Task UpdateAsync(UpdateInstituteRequest request);


    }
}
