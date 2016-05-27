namespace BarCamp.DDD.Models
{
    using DelegateDecompiler;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Surfer
    {
        protected Surfer()
        {
            SurfboardsStorage = new HashSet<Surfboard>();
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
        protected virtual ICollection<Surfboard> SurfboardsStorage { get; private set; }

        [Computed]
        public IEnumerable<Surfboard> Surfboards { get { return SurfboardsStorage.Skip(0); } }

        [Computed]
        public string FullName { get { return string.Concat(FirstName, " ", LastName); } }

        public void AddSurfboard(string shaperName, int feet, int inches)
        {
            if (SurfboardsStorage.Count >= 5)
            {
                throw new InvalidOperationException("A surfer cannot have more than 5 surfboards.");
            }

            SurfboardsStorage.Add(new Surfboard(shaperName, feet, inches, Id));
        }

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
