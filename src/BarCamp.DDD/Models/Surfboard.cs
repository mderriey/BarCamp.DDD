namespace BarCamp.DDD.Models
{
    using System;

    public class Surfboard
    {
        private Surfboard()
        {
        }

        public Surfboard(string shaperName, int feet, int inches, int surferId)
        {
            if (string.IsNullOrWhiteSpace(shaperName))
            {
                throw new ArgumentNullException("The name of the shaper cannot be null or empty.");
            }

            if (feet < 5)
            {
                throw new ArgumentException("A surfer cannot use a surfboard shorter than 5 foot long.");
            }

            if (inches < 0 || inches > 11)
            {
                throw new ArgumentException("It doesn't make sense to have a number of inches lower than 0 or greater than 11.");
            }

            if (surferId < 0)
            {
                throw new ArgumentException("The id of the surfer cannot be lower than 0.");
            }

            ShaperName = shaperName;
            Feet = feet;
            Inches = inches;
            SurferId = surferId;
        }

        public int Id { get; private set; }
        public int SurferId { get; private set; }
        public string ShaperName { get; private set; }
        public int Feet { get; private set; }
        public int Inches { get; private set; }

        public override string ToString()
        {
            return $"{ShaperName} {Feet}'{Inches}\"";
        }
    }
}
