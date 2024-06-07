using System.ComponentModel.DataAnnotations;

namespace EphProvider.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required] //Data Annotation
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
