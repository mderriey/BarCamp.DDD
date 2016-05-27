namespace BarCamp.DDD.Mappings
{
    using Models;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    internal class SurferMapping : EntityTypeConfiguration<Surfer>
    {
        public SurferMapping()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.CreatedOn)
                .IsRequired();

            Property(x => x.NameLastModifiedOn)
                .IsRequired();

            this.HasMany(x => x.Surfboards)
                .WithRequired()
                .HasForeignKey(x => x.SurferId);
        }
    }
}
