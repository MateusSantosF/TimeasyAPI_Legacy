using TimeasyAPI.Controllers.Middlewares.Exceptions;

namespace TimeasyAPI.src.Helpers
{
    public static class StringExtensions
    {
        public static Guid TryGetIdByString(this string id)
        {

            if (!Guid.TryParse(id, out Guid entitieId))
            {
                throw new AppException(ErrorMessages.InvalidIdFormat);
            }

            return entitieId;
        }

        public static DateOnly TryParseToBrLocateDate(this string date)
        {
            if (DateOnly.TryParseExact(date, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateOnly result))
            {
                return result;
            }
            throw new ArgumentException("A data não está no formato correto (dd/MM/yyyy).");
        }
    }
}
