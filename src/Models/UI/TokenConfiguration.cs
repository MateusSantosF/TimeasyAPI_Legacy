namespace TimeasyAPI.src.Models.UI
{
    public class TokenConfiguration
    {
        public int ExpirationHours { get; set; } = 2;
        public string SecretJwtKey { get; set; }
    }
}
