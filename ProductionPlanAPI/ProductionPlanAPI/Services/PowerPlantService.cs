using ProductionPlanAPI.Entities;
using ProductionPlanAPI.Models;
using System.Collections.Generic;
using static ProductionPlanAPI.Helpers.Enums;

namespace ProductionPlanAPI.Services
{
    public class PowerPlantService : IPowerPlantService
    {
        private readonly IFuelService _fuelService;

        public PowerPlantService(IFuelService fuelService) 
        {
            _fuelService = fuelService;
        }
        public List<PowerPlant> MapPowerPlants(PayLoad payLoad)
        {
            List<PowerPlant> powerPlants = new();

            foreach (PowerPlantDto powerPlant in payLoad.PowerPlants)
            {
                powerPlants.Add(MapPowerPlant(powerPlant, payLoad.Fuels));
            }

            return powerPlants;
        }
        private PowerPlant MapPowerPlant(PowerPlantDto powerPlant, Fuel fuels) { 
            decimal fuelPrize = _fuelService.GetFuelPrize(fuels, powerPlant.Type);
            decimal pricePerUnit;
            decimal pMaxEffective;

            if (powerPlant.Type == PowerPlantType.windturbine)
            {
                pricePerUnit = 0;
                pMaxEffective = powerPlant.Pmax * fuels.Wind / 100;
            }
            else
            {
                //No 'Efficiency <> 0' validation added as Error Handling test
                pricePerUnit = fuelPrize / powerPlant.Efficiency;
                pMaxEffective = powerPlant.Pmax;
            }

            return new PowerPlant
            {
                Name = powerPlant.Name,
                PricePerUnit = pricePerUnit,
                PminEffective = powerPlant.Pmin,
                PmaxEffective = pMaxEffective
            };
        }
    }
}
