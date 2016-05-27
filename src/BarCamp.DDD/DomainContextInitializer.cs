namespace BarCamp.DDD
{
    using Models;
    using System.Data.Entity;

    internal class DomainContextInitializer : CreateDatabaseIfNotExists<DomainContext>
    {
        protected override void Seed(DomainContext context)
        {
            var taj = new Surfer("Taj", "Burrow");
            taj.AddSurfboard("Webber", 5, 11);
            taj.AddSurfboard("Matt Biolos", 6, 2);

            var julian = new Surfer("Julian", "Wilson");
            julian.AddSurfboard("JS", 5, 9);
            julian.AddSurfboard("JS", 5, 10);

            var mick = new Surfer("Mick", "Fanning");
            mick.AddSurfboard("DHD", 6, 0);
            mick.AddSurfboard("DHD", 6, 2);

            context.Surfers.AddRange(new[] { taj, julian, mick });
            context.SaveChanges();
        }
    }
}
