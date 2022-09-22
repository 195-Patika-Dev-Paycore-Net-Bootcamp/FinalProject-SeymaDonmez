using System;
using System.ComponentModel.DataAnnotations;

namespace PaycoreFinalProject.Base.Attribute
{
    public class RoleAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                if (value is null)
                    return new ValidationResult("Invalid Role Name.");


                return ValidationResult.Success;
            }
            catch (Exception)
            {
                return new ValidationResult("Invalid Role field.");
            }
        }
    }
}
