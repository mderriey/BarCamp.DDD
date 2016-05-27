namespace BarCamp.DDD
{
    using Models;
    using System;
    using System.Data.Entity;

    internal class DomainContextInitializer : CreateDatabaseIfNotExists<DomainContext>
    {
        protected override void Seed(DomainContext context)
        {
            var taj = new Surfer { FirstName = "Taj", LastName = "Burrow", CreatedOn = DateTime.Now, NameLastModifiedOn = DateTime.Now };
            taj.Surfboards.Add(new Surfboard { ShaperName = "Webber", Feet = 5, Inches = 11 });
            taj.Surfboards.Add(new Surfboard { ShaperName = "Matt Biolos", Feet = 6, Inches = 2 });

            var julian = new Surfer { FirstName = "Julian", LastName = "Wilson", CreatedOn = DateTime.Now, NameLastModifiedOn = DateTime.Now };
            julian.Surfboards.Add(new Surfboard { ShaperName = "JS", Feet = 5, Inches = 9 });
            julian.Surfboards.Add(new Surfboard { ShaperName = "JS", Feet = 5, Inches = 10 });

            var mick = new Surfer { FirstName = "Mick", LastName = "Fanning", CreatedOn = DateTime.Now, NameLastModifiedOn = DateTime.Now };
            mick.Surfboards.Add(new Surfboard { ShaperName = "DHD", Feet = 6, Inches = 0 });
            mick.Surfboards.Add(new Surfboard { ShaperName = "DHD", Feet = 6, Inches = 2 });

            context.Surfers.AddRange(new[] { taj, julian, mick });
            context.SaveChanges();
        }
    }
}
