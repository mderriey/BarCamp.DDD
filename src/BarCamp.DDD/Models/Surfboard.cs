namespace BarCamp.DDD.Models
{
    public class Surfboard
    {
        public int Id { get; set; }
        public int SurferId { get; set; }
        public string ShaperName { get; set; }
        public int Feet { get; set; }
        public int Inches { get; set; }

        public override string ToString()
        {
            return $"{ShaperName} {Feet}'{Inches}\"";
        }
    }
}
