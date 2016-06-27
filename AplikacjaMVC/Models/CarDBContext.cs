using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AplikacjaMVC.Models
{
    public class CarDBContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Seller> Sellers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Car>()
                .HasRequired(a => a.Seller)
                .WithRequiredDependent()
                .WillCascadeOnDelete();

            modelBuilder.Entity<Car>()
                .HasRequired(a => a.Engine)
                .WithRequiredDependent()
                .WillCascadeOnDelete();
        }
}
}