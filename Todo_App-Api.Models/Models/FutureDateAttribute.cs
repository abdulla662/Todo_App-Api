using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo_App_Api.Models.Models
{
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true; // Allow null dates (since it's a nullable DateTime?)
            }

            if (value is DateTime date)
            {
                return date > DateTime.UtcNow;  // Validate that the date is in the future
            }

            // If it's not a valid DateTime, return false
            return false;
        }
    }
}
