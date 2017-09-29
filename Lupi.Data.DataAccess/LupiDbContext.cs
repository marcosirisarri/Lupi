using Lupi.Data.Entities;
using System.Data.Entity;

namespace Lupi.Data.DataAccess
{
    public class LupiDbContext : DbContext
    {
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Base64Image> Images { get; set; }
        public DbSet<Collar> Collars { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }

        public LupiDbContext() : base("name=Lupi") { }
    }
}
