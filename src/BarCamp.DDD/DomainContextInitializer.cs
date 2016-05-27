namespace BarCamp.DDD
{
    using Models;
    using System.Data.Entity;

    internal class DomainContextInitializer : CreateDatabaseIfNotExists<DomainContext>
    {
        protected override void Seed(DomainContext context)
        {
            var taj = new Surfer("Taj", "Burrow");
            taj.Surfboards.Add(new Surfboard("Webber", 5, 11, 0));
            taj.Surfboards.Add(new Surfboard("Matt Biolos", 6, 2, 0));

            var julian = new Surfer("Julian", "Wilson");
            julian.Surfboards.Add(new Surfboard("JS", 5, 9, 0));
            julian.Surfboards.Add(new Surfboard("JS", 5, 10, 0));

            var mick = new Surfer("Mick", "Fanning");
            mick.Surfboards.Add(new Surfboard("DHD", 6, 0, 0));
            mick.Surfboards.Add(new Surfboard("DHD", 6, 2, 0));

            context.Surfers.AddRange(new[] { taj, julian, mick });
            context.SaveChanges();
        }
    }
}
