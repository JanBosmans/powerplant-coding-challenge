using ProductionPlanAPI.Helpers;
using ProductionPlanAPI.Models;
using static ProductionPlanAPI.Helpers.Enums;

namespace ProductionPlanAPI.Services
{
    public class FuelService : IFuelService
    {
        public decimal GetFuelPrize(Fuel fuels, Enums.PowerPlantType type)
        {
            return type switch
            {
                PowerPlantType.gasfired => fuels.Gas,
                PowerPlantType.turbojet => fuels.Kerosine,
                PowerPlantType.windturbine => 0,
                _ => 0,
            };
        }
    }
}
