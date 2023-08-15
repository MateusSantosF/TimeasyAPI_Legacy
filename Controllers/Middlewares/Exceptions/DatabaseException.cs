using System.Globalization;

namespace TimeasyAPI.Controllers.Middlewares.Exceptions
{
    public class DatabaseException : Exception
    {
        public DatabaseException() : base() { }

        public DatabaseException(string message) : base(message) { }

        public DatabaseException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
