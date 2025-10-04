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
                    new City { Name = "Mumbai", State = "Maharashtra", Country = "India", Population = 20411274 },
                    new City { Name = "Delhi", State = "Delhi", Country = "India", Population = 16787941 },
                    new City { Name = "Bengaluru", State = "Karnataka", Country = "India", Population = 8443675 },
                    new City { Name = "Chennai", State = "Tamil Nadu", Country = "India", Population = 7090000 },
                    new City { Name = "Kolkata", State = "West Bengal", Country = "India", Population = 4486679 }
                );
                db.SaveChanges();
            }
        }
    }
}
