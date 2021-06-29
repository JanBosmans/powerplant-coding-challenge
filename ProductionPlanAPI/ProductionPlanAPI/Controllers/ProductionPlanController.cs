using Microsoft.AspNetCore.Mvc;
using ProductionPlanAPI.Entities;
using ProductionPlanAPI.Models;
using ProductionPlanAPI.Services;
using System.Collections.Generic;
using System.Linq;

namespace ProductionPlanAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductionPlanController : ControllerBase
    {
        private readonly IPowerPlantService _powerPlantService;
        private readonly IUnitCommitmentService _unitCommitmentService;

        public ProductionPlanController(IPowerPlantService powerPlantService, IUnitCommitmentService unitCommitmentService)
        {
            _powerPlantService = powerPlantService;
            _unitCommitmentService = unitCommitmentService;
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult Post([FromBody] PayLoad payLoad)
        {            
            if (!ModelState.IsValid)         
                return BadRequest(ModelState);

            // Create List of powerplants with price per unit and effective pMax
            List<PowerPlant> powerPlants = _powerPlantService.MapPowerPlants(payLoad);

            // Calculate maximum power output
            // Validation error if load > maxoutput
            decimal maxPower = powerPlants.Select(p => p.PmaxEffective).Sum();
            if (payLoad.Load > maxPower)
            {
                ModelState.AddModelError("Load", $"Requested load {payLoad.Load} exceeds maximum power output {maxPower}");
                return BadRequest(ModelState);
            }

            List<UnitCommitment> unitCommitments = _unitCommitmentService.CreateUnitCommitments(powerPlants, payLoad.Load);

            // validation error if total committed power <> load
            decimal commitmentTotalLoad = unitCommitments.Select(u => u.Power).Sum();
            if (commitmentTotalLoad != payLoad.Load) 
            {
                return NotFound(unitCommitments);
            }

            return Ok(unitCommitments);
        }
    }
}
