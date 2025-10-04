using GridStatePOC.Models;

namespace GridStatePOC.Data
{
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext db)
        {
            if (!db.Cities.Any())
            {
                db.Cities.AddRange(
                    new City { Name = "Mumbai", State = "Maharashtra", Country = "India", Population = 20000000 },
                    new City { Name = "Delhi", State = "Delhi", Country = "India", Population = 17000000 },
                    new City { Name = "Bengaluru", State = "Karnataka", Country = "India", Population = 8500000 }
                );
                db.SaveChanges();
            }
        }
    }
}
