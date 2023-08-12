namespace TimeasyAPI.src.Helpers
{
    public static class RandomNumberGenerator
    {
        private static Random random = new Random();
        public static string GenerateRandomNumber(int length)
        {
            const string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            char[] result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = characters[random.Next(characters.Length)];
            }

            return new string(result);
        }
    }
}
