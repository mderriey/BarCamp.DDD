namespace BarCamp.DDD.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Surfer
    {
        protected Surfer()
        {
            Surfboards = new HashSet<Surfboard>();
        }

        public Surfer(string firstName, string lastName)
            : this()
        {
            CreatedOn = DateTime.Now;
            ChangeName(firstName, lastName);
        }

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime NameLastModifiedOn { get; private set; }
        public virtual ICollection<Surfboard> Surfboards { get; private set; }

        public void ChangeName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException("The first name cannot be null or empty.");
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException("The last name cannot be null or empty.");
            }

            FirstName = firstName;
            LastName = lastName;
            NameLastModifiedOn = DateTime.Now;
        }

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
