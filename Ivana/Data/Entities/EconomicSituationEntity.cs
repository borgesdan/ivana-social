using System.ComponentModel.DataAnnotations;

namespace Ivana.Data.Entities
{
    public class EconomicSituationEntity
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string? Name { get; set; }

        public EconomicSituationIncomeType Income { get; set; }

        [StringLength(200)]
        public decimal IncomeAmount { get; set; }

        [StringLength(5000)]
        public string? Observations { get; set; }
    }
}