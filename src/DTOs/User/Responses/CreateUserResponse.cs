namespace TimeasyAPI.src.DTOs.User
{
    public class CreateUserResponse
    {
        public Guid UserId { get; set; }
        public Guid InstituteId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string InstituteName { get; set; }
        public string OpenHour { get; set; }
        public string CloseHour { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
    }
}
