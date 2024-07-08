using System.ComponentModel.DataAnnotations;

namespace EphProvider.Models
{
    public class PVT
    {
        public int Id { get; set; }
        public float LatitudeLib { get; set; }
        public float LongitudeLib { get; set; }
        public float LatitudeRaw { get; set; }
        public float LongitudeRaw { get; set; }
    }
}
