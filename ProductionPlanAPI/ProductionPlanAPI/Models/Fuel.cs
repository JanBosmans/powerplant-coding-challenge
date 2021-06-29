using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ProductionPlanAPI.Models
{
    public class Fuel
    {
        [JsonProperty(PropertyName = "gas(euro/MWh)")]
        [Required]
        public decimal Gas { get; set; }

        [JsonProperty(PropertyName = "kerosine(euro/MWh)")]
        [Required]
        public decimal Kerosine { get; set; }

        [JsonProperty(PropertyName = "co2(euro/ton)")]
        [Required]
        public decimal CO2 { get; set; }

        [JsonProperty(PropertyName = "wind(%)")]
        [Required]
        public decimal Wind { get; set; }
    }
}
