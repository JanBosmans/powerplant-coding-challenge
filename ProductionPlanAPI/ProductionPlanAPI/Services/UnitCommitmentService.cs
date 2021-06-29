using ProductionPlanAPI.Entities;
using ProductionPlanAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductionPlanAPI.Services
{
    public class UnitCommitmentService : IUnitCommitmentService
    {
        public List<UnitCommitment> CreateUnitCommitments(List<PowerPlant> powerPlants, decimal load)
        {
            List<PowerPlant> powerPlantsByPrice = powerPlants.OrderByDescending(p => p.PricePerUnit).ToList();

            List<UnitCommitment> unitCommitments = new();
            decimal remainingLoad = load;
            int i = 0;

            while (remainingLoad > 0 && i < powerPlantsByPrice.Count)
            {
                if (remainingLoad > powerPlantsByPrice[i].PminEffective
                    && powerPlantsByPrice[i].PmaxEffective > 0)
                {
                    decimal assignedLoad = Decimal.Round(Math.Min(powerPlantsByPrice[i].PmaxEffective, remainingLoad), 1);

                    unitCommitments.Add(new UnitCommitment { PowerPlantName = powerPlantsByPrice[i].Name, Power = assignedLoad });

                    remainingLoad -= assignedLoad;
                }
                i++;
            }

            return unitCommitments;
        }
    }
}
