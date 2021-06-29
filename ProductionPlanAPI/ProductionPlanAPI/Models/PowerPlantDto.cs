using Newtonsoft.Json;
using ProductionPlanAPI.Helpers;
using System.ComponentModel.DataAnnotations;
using static ProductionPlanAPI.Helpers.Enums;

namespace ProductionPlanAPI.Models
{
    public class PowerPlantDto
    {
        [Required]
        public string Name { get; set; }

        [PowerPlantType]
        [EnumDataType(typeof(PowerPlantType))]
        public PowerPlantType Type { get; set; }

        [Required]
        public decimal Efficiency { get; set; }

        [Required]
        public decimal Pmin { get; set; }

        [Required]
        public decimal Pmax { get; set; }
    }
}
