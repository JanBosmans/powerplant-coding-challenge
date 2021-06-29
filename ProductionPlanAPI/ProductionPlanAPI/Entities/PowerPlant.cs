namespace ProductionPlanAPI.Entities
{
    public class PowerPlant
    {
        public string Name { get; set; }

        public decimal PricePerUnit{ get; set; }

        public decimal PminEffective { get; set; }

        public decimal PmaxEffective { get; set; }
    }
}
