using ProductionPlanAPI.Entities;
using ProductionPlanAPI.Models;
using System.Collections.Generic;

namespace ProductionPlanAPI.Services
{
    public interface IPowerPlantService
    {
        List<PowerPlant> MapPowerPlants(PayLoad payLoad);
    }
}
