using System.ComponentModel.DataAnnotations;
using TimeasyAPI.src.Models.ValueObjects.Enums;

namespace TimeasyAPI.src.Validators
{
    public class OperationalSystemAttribute : ValidationAttribute
    {

        public override bool IsValid(object value)
        {

            var os = (string)value;

            if(Enum.TryParse<OperationalSystem>(os, ignoreCase:true, out var operationalSystem))
            {
                return true;
            }
            return false;
        }
    }
}
