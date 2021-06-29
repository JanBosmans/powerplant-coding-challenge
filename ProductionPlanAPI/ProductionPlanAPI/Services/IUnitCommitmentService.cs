using ProductionPlanAPI.Entities;
using ProductionPlanAPI.Models;
using System.Collections.Generic;

namespace ProductionPlanAPI.Services
{
    public interface IUnitCommitmentService
    {
        List<UnitCommitment> CreateUnitCommitments(List<PowerPlant> powerPlants, decimal load);
    }
}
