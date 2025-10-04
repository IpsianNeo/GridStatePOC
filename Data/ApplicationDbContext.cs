using GridStatePOC.Models;

using Microsoft.EntityFrameworkCore;

namespace GridStatePOC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<City> Cities { get; set; }
        public DbSet<GridState> GridStates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GridState>()
                .HasIndex(x => new { x.UserName, x.PageKey })
                .IsUnique();
        }

    }
}
