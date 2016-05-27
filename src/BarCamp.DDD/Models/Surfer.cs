namespace BarCamp.DDD.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Surfer
    {
        public Surfer()
        {
            Surfboards = new HashSet<Surfboard>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime NameLastModifiedOn { get; set; }
        public virtual ICollection<Surfboard> Surfboards { get; private set; }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"#{Id}: {FirstName} {LastName} created on {CreatedOn.ToShortDateString()} at {CreatedOn.ToLongTimeString()}");

            foreach (var surfboard in Surfboards)
            {
                builder.AppendLine($"  - {surfboard.ToString()}");
            }

            return builder.ToString();
        }
    }

}
