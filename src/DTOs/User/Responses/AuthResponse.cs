namespace TimeasyAPI.src.DTOs.User.Responses
{
    public class AuthResponse
    {

        public string Id { get;set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public uint AcessLevel { get; set; }

    }
}
