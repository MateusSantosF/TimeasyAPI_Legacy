using TimeasyAPI.src.DTOs.User;
using TimeasyAPI.src.DTOs.User.Responses;
using TimeasyAPI.src.Models.Core;

namespace TimeasyAPI.src.Mappings
{
    public static class UserMappings
    {

        public static User MapToEntity(this CreateUserRequest createUserRequest)
        {
            if (createUserRequest is null)
                return new User();

            return new User
            {
                FullName = createUserRequest.Name,
                Email = createUserRequest.Email,
                Password = createUserRequest.Password,
                Institute = new Models.Institute
                {
                    Name = createUserRequest.InstituteName,
                    OpenHour = createUserRequest.OpenHour,
                    CloseHour = createUserRequest.CloseHour,
                    Monday = createUserRequest.Monday,
                    Tuesday = createUserRequest.Tuesday,
                    Wednesday = createUserRequest.Wednesday,
                    Thursday = createUserRequest.Thursday,
                    Friday = createUserRequest.Friday,
                    Saturday = createUserRequest.Saturday
                }
            };
        }

        public static CreateUserResponse EntityToMap(this User user)
        {
            if (user is null)
                return new CreateUserResponse();

            return new CreateUserResponse
            {
                UserId = user.Id,
                InstituteId = user.Institute.Id,
                Name = user.FullName,
                Email = user.Email,
                InstituteName = user.Institute.Name,
                OpenHour = user.Institute.OpenHour,
                CloseHour = user.Institute.CloseHour,
                Monday = user.Institute.Monday,
                Tuesday = user.Institute.Tuesday,
                Wednesday = user.Institute.Wednesday,
                Thursday = user.Institute.Thursday,
                Friday = user.Institute.Friday,
                Saturday = user.Institute.Saturday
            };
        }

        public static AuthResponse EntitityToMap(this User user)
        {
            return new AuthResponse
            {
                Id = user.Id,
                Email = user.Email,
                AcessLevel = (uint)user.AcessLevel
            };
        }
    }
}
