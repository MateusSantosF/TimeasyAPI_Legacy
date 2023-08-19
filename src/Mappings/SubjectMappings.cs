using TimeasyAPI.src.DTOs.Subject;
using TimeasyAPI.src.DTOs.Subject.Requests;
using TimeasyAPI.src.Models;
using TimeasyAPI.src.Models.ValueObjects.Enums;

namespace TimeasyAPI.src.Mappings
{
    public static class SubjectMappings
    {

        public static Subject MapToEntitie(this CreateSubjectRequest subject)
        {
            return new Subject()
            {
                Acronym = subject.Acronym,
                Name = subject.Name,
                Complexity = Enum.Parse<SubjectComplexity>(subject.Complexity, true),
                RoomTypeId = subject.RoomTypeId
            };
        }

        public static SubjectDTO EntitieToMap(this Subject subject)
        {
            if (subject.RoomTypeNeeded is null)
            {
                return new SubjectDTO()
                {
                    Id = subject.Id,
                    Acronym = subject.Acronym,
                    Name = subject.Name,
                    Complexity = subject.Complexity.ToString(),
                    RoomTypeId = subject.RoomTypeId.ToString()
                };
            }

            return new SubjectDTO()
            {
                Id = subject.Id.ToString(),
                Acronym = subject.Acronym,
                Name = subject.Name,
                Complexity = subject.Complexity.ToString(),
                RoomType = subject.RoomTypeNeeded.Name,
                RoomTypeId = subject.RoomTypeNeeded.Id.ToString()
            };
        }


    }
}
