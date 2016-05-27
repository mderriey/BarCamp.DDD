namespace BarCamp.DDD
{
    using DelegateDecompiler;
    using System;
    using System.Data.Entity;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DomainContextInitializer());

            using (var context = new DomainContext())
            {
                // Listing all the surfers
                var people = context
                    .Surfers
                    .Include(x => x.Surfboards)
                    .Where(x => x.FullName.Contains("Taj") || x.FullName.Contains("Wilson"))
                    .Decompile()
                    .ToList();

                people.ForEach(Console.WriteLine);
            }

            Console.ReadLine();
        }
    }
}
