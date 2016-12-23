using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.Models.CustomValidationAttributes
{
    /*Future date data validation*/
    public sealed class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTimePassed;

            // passing the date time input to a datetime object
            if (!DateTime.TryParseExact(Convert.ToString(value),
                "dd/MM/yy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateTimePassed))
                return false;


            return (dateTimePassed > DateTime.Now);
        }
    }
}