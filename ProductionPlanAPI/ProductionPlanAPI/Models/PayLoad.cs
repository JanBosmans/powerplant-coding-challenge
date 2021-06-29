using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductionPlanAPI.Models
{
    public class PayLoad
    {
        [Required]
        [Range(0, Double.PositiveInfinity)]
        public decimal Load { get; set; }

        [Required]
        public Fuel Fuels { get; set; }

        [Required]
        public IEnumerable<PowerPlantDto> PowerPlants { get; set; }
    }
}
