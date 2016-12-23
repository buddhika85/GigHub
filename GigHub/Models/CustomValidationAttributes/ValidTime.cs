using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.Models.CustomValidationAttributes
{
    public sealed class ValidTime : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime timePassed;
            return (DateTime.TryParseExact(
                Convert.ToString(value),
                "h:mm:ss tt",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out timePassed));
        }
    }
}