using System.ComponentModel.DataAnnotations;
using TimeasyAPI.src.Models.ValueObjects.Enums;

namespace TimeasyAPI.src.Validators
{
    public class OperationalSystemAttribute : ValidationAttribute
    {

        public override bool IsValid(object? value)
        {

            if(value is null)
            {
                return true;
            }

            var os = (uint)value;

            string osString = os.ToString();

            ReadOnlySpan<char> osSpan = osString.AsSpan();


            if (Enum.TryParse<OperationalSystem>(osSpan, ignoreCase:true, out _))
            {
                return true;
            }
            return false;
        }
    }
}
