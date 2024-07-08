using System.ComponentModel.DataAnnotations;

namespace EphProvider.Models
{
    public class Galileo
    {
        public int Id { get; set; }
        [Required] //Data Annotation
        public int SvId { get; set; }
        public int Week { get; set; }
        public int Tow { get; set; }
        [StringLength(2048)]
        public string NavigationMessage { get; set; }
        [StringLength(2048)]
        public string? Signature { get; set; }
        public string Timestamp { get; set; }
    }
}
