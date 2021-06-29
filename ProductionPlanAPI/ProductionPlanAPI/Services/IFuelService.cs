using ProductionPlanAPI.Models;
using static ProductionPlanAPI.Helpers.Enums;

namespace ProductionPlanAPI.Services
{
    public interface IFuelService
    {
        decimal GetFuelPrize(Fuel fuels, PowerPlantType type);
    }
}
