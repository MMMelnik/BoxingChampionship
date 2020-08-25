using System.Data.Entity;

namespace BoxingChampionship.Models
{
    public class ChampionshipContext : DbContext
    {
        public DbSet<Battle> Battles { get; set; }
    }
}