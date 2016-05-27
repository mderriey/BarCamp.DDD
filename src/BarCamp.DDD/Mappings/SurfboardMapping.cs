namespace BarCamp.DDD.Mappings
{
    using Models;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    internal class SurfboardMapping : EntityTypeConfiguration<Surfboard>
    {
        public SurfboardMapping()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.ShaperName)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.Feet)
                .IsRequired();

            Property(x => x.Inches)
                .IsRequired();
        }
    }
}
