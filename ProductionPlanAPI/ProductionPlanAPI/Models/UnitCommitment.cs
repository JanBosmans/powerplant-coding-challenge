using Newtonsoft.Json;

namespace ProductionPlanAPI.Models
{
    public class UnitCommitment
    {
        [JsonProperty(PropertyName = "name")]
        public string PowerPlantName { get; set; }

        [JsonProperty(PropertyName = "p")]
        public decimal Power { get; set; }
    }
}
