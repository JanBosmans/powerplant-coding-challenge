using System;
using System.ComponentModel.DataAnnotations;
using static ProductionPlanAPI.Helpers.Enums;

namespace ProductionPlanAPI.Helpers
{
    public class PowerPlantTypeAttribute : RequiredAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Enum.IsDefined(typeof(PowerPlantType), value))
            {
                return ValidationResult.Success; 
            }

            return new ValidationResult("Unknown type of powerplant: " + value.ToString());
        }
    }
}
