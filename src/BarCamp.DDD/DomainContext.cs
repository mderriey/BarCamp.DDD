namespace BarCamp.DDD
{
    using Mappings;
    using Models;
    using System.Data.Entity;

    public class DomainContext : DbContext
    {
        public DomainContext()
            : base("DomainContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Configurations
                .Add(new SurferMapping())
                .Add(new SurfboardMapping());
        }

        public DbSet<Surfer> Surfers { get; set; }
    }
}
