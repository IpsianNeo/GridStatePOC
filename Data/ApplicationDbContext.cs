using GridStatePOC.Models;

using Microsoft.EntityFrameworkCore;

namespace GridStatePOC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<City> Cities { get; set; }
        public DbSet<GridState> GridStates { get; set; }
    }
}
