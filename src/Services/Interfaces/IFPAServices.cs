using TimeasyAPI.src.DTOs.FPA.requests;

namespace TimeasyAPI.src.Services.Interfaces
{
    public interface IFPAServices
    {

        Task FillAsync(FillFPARequest request);

    }
}
