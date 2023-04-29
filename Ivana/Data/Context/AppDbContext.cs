using Ivana.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ivana.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<DemandEntity> Demands { get; set; }
        public DbSet<EconomicSituationEntity> EconomicSituations { get; set; }
        public DbSet<FamilyCompositionEntity> FamilyCompositions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
