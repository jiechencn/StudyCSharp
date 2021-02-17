using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AttributeTest
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class GenderAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            char convertedValue = (char)value;

            if (convertedValue != 'F')
            {
                return ValidationResult.Success;
            }

            else
            {
                return new ValidationResult(ErrorMessage);
            }
        }

    }
}
